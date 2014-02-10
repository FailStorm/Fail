using UnityEngine;
using System.Collections;

public class WaterBound : MonoBehaviour {

	float originalDrag, originalGravity;
	// Use this for initialization
	void Start () {
		originalDrag = 0;
		originalGravity = 0;
	}

	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player"/* && Player.GetForm() == 2*/)
		{
			Player.SetSwimming(true);
			//Saves the original drag and gravity
			originalDrag = obj.rigidbody2D.drag;
			originalGravity = obj.rigidbody2D.gravityScale;
			obj.rigidbody2D.drag = 10;
			obj.rigidbody2D.gravityScale = 3;
		}
	}
	
	void OnTriggerExit2D(Collider2D obj)
	{
		if (obj.gameObject.name == "Player")
		{
			Player.SetSwimming(false);
			obj.rigidbody2D.drag = originalDrag;
			obj.rigidbody2D.gravityScale = originalGravity;
		}
	}
}
