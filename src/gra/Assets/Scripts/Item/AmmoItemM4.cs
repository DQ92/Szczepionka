using UnityEngine;
using System.Collections;

public class AmmoItemM4 : MonoBehaviour {
	public string itemName;
	public AudioClip pickUpSound;
	public int ammo = 60;

	public WeaponManager weaponManager;

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
			GUI.Label(new Rect(300,300,500,200), "Wciśnij E aby zabrać "+itemName);
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
		audio.PlayOneShot(pickUpSound);
		renderer.enabled = false;
		
		Inventory inventory=GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
		inventory.AddItem(new Item("M4 Ammo",1,"Amunicja do broni M4",Item.ItemType.M4Ammo,ammo,weaponManager));

		triggered = false;
		Destroy(gameObject, pickUpSound.length);
	}
}
