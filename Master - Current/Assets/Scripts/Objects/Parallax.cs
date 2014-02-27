using UnityEngine;
using System.Collections;

public class Parallax : MonoBehaviour {

	private GameObject[] mountains;
	private Transform camera;

	// Use this for initialization
	void Start () {
		mountains = GameObject.FindGameObjectsWithTag("Parallax");
		camera = GameObject.FindGameObjectWithTag("MainCamera").transform;

	}
	
	// Update is called once per frame
	void Update () {
		foreach (GameObject mountain in mountains)
		{
			mountain.transform.position = new Vector3(-camera.position.x * (10 /mountain.transform.position.z) + 5,mountain.transform.position.y, mountain.transform.position.z);
		}
	}
}
