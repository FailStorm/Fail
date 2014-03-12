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
						Player.PlaceInWorld(other.rigidbody2D, -200, 10);
						//if (cam.GetTrans () == 1)
						//	Player.ResetPos (rigidbody2D);
						cam.StartFade (new Color(0,0,0,1), 1.0f);
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
