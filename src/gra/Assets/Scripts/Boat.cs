using UnityEngine;
using System.Collections;

public class Boat : MonoBehaviour {

	protected bool triggered = false;
	private Inventory inventory;
	
	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;
			print("wsiadł do łódki");
			//inventory.
			//TODO 

			goToNextLevel();
			print("wsiadł do łódki");
		}
	}
	
	void OnTriggerExit( Collider other)
	{
		if (other.gameObject.tag == "Player"){
			triggered = false;
		}
	}

	private void goToNextLevel(){
		//TODO przeniesienie!
	}

}
