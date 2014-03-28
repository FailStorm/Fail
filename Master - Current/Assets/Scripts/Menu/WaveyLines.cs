using UnityEngine;
using System.Collections;

public class WaveyLines : MonoBehaviour {

	Vector3 mousePos;


	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	/*void Update()
	{
		Vector3 mousePos = Input.mousePosition;
		
		mousePos.z = -(transform.position.x - Camera.main.transform.position.x);
		
		Vector3 worldPos = Camera.main.ScreenToWorldPoint(mousePos);
		
		transform.LookAt(mousePos);
	}*/
	
	void Update () {
		
		
		
		mousePos = Input.mousePosition;            
		
		mousePos = Camera.main.ScreenToWorldPoint(mousePos);
		
		//transform.LookAt(new Vector3(mousePosition.x, mousePosition.y, transform.position.x)); 
		
		Quaternion rot = Quaternion.LookRotation(transform.position - mousePos, Vector3.forward );
		
		transform.rotation = rot;   
		
		transform.eulerAngles = new Vector3(0, 0,transform.eulerAngles.z); 
		
	}
}
