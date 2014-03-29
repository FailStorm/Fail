using UnityEngine;
using System.Collections;

public class Menu : MonoBehaviour {

	public GameObject waveyLines, startButton, settingsButton, creditsButton, aboutButton;
	public float volumeLevel = 10.0f;
	bool settings = false;
	bool menuActive = true;
	int menuAlpha = 0;
	bool mouseUp;
	
	void Start()
	{
		waveyLines = GameObject.Find("WaveyLines");
		startButton = GameObject.Find ("play");
		settingsButton = GameObject.Find ("settings");
		creditsButton = GameObject.Find ("credits");
		aboutButton = GameObject.Find ("about");
		waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
	}

	void OnGUI()
	{
		if (settings)
		{
			volumeLevel = GUI.HorizontalSlider(new Rect(25, 25, 100, 30), volumeLevel, 10.0F, 20.0F);
			
			if (GUI.Button (new Rect (25, 50, 100, 50), "Done")) 
			{
				settings = false;
			}
		}
	}

	void OnMouseExit()
	{
		if (menuActive)
		{
			if (this.gameObject.name == "play") 
			{
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0); 
				WaveyLines.StopLines();	
			}
			
			if (this.gameObject.name == "settings") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0); 
				WaveyLines.StopLines();
			}
			
			//
			if (this.gameObject.name == "about") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
				WaveyLines.StopLines();
			}
			
			if (this.gameObject.name == "credits") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (0, 0, 0, 0);
				WaveyLines.StopLines();
			}
		}
	}

	void OnMouseOver()
	{
		Debug.Log("oiner");
		if (menuActive)
		{
			if (this.gameObject.name == "play")
			{
				Debug.Log("oiner");
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
				WaveyLines.PlayLines();
			}
			
			if (this.gameObject.name == "settings") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
				WaveyLines.PlayLines();
			}
			
			//
			if (this.gameObject.name == "about") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
				WaveyLines.PlayLines(); 
			}
			
			if (this.gameObject.name == "credits") 
			{	
				waveyLines.GetComponent<SpriteRenderer>().color = new Color (255, 255, 255, 255);
				WaveyLines.PlayLines();
			}
		}
	}
	
	void OnMouseUp()
	{
	 	if (menuActive)
		{
			Debug.Log("Button");
			/*if (startButton.GetMouseUp())
			{
				//do stuff
				startButton.SetMouseUp();
			}*/
			
			if (this.gameObject.name == "play") 
			{
				Application.LoadLevel(2);
				Time.timeScale = 1;
			}
			
			if (this.gameObject.name == "settings") 
			{
			}
			
			//
			if (this.gameObject.name == "about") 
			{
				About ();
				HideMenu ();
				SetMenuState (false);
			}
			
			if (this.gameObject.name == "credits") 
			{
				Credits ();
				HideMenu ();
				SetMenuState (false);
			}			
		}
			
		if (this.gameObject.name == "CreditsPage(Clone)") 
		{
			Destroy(GameObject.Find("CreditsPage(Clone)"));
			ShowMenu();
			SetMenuState (true);
		}

		if (this.gameObject.name == "aboutpage(Clone)") 
		{
			Destroy(GameObject.Find("aboutpage(Clone)"));
			ShowMenu();
			SetMenuState (true);
		}
	}

	void About()
	{
		GameObject aboutInstance = Instantiate(Resources.Load("aboutpage")) as GameObject;
		aboutInstance.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}

	void Credits()
	{
		GameObject creditInstance = Instantiate(Resources.Load("CreditsPage")) as GameObject;
		creditInstance.GetComponent<SpriteRenderer>().sortingOrder = 2;
	}

	void SetMenuState(bool x)
	{
		menuActive = x;
	}

	void HideMenu()
	{
		startButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		settingsButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		aboutButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		creditsButton.GetComponent<SpriteRenderer> ().color = new Color (0, 0, 0, 0);
		
		SetMenuState(false);
	}
	
	void ShowMenu()
	{
		startButton.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
		settingsButton.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
		aboutButton.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
		creditsButton.GetComponent<SpriteRenderer> ().color = new Color (255, 255, 255, 255);
		
		SetMenuState (true);
	}
	
}
