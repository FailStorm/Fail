using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour
{
	public static int form = 0;	// Which state the player is in
	public bool grounded;
	public static bool swimming = false;
	public AudioClip mySound;
	
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
		mySound = (AudioClip)Resources.Load("M:/Abertay/Year 3/Project/Master - Current/Assets/ubw.wav");
		//audio.clip = mySound;
		//audio.Play();
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
	}

	void OnCollisionEnter2D(Collision2D obj)
	{
		if (obj.gameObject.name == "Floor")
		{
			grounded = true;
		}
	}

	void OnCollisionExit2D(Collision2D obj)
	{
		if (obj.gameObject.name == "Floor")
		{
			grounded = false;
		}
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
