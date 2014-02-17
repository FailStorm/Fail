using UnityEngine;
using System.Collections;

public class WaterBound : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player" && Player.GetForm() == 2)
		{
			Player.SetSwimming(true);
			obj.rigidbody2D.gravityScale = 1;
		}
	}
	
	void OnTriggerExit2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player")
		{
			Player.SetSwimming(false);
			obj.rigidbody2D.gravityScale = 15;
		}
	}
}
