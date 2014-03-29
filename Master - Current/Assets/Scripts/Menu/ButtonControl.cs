using UnityEngine;
using System.Collections;

public class ButtonControl : MonoBehaviour {

	bool mouseUp, mouseOver, mouseExit;
	
	void OnMouseUp()
	{
		mouseUp = true;
	}	
	
	void OnMouseOver()
	{
		mouseOver = true;
	}
	
	void OnMouseExit()
	{
		mouseExit = true;
	}
	
	void SetMouseUp()
	{
		mouseUp = false;
	}
	
	void SetMouseOver()
	{
		mouseOver = false;
	}
	
	void SetMouseExit()
	{
		mouseExit = false;
	}
	
	bool GetMouseUp()
	{
		return mouseUp;
	}
	
	//getters
	
}
