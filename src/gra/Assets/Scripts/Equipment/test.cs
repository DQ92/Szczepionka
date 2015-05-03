using UnityEngine;
using System.Collections;

public class test : MonoBehaviour {
	Inventory inventory;
	// Use this for initialization
	void Start () {
		inventory=GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>();
	}
	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {

			inventory.AddItem(new Item("1",0,"loremi",Item.ItemType.Weapon,5));
		}
	}
	// Update is called once per frame
	void Update () {

	}
}
