using UnityEngine;
using System.Collections;

public class SpikeTrigger : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if (this.gameObject.name == "SpikeLand")
			{
				other.rigidbody2D.mass = 200;
				other.rigidbody2D.gravityScale = 10;
				other.rigidbody2D.drag = 0;
				Player.SetForm(1);
			}
			else if (this.gameObject.name == "SpikeWater")
			{
				other.rigidbody2D.mass = 10;
				other.rigidbody2D.gravityScale = 15;
				Player.SetForm(2);				
			}
			else if (this.gameObject.name == "SpikeAir")
			{
				other.rigidbody2D.mass = 10;
				other.rigidbody2D.gravityScale = 15;
				Player.SetForm(3);				
			}		
			Player.Reset(other.rigidbody2D);
		}
	}
}
