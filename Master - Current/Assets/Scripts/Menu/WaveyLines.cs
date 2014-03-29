using UnityEngine;
using System.Collections;
//LookAt
public class WaveyLines : MonoBehaviour {
	
	float angle;
	Vector3 mouse_pos;
	Vector3 object_pos;
	Quaternion newRotation;
	Vector3 mousePos;

	public static bool testbool = false;

	public static Animator lineAnim;

	void Start()
	{
		lineAnim = GetComponent<Animator> ();
	}


	void Update ()
	{
		mouse_pos = Input.mousePosition;
		mouse_pos.z = 10; //The distance between the camera and object
		object_pos = Camera.main.WorldToScreenPoint(this.transform.position);
		mouse_pos.x = -mouse_pos.x + object_pos.x;
		mouse_pos.y = -mouse_pos.y + object_pos.y;
		angle = Mathf.Atan2(mouse_pos.y, mouse_pos.x) * Mathf.Rad2Deg;
		newRotation = Quaternion.Euler(new Vector3(0, 0, angle));
		transform.rotation = newRotation;
	}



	public static void PlayLines()
	{
		lineAnim.SetBool("active", true); 
	}

	public static void StopLines()
	{
		lineAnim.SetBool("active", false); 
	}
}
