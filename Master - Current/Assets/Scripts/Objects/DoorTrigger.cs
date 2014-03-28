using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour 
{
	CameraFade cam;

	void OnTriggerStay2D(Collider2D other)
	{
		if (Player.GetForm () != 0) 
		{
			// Triggers if collides with the player
			if (other.gameObject.collider2D.name == "Player") 
			{
				if (Player.GetRam ()) 
				{
					if (this.gameObject.name == "Door1") 
					{
						Player.SetCheckpoint(1);
						Player.Reset(other.rigidbody2D);
						Player.dead = false;
					}

					if (this.gameObject.name == "Door2") 
					{
							
					}

					if (this.gameObject.name == "Door3") 
					{
							
					}
				}
			}
		}
	}
	
	
}
