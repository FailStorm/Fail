using UnityEngine;
using System.Collections;

public class JetTrigger : MonoBehaviour {
	
	//When the player gets inside a water jet or a spike
	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.collider2D.name == "Player")
		{
			obj.rigidbody2D.AddForce(new Vector2(0, 25000 * Time.deltaTime));
		}
	}
}
