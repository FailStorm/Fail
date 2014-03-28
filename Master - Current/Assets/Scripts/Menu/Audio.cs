using UnityEngine;
using System.Collections;

public class Audio : MonoBehaviour {
	
	private Object[] sounds;
	private AudioSource source;
	public bool type;
	
	void Start()
	{
		if (type) {
			sounds = Resources.LoadAll ("Audio (Final)/General Ambience/Land/Type1", typeof(AudioClip));
			source = GetComponent<AudioSource> ();
			PlayNextSong ();
		} 
		else 
		{
			sounds = Resources.LoadAll ("Audio (Final)/General Ambience/Land/Type2", typeof(AudioClip));
			source = GetComponent<AudioSource> ();
			PlayNextSong ();
		}
	}
	void LoadSound(string directory)
	{
		sounds = Resources.LoadAll (directory, typeof(AudioClip));
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void PlayNextSong(){
		
		source.clip = (AudioClip)sounds[Random.Range(0,sounds.Length)];
		source.Play();
		Invoke("PlayNextSong", source.clip.length);
	}
}
