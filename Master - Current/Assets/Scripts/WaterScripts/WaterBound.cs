using UnityEngine;
using System.Collections;

public class WaterBound : MonoBehaviour {
	
	// Use this for initialization
	void Start () {

	}

	void OnTriggerEnter2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player"/* && Player.GetForm() == 2*/)
		{
			if (Player.GetForm() == 2)
				Player.SetSwimming(true);
			//Saves the original drag and gravity
			Player.originalDrag = obj.rigidbody2D.drag;
			Player.originalGravity = obj.rigidbody2D.gravityScale;
			obj.rigidbody2D.drag = 5;
			obj.rigidbody2D.gravityScale = 2;
		}
	}
	
	void OnTriggerExit2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player")
		{
			Player.SetSwimming(false);
			obj.rigidbody2D.drag = Player.originalDrag;
			obj.rigidbody2D.gravityScale = Player.originalGravity;
		}
	}
}
