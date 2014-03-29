using UnityEngine;
using System.Collections;

public class SettingButtonScript : MonoBehaviour {

	public GameObject waveyLines, settingsButton;
	
	// Use this for initialization
	void Start () 
	{
		waveyLines = GameObject.Find("WaveyLines");
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
		settingsButton = GameObject.Find ("settings");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Settings()
	{
		Application.LoadLevel(2);
		Time.timeScale = 1;
	}
	
	void OnMouseUp()
	{
		settingsButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		Settings();
	}
	
	void OnMouseOver()
	{
		
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
		WaveyLines.PlayLines(); 
		
	}
	
	void OnMouseExit()
	{
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
		WaveyLines.StopLines();
	}
}
