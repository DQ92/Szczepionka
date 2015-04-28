using UnityEngine;
using System.Collections;

public class WeaponItem : MonoBehaviour {
	public AudioClip pickUpSound;
	public Vector3 rotation;
	public string prefab;

	protected bool triggered = false;
	protected WeaponManager manager;

	void Awake()
	{
		GameObject o = GameObject.Find ("/Player/Main Camera/Weapon");
		manager = o.gameObject.GetComponent<WeaponManager> ();
	}

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
		audio.PlayOneShot(pickUpSound);
		renderer.enabled = false;
		triggered = false;

		manager.AddWeapon (prefab,rotation);
		Destroy (gameObject);
	}
}
