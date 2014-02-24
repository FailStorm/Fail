using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static int form = 0;	// Which state the player is in
	public bool grounded;
	public static bool swimming = false;
	public Vector2 PosStart, PosEnd;
	public static float originalDrag, originalGravity;
	
	// Reset the player to his original position
	public static void Reset(Rigidbody2D body) 
	{
		Vector2 temp;
		temp = body.transform.position;
		temp.x = -temp.x;
		temp.y = -temp.y;
		body.transform.Translate(temp);
	}

	// Use this for initialization
	void Start ()
	{
		rigidbody2D.drag = 2;
		rigidbody2D.mass = 10;
		rigidbody2D.gravityScale = 2;
	}
	
	// Update is called once per frame
	void Update ()
	{
		// Update based on which state the player is in
		// (Currently only handles movement)
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

		//Check the collision using raycasting
		BoxCollider2D boxCollider = GetComponent<BoxCollider2D>();
		
		PosStart = transform.position;
		PosEnd = transform.position;
		PosStart.y -= boxCollider.size.y * 1.5f;
		PosEnd.y -= boxCollider.size.y * 1.3f;
		
		RaycastHit2D hit = Physics2D.Linecast(PosStart, PosEnd);
		
		PosStart.x -= boxCollider.size.x;
		PosEnd.x -= boxCollider.size.x;
		
		RaycastHit2D hit2 = Physics2D.Linecast(PosStart, PosEnd);
		
		//Position for the second ray
		PosStart.x += boxCollider.size.x * 2;
		PosEnd.x += boxCollider.size.x * 2;
		
		RaycastHit2D hit3 = Physics2D.Linecast(PosStart, PosEnd);

		//Check if the rays collided
		if (hit.collider || hit2.collider || hit3.collider)
			grounded = true;
		else
			grounded = false;

		if (hit.collider)
		{
			if (hit.collider.gameObject.layer == 9)
				Physics2D.IgnoreLayerCollision(10, 9, false);
		}
		else if (hit2.collider)
		{
			if (hit2.collider.gameObject.layer == 9)
				Physics2D.IgnoreLayerCollision(10, 9, false);		
		}
		else if (hit3.collider)
		{
			if (hit3.collider.gameObject.layer == 9)
				Physics2D.IgnoreLayerCollision(10, 9, false);		
		}
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
