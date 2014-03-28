using UnityEngine;
using System.Collections;

public class JetTrigger : MonoBehaviour {

	public bool pressure;
	private int power, superPower;
	
	//When the player gets inside a water jet or a spike
	void OnTriggerStay2D(Collider2D obj)
	{
		if (obj.gameObject.collider2D.name == "Player")
		{
			if(Player.GetForm() == 2)
			{
				power = 20000;
				superPower = 1000;
			}
			if(Player.GetForm() == 1)
			{
				power = 1000000;
				superPower = 50;
			}
			if(!pressure)
			{
				obj.rigidbody2D.AddForce(new Vector2(0, power * Time.deltaTime));
			}
			if(pressure)
			{
				obj.rigidbody2D.velocity = new Vector2(0,power * superPower);
			}
		}
	}
}
