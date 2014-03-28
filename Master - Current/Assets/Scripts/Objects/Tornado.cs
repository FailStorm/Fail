using UnityEngine;
using System.Collections;

public class Tornado : MonoBehaviour 
{
	
	void OnTriggerStay2D(Collider2D other)
	{

		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if (this.gameObject.name == "Tornado")
			{
				float direction = Random.Range(0,359);
				float number = Random.Range(1000000,30000000);
				//other.gameObject.rigidbody2D.AddForce(new Vector2(0, number * Time.deltaTime));
				other.gameObject.rigidbody2D.AddForce(new Vector2(Mathf.Sin(direction) * number, Mathf.Cos(direction) * number));
			}
		}
	}
}