using UnityEngine;
using System.Collections;

public class Ladder : MonoBehaviour {
	public GameObject character;
	public CharacterMotor motor;

	public float speed = 1.0f;

	bool triggered = false;
	float gravity;

	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;
			//gravity = motor.gravity;
			motor.enabled = false;
		}
	}
	
	void OnTriggerExit( Collider other)
	{
		if (other.gameObject.tag == "Player"){
			triggered = false;
			//motor.gravity = gravity;
			motor.enabled = true;
		}
	}

	void Update()
	{
		if(!triggered)
			return;
		if(Input.GetKey("w"))
		{
			character.transform.Translate (Vector3.up * Time.deltaTime*speed);
		}
		else
		if(Input.GetKey("s"))
		{
			character.transform.Translate (Vector3.down * Time.deltaTime*speed);
		}
	}
}
