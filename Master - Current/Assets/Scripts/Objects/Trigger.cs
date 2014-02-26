using UnityEngine;
using System.Collections;

public class Trigger : MonoBehaviour
{	
	void OnTriggerEnter2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.name == "Player")
		{
			if (this.gameObject.name == "TriggerLand")
			{
				other.rigidbody2D.gravityScale = 5;
				Player.SetForm(1);
			}
			else if (this.gameObject.name == "TriggerWater")
			{
				other.rigidbody2D.gravityScale = 1;
				Player.SetForm(2);
			}
			else if (this.gameObject.name == "TriggerAir")
			{
				other.rigidbody2D.gravityScale = 5;
				Player.SetForm(3);
			}
			
			// Functions are temporary for demo purposes

			//Vector2 temp;
			//temp.x = -5; temp.y = -5;
			//other.gameObject.transform.Translate(temp);
			Destroy(this.gameObject);
		}
	}
}