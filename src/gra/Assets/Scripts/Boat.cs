using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	protected bool triggered = false;
	private Inventory inventory;
	
	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;
			//TODO 
		
		}
	}
	
	void OnTriggerExit( Collider other)
	{
		if (other.gameObject.tag == "Player"){
			triggered = false;
		}
	}


}
