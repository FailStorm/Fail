using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static int form = 0;	// Which state the player is in
	public bool grounded;
	public static bool swimming = false, dead = false;
	public Vector2 PosStart, PosEnd;
	public static float originalDrag, originalGravity;
	private static Vector2 startPos;
	private static CameraFade cam;
	
	// Reset the player to his original position
	public static void Reset(Rigidbody2D body) 
	{
		dead = true;
		originalGravity = body.gravityScale;
		body.gravityScale = 0;
		body.velocity=Vector3.zero;
		cam.StartFade (new Color(0,0,0,1), 1.0f);
	}
	
	// Reset the player to his original position
	public static void ResetPos(Rigidbody2D body) 
	{
		Vector2 temp;
		dead = false;
		temp = body.transform.position;
		temp.x = -temp.x;
		temp.y = -temp.y;
		temp.x += startPos.x;
		temp.y += startPos.y;
		body.transform.Translate(temp);
		body.gravityScale = originalGravity;
		cam.StartFade (new Color(0,0,0,0), 0.5f);
	}
	
	// Use this for initialization
	void Start ()
	{
		cam = GetComponent<CameraFade> ();
		startPos = rigidbody2D.transform.position;
		rigidbody2D.drag = 2;
		rigidbody2D.mass = 10;
		rigidbody2D.gravityScale = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		if(dead)
			if (cam.GetTrans () == 1)
				ResetPos (rigidbody2D);
		
		bool collision = false;
		// Update based on which state the player is in
		// (Currently only handles movement)
		if(!dead)
			switch (form)
		{
			case 0:		// Hub
			PlayerHub.Move(rigidbody2D, grounded);
			break;
			case 1:		// Land
			PlayerLand.Move(rigidbody2D, grounded);
			break;
			case 2:		// Water
			if (swimming)
			{
				// If in water, swim
				PlayerWater.Move(rigidbody2D);
			}
			else
			{
				// If not in water, use default movement
				PlayerHub.Move(rigidbody2D, grounded);				
			}
			break;
			case 3:		// Air
			PlayerAir.Move(rigidbody2D, grounded);
			break;
			default:	// Default to Hub
			PlayerHub.Move(rigidbody2D, grounded);
			break;
		}		
		
		grounded = false;
		
		//Check the collision using raycasting
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
		
		PosStart = transform.position;
		PosEnd = transform.position;
		PosStart.y -= boxCollider.size.y * transform.localScale.y * 0.8f;
		PosEnd.y -= boxCollider.size.y * transform.localScale.y * 0.55f;
		
		RaycastHit2D hit = Physics2D.Linecast(PosStart, PosEnd);
		Debug.DrawLine (PosStart, PosEnd, Color.red);
		
		if (hit.collider)
		{
			if (hit.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}
		
		PosStart.x -= boxCollider.size.x * transform.localScale.x * 0.5f;
		PosEnd.x -= boxCollider.size.x * transform.localScale.x * 0.5f;
		
		RaycastHit2D hit2 = Physics2D.Linecast(PosStart, PosEnd);
		Debug.DrawLine (PosStart, PosEnd, Color.red);
		
		if (hit2.collider)
		{
			if (hit2.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}
		
		//Position for the second ray
		PosStart.x += boxCollider.size.x * transform.localScale.x;
		PosEnd.x += boxCollider.size.x * transform.localScale.x;
		
		RaycastHit2D hit3 = Physics2D.Linecast(PosStart, PosEnd);
		Debug.DrawLine (PosStart, PosEnd, Color.red);
		
		if (hit3.collider)
		{
			if (hit3.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}
		/*
		//Check if the rays collided
		if (hit.collider)
		{
					
		}
		if (hit2.collider)
		{
			grounded = true;			
		}
		if (hit3.collider)
		{
			grounded = true;		
		}
			*/
		if(collision)
			Physics2D.IgnoreLayerCollision(10, 9, false);
		else
			Physics2D.IgnoreLayerCollision(10, 9, true);
		
	}
	
	
	// Change form
	public static void SetForm(int a) 
	{
		form = a;
	}
	
	// Get the current form
	public static int GetForm()
	{
		return form;
	}
	
	
	public static void SetSwimming(bool a) 
	{
		swimming = a;
	}
	
	
	public static bool GetSwimming()
	{
		return swimming;
	}
}
