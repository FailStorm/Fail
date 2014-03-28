using UnityEngine;
using System.Collections;

public class Fish : MonoBehaviour {

	private int speed = 10;
	private float angle = 0, XSpeed = 0, YSpeed = 0;
	private bool right = true;

	// Use this for initialization
	void Start () {
		rigidbody2D.transform.position = new Vector2 (-70, -100);
		//rigidbody2D.transform.Rotate (new Vector3 (0, 0, 0));
		rigidbody2D.drag = 5;
		rigidbody2D.gravityScale = 0;
	}
	
	// Update is called once per frame
	void Update () {
		XSpeed = speed * 5 * Mathf.Cos (angle);
		YSpeed = speed * 5 * Mathf.Sin (angle);

		rigidbody2D.AddForce (new Vector2 (XSpeed, YSpeed));

		angle += 0.01f;

		if (XSpeed > 0) 
		{
			if(!right)
				rigidbody2D.transform.Rotate (new Vector3 (0, 180, 0));
			right = true;
		} 
		else 
		{
			if(right)
				rigidbody2D.transform.Rotate (new Vector3 (0, 180, 0));
			right = false;
		}
	}
}
