using UnityEngine;
using System.Collections;

public class AmmoItem : MonoBehaviour {
	public string itemName;
	public AudioClip pickUpSound;
	public int ammo = 32;
	public string weaponPath;
	protected Transform weapon;

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
			if(weapon)
				GUI.Label(new Rect(300,300,500,200), "Wciśnij E aby zabrać "+itemName);
			else
				GUI.Label(new Rect(300,300,500,200), "Nie masz tej broni");
		}
	}

	void Update()
	{
		if (!weapon) {
			GameObject gObject = GameObject.Find (weaponPath);
			if (!gObject)
				return;
				weapon = gObject.transform;
		}

		if (triggered && Input.GetKeyDown ("e")) {
			pickUp();
		}
	}

	void pickUp()
	{
		//weapon.SendMessage ("addAmmo", ammo, SendMessageOptions.DontRequireReceiver);
		audio.PlayOneShot(pickUpSound);
		renderer.enabled = false;
		//gun colt = weapon.gameObject.GetComponent<gun>();
		//colt.addAmmo (ammo);
		Inventory inventory=GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		inventory.AddItem(new Item("M9 Ammo",1,"Amunicja do broni M9",Item.ItemType.Ammo,0));

		triggered = false;
		Destroy(gameObject, pickUpSound.length);
	}
}
