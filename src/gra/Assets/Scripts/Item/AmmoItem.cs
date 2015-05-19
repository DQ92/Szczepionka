using UnityEngine;
using System.Collections;

public class AmmoItem : MonoBehaviour {
	public string itemName;
	public AudioClip pickUpSound;
	public int ammo = 32;

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
		inventory.AddItem(new Item("M9 Ammo",1,"Amunicja do broni M9",Item.ItemType.M9Ammo,ammo,weaponManager));

		triggered = false;
		Destroy(gameObject, pickUpSound.length);
	}
}
