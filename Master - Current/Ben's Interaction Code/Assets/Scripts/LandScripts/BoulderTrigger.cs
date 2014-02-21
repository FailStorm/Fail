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
	
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "BreakableFloor")
		{
			Destroy(other.gameObject);
		}
	}
}
