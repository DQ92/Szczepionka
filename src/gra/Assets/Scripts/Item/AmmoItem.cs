using UnityEngine;
using System.Collections;

public class AmmoItem : MonoBehaviour {
	public AudioClip pickUpSound;
	public int ammo = 32;
	public Transform weapon;

	protected bool triggered = false;

	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;
		}
	}

	void OnTriggerExit( Collider other)
	{
		if (other.gameObject.tag == "Player"){
			triggered = false;
		}
	}

	void OnGUI()
	{
		if (triggered)
		{

			//if (weapon.gameObject.activeSelf == true)
				GUI.Label(new Rect(300,300,500,200), "Wciśnij E aby zabrać");
		}
	}

	void Update()
	{
		if (triggered && Input.GetKeyDown ("e")) {
			pickUp();
		}
	}

	void pickUp()
	{
		//weapon.SendMessage ("addAmmo", ammo, SendMessageOptions.DontRequireReceiver);
		audio.PlayOneShot(pickUpSound);
		renderer.enabled = false;
		ColtM9 colt = weapon.gameObject.GetComponent<ColtM9>();
		colt.addAmmo (ammo);
		triggered = false;
		Destroy(gameObject, pickUpSound.length);
	}
}
