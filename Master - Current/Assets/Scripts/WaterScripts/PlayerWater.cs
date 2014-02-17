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
			waterSpeed = 200000;
		else
			waterSpeed = 10000;

		body.AddForce (new Vector2(Input.GetAxisRaw ("Horizontal") * waterSpeed * Time.deltaTime, Input.GetAxisRaw("Vertical") * waterSpeed* Time.deltaTime));
	}	
}
