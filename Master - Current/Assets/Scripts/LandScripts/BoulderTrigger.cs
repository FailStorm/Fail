using UnityEngine;
using System.Collections;

public class BoulderTrigger : MonoBehaviour 
{
	// Use this for initialization
	void Start () 
	{
	
	}
	
	// Update is called once per frame
	void Update () 
	{
		if(Input.GetButtonDown ("Fire1"))
			rigidbody2D.mass = 0;
		else
			rigidbody2D.mass = 3000;
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.name == "Player") 
		{
			if(Player.GetForm() == 1)
			{

			}
		}
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "BreakableFloor")
		{
			Destroy(other.gameObject);
		}
	}
}
