//Water movement/physics code
//by Gao Jinghao

using UnityEngine;
using System.Collections;

public class PlayerWater : MonoBehaviour {
	
	private static float waterSpeed;
	
	void Start () 
	{	
		
	}

	//Handles the movements
	public static void Move(Rigidbody2D body)
	{		
		if (Input.GetButtonDown ("Jump")) 
			waterSpeed = 700;
		else
			waterSpeed = 30;

		body.AddForce (new Vector2(Input.GetAxisRaw ("Horizontal") * waterSpeed * 500 * Time.deltaTime, Input.GetAxisRaw("Vertical") * waterSpeed * 500 * Time.deltaTime));
	}	
}
