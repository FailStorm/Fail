using UnityEngine;
using System.Collections;

public class WaterBound : MonoBehaviour {

	public static float breath = 1;

	// Use this for initialization
	void Start () {
		
	}
	
	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player"/* && Player.GetForm() == 2*/)
		{
			Player.SetSwimming(true);
			//Saves the original drag and gravity
			if(obj.rigidbody2D.drag != 3)
			{
				Player.originalDrag = obj.rigidbody2D.drag;
				obj.rigidbody2D.drag = 3;
			}
			if(obj.rigidbody2D.gravityScale != 2)
			{
				Player.originalGravity = obj.rigidbody2D.gravityScale;
				obj.rigidbody2D.gravityScale = 2;
			}
		}
	}

	
	void OnTriggerStay2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if(!Player.dead)
				if (breath <= 0.2f) 
				{
					other.rigidbody2D.mass = 10;
					other.rigidbody2D.gravityScale = 10;
					other.rigidbody2D.drag = 2;
					Player.originalDrag = other.rigidbody2D.drag;
					Player.originalGravity = other.rigidbody2D.gravityScale;
					
					Player.SetForm(2);				
					
					Player.Reset(other.rigidbody2D);
					Debug.Log ("lol");
				}
		}
	}
	
	void OnTriggerExit2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player")
		{
			Player.SetSwimming(false);
			obj.rigidbody2D.drag = Player.originalDrag;
			obj.rigidbody2D.gravityScale = Player.originalGravity;
		}
	}
}
