using UnityEngine;
using System.Collections;

public class CheckpointTrigger : MonoBehaviour 
{
	void OnTriggerEnter2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if (this.gameObject.name == "CheckpointA")
			{
				Player.SetCheckpoint(1);
				Debug.Log("test");
			}
			if (this.gameObject.name == "CheckpointB")
			{
				Player.SetCheckpoint(2);
				Debug.Log("test2");
			}
			if (this.gameObject.name == "CheckpointC")
			{
				Player.SetCheckpoint(3);
				Debug.Log("test3");
			}
		}
	}
}
