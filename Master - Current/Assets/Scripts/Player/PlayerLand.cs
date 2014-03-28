using UnityEngine;
using System.Collections;

public class PlayerLand : MonoBehaviour
{
	private static float xSpeed = 40;
	private static float ySpeed = 20;
	
	// Handles movement
	public static void Move (Rigidbody2D body, bool grounded)
	{
		Vector2 movement;
		movement.x = Input.GetAxisRaw ("Horizontal") * xSpeed * 20000 * Time.deltaTime;
		movement.y = 0;
		
		// Jumping
		if (Input.GetButtonDown ("Jump") && grounded) // If jump is pressed and the player is not falling / rising...
		{
			if(Time.timeScale != 0)
				movement.y = ySpeed * 20000;
		}

		if (Input.GetButtonDown ("Jump") && Player.GetSwimming ()) 
		{
			if(Time.timeScale != 0)
				movement.y = ySpeed * 10000;
		}

		/*
		//Reduce movement speed when in mid air
		if (!grounded){
			xSpeed = 20;
		}
		else
		{
			xSpeed = 40;
		}*/
		
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
	
}