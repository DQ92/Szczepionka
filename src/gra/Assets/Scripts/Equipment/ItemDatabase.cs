using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class ItemDatabase : MonoBehaviour {
	public List<Item> items = new List<Item> ();


	void Start(){
		items.Add (new Item ("2", 0, "lol", Item.ItemType.Weapon));
		items.Add (new Item ("3", 1, "lol1", Item.ItemType.Weapon));
	}


}
