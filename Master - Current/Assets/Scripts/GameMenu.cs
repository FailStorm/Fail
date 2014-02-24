using UnityEngine;
using System.Collections;

public class GameMenu : MonoBehaviour {

	bool paused = false;

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
			}
		}
	}

	void Pause()
	{
		OnGUI();
	}

	void OnGUI(){
	
		if (paused == true)
		{
			if (GUI.Button (new Rect (0, 0, 150, 50), "Main Menu")) {
				Application.LoadLevel(0);
				paused = false;
			}
	
			if (GUI.Button (new Rect (0, 100, 150, 50), "Settings")) {
				
			}
			
			if (GUI.Button (new Rect (0, 200, 150, 50), "About")) {
				
			}
			
			if (GUI.Button (new Rect (0, 300, 150, 50), "Credits")) {
				
			}
			
			if (GUI.Button (new Rect (0, 400, 150, 50), "Exit Game")) {
				Application.Quit();
			}
		}
	}

}
