using UnityEngine;
using System.Collections;

public class JellyFish : MonoBehaviour {

	private int speed = 0, counter = 0, direction = 1;

	// Use this for initialization
	void Start () {
		rigidbody2D.transform.position = new Vector2 (-30, -65);
		rigidbody2D.transform.Rotate (new Vector3 (0, 0, -90));
		rigidbody2D.drag = 5;
		rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		if (speed == 0) 
		{
			if (counter > 4) 
			{
				direction *= -1;
				counter = 0;
				rigidbody2D.transform.Rotate (new Vector3 (0, 0, 180));
			}

			speed = 6000;
			rigidbody2D.AddForce (new Vector2 (speed * direction * 500, 0));
			counter ++;
		}

		if (speed > 0) 
		{
			speed -= 100;
		}


	}
}
