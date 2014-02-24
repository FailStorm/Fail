using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {
	
	public GUIStyle PlayStyle, AboutStyle, CreditsStyle, SettingsStyle;
	public float volumeLevel = 10.0f;
	bool settings = false;

	void OnGUI(){

		

		//BeginArea(Rect screenRect, GUIStyle style);

		GUILayout.BeginArea (new Rect (210, 225, 100, 100));
		if (GUILayout.Button ("", PlayStyle)) 
		{
			Application.LoadLevel(1);
		}
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (285, 175, 100, 100));
		if (GUILayout.Button ("", AboutStyle)) 
		{
		}
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (380, 180, 100, 100));
		if (GUILayout.Button ("", CreditsStyle)) 
		{
		}
		GUILayout.EndArea ();

		GUILayout.BeginArea (new Rect (170, 320, 100, 100));
		if (GUILayout.Button ("", SettingsStyle)) 
		{
			settings = true;
		}
		GUILayout.EndArea ();

		if (settings)
		{
			volumeLevel = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), volumeLevel, 10.0F, 20.0F);
			
			if (GUI.Button (new Rect (25, 50, 100, 50), "Done")) 
			{
				settings = false;
			}
			
			//audio.volume = volumeLevel *0.2; Doesn't go in here btw
		}


	}
}
