using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	public float volumeLevel = 1.0f, menuLower = 0.01f;
	bool paused = false, settings = false;
	private static CameraFade cam;

	//Object[] sounds;

	void Start()
	{
		//sounds = Resources.LoadAll("Audio (Final)/General Ambience/Land", typeof(AudioClip));
	}

	void Update()
	{
		if (Input.GetKeyDown(KeyCode.P))
		{
			if(!paused) 
			{
				Time.timeScale = 0;
				paused = true;
				Pause ();
				
			} 
			else 
			{
				Time.timeScale = 1;
				paused = false;
				settings = false;
				
			}
		}
		//sound[0] = (AudioClip)Resources.Load("Audio (Final)/General Ambience/Land/Land_Level_General_Ambience_01", typeof(AudioClip));
	}
		/*
	void PlayNextSong(){

		//AudioSource.clip = sounds[Random.Range(0,sounds.length)];
		AudioSource.Play();
		Invoke("PlayNextSong", AudioSource.clip.length);
	}
*/
	void Pause()
	{
		OnGUI();
	}

	void OnGUI(){
	
		if (paused == true)
		{

			AudioListener.volume = volumeLevel * menuLower;

			if (GUI.Button (new Rect (0, 0, 150, 50), "Main Menu")) {
				Application.LoadLevel(0);
				paused = false;
			}
	
			if (GUI.Button (new Rect (0, 100, 150, 50), "Settings")) {
				settings = true;
			}
			
			if (GUI.Button (new Rect (0, 200, 150, 50), "About")) {
				
			}
			
			if (GUI.Button (new Rect (0, 300, 150, 50), "Credits")) {
				
			}
			
			if (GUI.Button (new Rect (0, 400, 150, 50), "Exit Game")) {
				Application.Quit();
			}

			if (settings)
			{
				volumeLevel = GUI.HorizontalSlider(new Rect(200, 100, 100, 30), volumeLevel, 0.0F, 1.0F);
				
				if (GUI.Button (new Rect (200, 120, 100, 50), "Done")) 
				{
					settings = false;
				}

				if(AudioListener.volume != volumeLevel)
					AudioListener.volume = volumeLevel;
			}

		}
		else
			AudioListener.volume = volumeLevel;
	}

}
