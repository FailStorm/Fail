// Hub movement
// Harvey Norman

using UnityEngine;
using System.Collections;

public class PlayerHub : MonoBehaviour
{
	public float xSpeed = 30;
	public float ySpeed = 16;
	
	private static PlayerHub hub;
	
	void Start()
	{
		hub = GetComponent<PlayerHub>();
	}
	
	// Handles movement
	public static void Move (Rigidbody2D body, bool grounded)
	{
		Vector2 movement;
		movement.x = Input.GetAxisRaw ("Horizontal") * hub.xSpeed * 500 * Time.deltaTime;
		movement.y = 0;
		
		// Jumping
		if (Input.GetButtonDown ("Jump") && grounded) // If jump is pressed and the player is not falling / rising...
		{
			movement.y = hub.ySpeed * 500;
		}
		
		//Reduce movement speed when in mid air
		/*
		if (!grounded){
			hub.xSpeed = 20;
		}
		else
		{
			hub.xSpeed = 30;
		}
		*/
		
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