using UnityEngine;
using System.Collections;

public class Eagle : MonoBehaviour {

	void OnTriggerEnter2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.name == "Apple")
		{
			if (this.gameObject.name == "Eagle")
			{
				Destroy(this.gameObject);
			}
		}
}
}
