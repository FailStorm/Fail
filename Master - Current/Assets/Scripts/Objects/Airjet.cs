using UnityEngine;
using System.Collections;

public class Airjet : MonoBehaviour 
{

	void OnTriggerStay2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if (this.gameObject.name == "AirJet")
			{
				other.gameObject.rigidbody2D.AddForce(new Vector2(0, 30000000 * Time.deltaTime));
			}
		}
	}
}