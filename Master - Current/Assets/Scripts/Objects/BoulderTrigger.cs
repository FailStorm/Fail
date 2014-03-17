using UnityEngine;
using System.Collections;

public class BoulderTrigger : MonoBehaviour 
{
	private Transform boulder;	
	private bool isTriggered = false;

	// Use this for initialization
	void Start () 
	{
		boulder = GameObject.FindGameObjectWithTag("Boulder").transform;
		boulder.rigidbody2D.mass = 3000;
		boulder.rigidbody2D.gravityScale = 10;
	}
	
	void OnTriggerStay2D(Collider2D other)
	{
		if (other.gameObject.collider2D.name == "Player") 
		{
			if (Player.GetRam () && isTriggered == false) 
			{
				boulder.rigidbody2D.mass = 500;

				if ((other.gameObject.transform.position.x < boulder.gameObject.transform.position.x)  && Player.GetFacingLeft() == false)
				{
					boulder.rigidbody2D.AddForce(new Vector2(20000000 * Time.deltaTime, 0));
					isTriggered = true;
				}
				else if ((other.gameObject.transform.position.x > boulder.gameObject.transform.position.x) && Player.GetFacingLeft() == true)
				{
					boulder.rigidbody2D.AddForce(new Vector2(-20000000 * Time.deltaTime, 0));
					isTriggered = true;
				}
			}
		}
	}
}
