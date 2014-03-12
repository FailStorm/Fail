/*
using UnityEngine;
using System.Collections;

public class CameraFadeV2 : MonoBehaviour {
	
		Texture2D fadeTexture;
		public float fadeSpeed = 0.2f;
		public float drawDepth = -1000f;
		
		private float alpha = 1.0f; 
		private float fadeDir = -1f;
		
		public bool fade = false;
	
	void OnGUI()
	{
		if (fade)
		{	
			alpha += fadeDir * fadeSpeed * Time.deltaTime;  
			alpha = Mathf.Clamp01(alpha);   
			
			GUI.color.a = alpha;
			
			GUI.depth = drawDepth;
			
			GUI.DrawTexture(Rect(0, 0, Screen.width, Screen.height), fadeTexture);
		}
	}	
}*/
