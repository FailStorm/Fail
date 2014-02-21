using UnityEngine;
using System.Collections;

public class Sounds : MonoBehaviour {

	static Sounds s;

	// Use this for initialization
	void Start () {
		s = GetComponent<Sounds>();
	}

	// Update is called once per frame
	void Update () {
		//
	}

	public static void Stop()
	{
		s.audio.volume = 0.5f;
	}
}
