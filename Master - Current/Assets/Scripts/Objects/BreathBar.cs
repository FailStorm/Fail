using UnityEngine;
using System.Collections;

public class BreathBar : MonoBehaviour {

	private Vector2 position;
	private float breath = 1;

	// Use this for initialization
	void Start () {
	}

	// Update is called once per frame
	void Update () {
		if (Player.GetSwimming ()) 
		{
			if(Player.GetForm() != 2)
			{
				position = GameObject.FindGameObjectWithTag ("Player").transform.position;
				position.y -= 5;
				transform.position = position;
				position.x = transform.localScale.x;
				position.x *= breath;
				transform.localScale = new Vector3 (position.x, 1, 1);
				breath -= 0.00002f;
			}
		} 
		else 
		{
			transform.position = new Vector3 (0, 0, -200);
			breath = 1;
			transform.localScale = new Vector3 (6, 1, 1);
		}

		WaterBound.breath = transform.localScale.x;
		/*
		if (breath <= 1) 
		{
			player.rigidbody2D.mass = 10;
			player.rigidbody2D.gravityScale = 10;
			player.rigidbody2D.drag = 2;
			Player.originalDrag = player.rigidbody2D.drag;
			Player.originalGravity = player.rigidbody2D.gravityScale;
			
			Player.SetForm(2);		

			Player.Reset(player.rigidbody2D);
		}*/
	}

}
