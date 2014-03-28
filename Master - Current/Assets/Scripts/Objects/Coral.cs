using UnityEngine;
using System.Collections;

public class Coral : MonoBehaviour {

	// Use this for initialization
	void Start () {
	
	}
	
	void OnCollisionEnter2D(Collision2D other)
	{
		if (other.gameObject.layer == 12)
			Destroy (gameObject);
	}
}
