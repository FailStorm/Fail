using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour 
{

	CameraFade cam;
	CameraFollow followcam;


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
						Player.PlaceInWorld(other.rigidbody2D, -200, 10);
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
