using UnityEngine;
using System.Collections;

public class PlayScript : MonoBehaviour {

	public GameObject waveyLines, playButton;
	
	// Use this for initialization
	void Start () 
	{
		waveyLines = GameObject.Find("WaveyLines");
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
		playButton = GameObject.Find ("play");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Play()
	{
		Application.LoadLevel(2);
		Time.timeScale = 1;
	}
	
	void OnMouseUp()
	{
		playButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		Play();
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
