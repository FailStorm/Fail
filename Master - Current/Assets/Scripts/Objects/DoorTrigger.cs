using UnityEngine;
using System.Collections;

public class DoorTrigger : MonoBehaviour {
	

	void OnTriggerStay2D(Collider2D other)
	{
				if (Player.GetForm () != 0) {
						// Triggers if collides with the player
						if (other.gameObject.collider2D.name == "Player") {
								if (Player.GetRam ()) {

										if (this.gameObject.name == "Door1") {
												//place player in land area.
												Application.LoadLevel (2);
										}

										if (this.gameObject.name == "Door2") {
												//place player in air area
												Application.LoadLevel (2);
										}

										if (this.gameObject.name == "Door3") {
												//place player in water area
												Application.LoadLevel (2);
										}
				
								}
						}
				}
		}
}
