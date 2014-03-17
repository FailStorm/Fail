using UnityEngine;
using System.Collections;

public class Airjet : MonoBehaviour 
{
	void OnTriggerStay2D(Collider2D other)
	{
		GameObject[] apples = GameObject.FindGameObjectsWithTag("Apple");
		if (other.gameObject.collider2D.name == "Player")
		{
			other.gameObject.rigidbody2D.AddForce(new Vector2(0, 30000000 * Time.deltaTime));
		}
		
		foreach (GameObject apple in apples)
		{
			if (apple == other.gameObject)
			{
				apple.rigidbody2D.AddForce(new Vector2(0, 50000));
			}
		}
	}
}