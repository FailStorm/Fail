using UnityEngine;
using System.Collections;

public class AppleTrigger : MonoBehaviour {

	void OnTriggerStay2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if(Player.GetRam())
			{
				//GameObject.FindGameObjectWithTag("Apple").rigidbody2D.gravityScale = 5;
				GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
				
				foreach (GameObject apple in apples)
				{
					if(apple.rigidbody2D.gravityScale == 0)
					{
						apple.rigidbody2D.gravityScale = 5;
						apple.rigidbody2D.AddForce(new Vector2(-500, 0));
					}
				}
			}
		}
	}
}
