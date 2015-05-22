using UnityEngine;
using System.Collections;

public class VaccinePart : MonoBehaviour {
	public string name;
	public string desc;
	// Use this for initialization
	void Start () {
		
	}
	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player" && name!="") {
			
			GameObject.FindGameObjectWithTag("Inventory").GetComponent<Inventory>().AddItem(new Item(name,0,desc+"\nNiezbędna część szczepionki potrzebna do misji.",Item.ItemType.VaccinePart,5));
			Destroy(gameObject,0);
		}
	}
	// Update is called once per frame
	void Update () {
		
	}
}
