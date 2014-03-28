using UnityEngine;
using System.Collections;

public class Key : MonoBehaviour {

	private bool onPlayer = false;
	private Vector2 position;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (onPlayer) 
		{
			position = GameObject.FindGameObjectWithTag ("Player").transform.position;
			transform.position = position;
		}
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		// Triggers if collides with the player
		if (other.gameObject.collider2D.name == "Player")
		{
			if(Player.pickUp)
			{
				onPlayer = true;
				rigidbody2D.gravityScale = 0;
				rigidbody2D.mass = 0;
			}
			else
			{
				onPlayer = false;
				rigidbody2D.gravityScale = 1;
				rigidbody2D.mass = 1000;
				rigidbody2D.velocity = new Vector3(0,0,0);
			}
		}
	}

	void OnCollisionEnter2D(Collision2D other)
	{
		Physics2D.IgnoreLayerCollision(10, 12, false);
		Debug.Log ("lol");
	}
}
