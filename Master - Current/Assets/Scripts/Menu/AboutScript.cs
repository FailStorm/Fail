using UnityEngine;
using System.Collections;

public class AboutScript : MonoBehaviour {

	public GameObject waveyLines, aboutButton;

	// Use this for initialization
	void Start () 
	{
		waveyLines = GameObject.Find("WaveyLines");
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
		aboutButton = GameObject.Find ("about");
	}
	
	// Update is called once per frame
	void Update () {
	
	}
	
	void About()
	{
		GameObject aboutInstance = Instantiate(Resources.Load("aboutpage")) as GameObject;
		aboutInstance.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}
	
	
	void OnMouseUp()
	{
		aboutButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		About();
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
