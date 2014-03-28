using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static int form = 0;	// Which state the player is in
	public bool grounded;
	bool CamLock = true;
	public static bool facingLeft = true, start = false;
	public static bool swimming = false, dead = false, ramStatus = false, pickUp = false;
	public Vector2 PosStart, PosEnd;
	public static Vector2 SpawnPos;
	public static float originalDrag, originalGravity;
	private static Vector2 startPos;
	private static CameraFade cam;
	private static LayerMask mask = ~(3 << 10);
	
		// Checkpoint stuff
	private static Vector2[] checkpointArray;
	private static int lastCheckpoint = 0;
		
	Animator anim;
	
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
		temp.x += checkpointArray[lastCheckpoint].x;
		temp.y += checkpointArray[lastCheckpoint].y;
		body.transform.Translate(temp);
		body.gravityScale = originalGravity;
		cam.StartFade (new Color(0,0,0,0), 0.5f);
	}
	
	//Gary 
	public static void PlaceInWorld(Rigidbody2D body, int xPos, int yPos)
	{	
		cam.StartFade (new Color(0,0,0,1), 1f);
		SpawnPos.x = xPos;
		SpawnPos.y = yPos;
	}
	
	public static void FadeToPosition(Rigidbody2D body, int xPos, int yPos)
	{
		Vector2 temp;
		temp = new Vector2 (xPos, yPos);
		body.transform.Translate(temp);
		body.gravityScale = originalGravity;
		cam.StartFade (new Color(0,0,0,0), 1f);
	}
	
	
	public static void fadeInorOut()
	{
		if (cam.GetTrans () == 1)
		{
			
		}

		if (cam.GetTrans () == 0) 
		{
			
		}
	}

	// Use this for initialization
	void Start ()
	{
		cam = GetComponent<CameraFade> ();
		anim = GetComponent<Animator>();
		startPos = rigidbody2D.transform.position;
		rigidbody2D.drag = 2;
		rigidbody2D.mass = 10;
		rigidbody2D.gravityScale = 2;
		
		
		checkpointArray = new Vector2[]
		{
			new Vector2(180, 7),
			new Vector2(-25, 0),
			new Vector2(73, -11),
			new Vector2(42, 20),
		};
	}
	
	public bool isCamLocked()
	{
		return CamLock;
	}
	
	// Update is called once per frame
	void Update ()
	{

		if (dead)
		{
			if (cam.GetTrans () == 1)
			ResetPos(rigidbody2D);
		}
		else
			if (cam.GetTrans () == 1)
			{
				ResetPos(rigidbody2D);
				CamLock = false;
			}
		
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
			anim.SetBool("isDeer", true);  
			break;
			case 2:		// Water
			PlayerWater.Move(rigidbody2D, swimming, grounded);
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
		
		RaycastHit2D hit = Physics2D.Linecast(PosStart, PosEnd, mask);
		Debug.DrawLine (PosStart, PosEnd, Color.red);
		
		if (hit.collider)
		{
			if (hit.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}
		
		PosStart.x -= boxCollider.size.x * transform.localScale.x * 0.5f;
		PosEnd.x -= boxCollider.size.x * transform.localScale.x * 0.5f;
		
		RaycastHit2D hit2 = Physics2D.Linecast(PosStart, PosEnd, mask);
		Debug.DrawLine (PosStart, PosEnd, Color.blue);
		
		if (hit2.collider)
		{
			if (hit2.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}
		
		//Position for the second ray
		PosStart.x += boxCollider.size.x * transform.localScale.x;
		PosEnd.x += boxCollider.size.x * transform.localScale.x;
		
		RaycastHit2D hit3 = Physics2D.Linecast(PosStart, PosEnd, mask);
		Debug.DrawLine (PosStart, PosEnd, Color.green);
		
		if (hit3.collider)
		{
			if (hit3.collider.gameObject.layer == 9)
				collision = true;
			
			grounded = true;
		}

		if (grounded)
			if(hit.collider)
				if (hit.collider.gameObject.layer == 4)
					grounded = false;
		
		if(collision)
			Physics2D.IgnoreLayerCollision(10, 9, false);
		else
			Physics2D.IgnoreLayerCollision(10, 9, true);		
	}
	
	
	void FixedUpdate()
	{
		//This is going to need cleaned up so so much.

		anim.SetFloat("Speed", Mathf.Abs(rigidbody2D.velocity.x));
		
		anim.SetFloat("YSpeed", Mathf.Abs(rigidbody2D.velocity.y));

		if(swimming)
			anim.SetBool (("Water"), true);		
		else
			anim.SetBool (("Water"), false);	
		
		if (grounded) 
		{
			anim.SetBool (("anim_grounded"), true);		
		} else
			anim.SetBool (("anim_grounded"), false);

		if (Input.GetButtonDown("Jump"))
		{
			if(grounded)
				anim.SetBool(("Jump"), true);
		}
		else
			anim.SetBool(("Jump"), false);
		
		if (anim.GetBool("isDeer") == true)
		{
		
		if (Input.GetButtonDown("Fire1"))
		{
			//anim.SetBool(("Action"), true);
			anim.Play("DeerRam");
			ramStatus = true;
		}
		else
			ramStatus = false;
			
		}
		/*
		if(grounded)
		{
			//anim.SetBool(("Jump"), false);
		}
		else
			anim.SetBool(("Jump"), true);
*/
		if (Input.GetAxisRaw ("Horizontal") > 0 && facingLeft)
				Flip ();
		else if (Input.GetAxisRaw ("Horizontal") < 0 && !facingLeft)
				Flip ();	
	}

	void Flip()
	{
		facingLeft = !facingLeft;
		Vector3 theScale = transform.localScale;
		theScale.x *= -1;
		transform.localScale = theScale;
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

	// Get the current form
	public static bool GetRam()
	{
		return ramStatus;
	}
	
	public static void SetSwimming(bool a) 
	{
		swimming = a;
	}
	
	
	public static bool GetSwimming()
	{
		return swimming;
	}

	public static bool GetFacingLeft()
	{
		return facingLeft;
	}
	
	public static void SetCheckpoint(int a)
	{
		lastCheckpoint = a;
	}
}
