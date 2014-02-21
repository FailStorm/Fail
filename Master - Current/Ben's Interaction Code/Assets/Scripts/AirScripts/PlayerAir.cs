using UnityEngine;
using System.Collections;

public class PlayerAir : MonoBehaviour
{
	private static float xSpeed = 70000;
	private static float ySpeed = 30000;
	
	// Handles movement
	public static void Move (Rigidbody2D body, bool grounded)
	{
		Vector2 movement;
		movement.x = Input.GetAxisRaw ("Horizontal") * xSpeed * Time.deltaTime;
		movement.y = 0;
		
		// Jumping
		if (grounded) // If jump is pressed and the player is not falling / rising...
		{
			if (Input.GetButtonDown ("Jump"))
			{
				movement.y = ySpeed;
			}
		}
		else
		{
			if (Input.GetButtonDown ("Jump"))
			{
				movement.y = ySpeed / 2;
			}
			
			body.drag = 2;
			
			if(body.velocity.y <= -3 && Input.GetButton ("Jump"))
			{
				body.drag = 6;
				body.AddForce(new Vector2(0, 500));
			}
		}
		
		// Add forces		
		if (movement.x != 0 && body.velocity.x <= 20 && body.velocity.x >= -20)
		{
			body.AddForce(new Vector2(movement.x, 0));		
		}
		
		if (movement.y != 0)
		{
			body.AddForce(new Vector2(0, movement.y));
		}
	}
}