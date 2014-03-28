//Water movement/physics code
//by Gao Jinghao

using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour {
	
	private static float waterSpeed;
	private static float xSpeed = 40;
	private static float ySpeed = 20;
	
	void Start () 
	{	
		
	}
	
	//Handles the movements
	public static void Move(Rigidbody2D body, bool swimming, bool grounded)
	{		
		Vector2 movement;

		if (swimming) 
		{
			if(Time.timeScale != 0)
				if (Input.GetButtonDown ("Jump")) 
					waterSpeed = 700;
				else
					waterSpeed = 30;
		
			body.AddForce (new Vector2 (Input.GetAxisRaw ("Horizontal") * waterSpeed * 500 * Time.deltaTime, Input.GetAxisRaw ("Vertical") * waterSpeed * 500 * Time.deltaTime));
		} 
		else 
		{
			movement.x = Input.GetAxisRaw ("Horizontal") * xSpeed * 800 * Time.deltaTime;
			movement.y = 0;
			
			// Jumping
			if (Input.GetButtonDown ("Jump") && grounded) // If jump is pressed and the player is not falling / rising...
			{
				if(Time.timeScale != 0)
					movement.y = ySpeed * 1000;
			}
			// Add forces		
			if (movement.x != 0 && body.velocity.x <= 15 && body.velocity.x >= -15)
			{
				body.AddForce(new Vector2(movement.x, 0));		
			}
			
			if (movement.y != 0)
			{
				body.AddForce(new Vector2(0, movement.y));
			}
		}

		if (Input.GetButtonDown ("Fire1")) 
		{
			if (Player.pickUp)
			{
				Player.pickUp = false;
				Physics2D.IgnoreLayerCollision(10, 12, true);
			}
			else
			{
				Player.pickUp = true;
			}
		}
	}	
}

