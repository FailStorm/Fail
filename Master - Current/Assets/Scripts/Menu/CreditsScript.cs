using UnityEngine;
using System.Collections;

public class CreditsScript : MonoBehaviour {
	
	public GameObject waveyLines, creditsButton;
	
	// Use this for initialization
	void Start () 
	{
		waveyLines = GameObject.Find("WaveyLines");
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
		creditsButton = GameObject.Find ("credits");
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void Credits()
	{
		GameObject creditsInstance = Instantiate(Resources.Load("creditspage")) as GameObject;
		creditsInstance.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}
	
	
	void OnMouseUp()
	{
		creditsButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		Credits();
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
