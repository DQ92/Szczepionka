using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	public GUISkin skin;

	public int slotsX, slotsY;
	public List<Item> slots = new List<Item>();
	private ItemDatabase database;

	private bool showInventory;

	// Use this for initialization
	void Start () {
		showInventory = false;

		for (int i=0; i<(slotsX*slotsY); i++) {
			slots.Add(new Item());
			inventory.Add(new Item());
		}

//		database = GameObject.FindGameObjectWithTag("ItemDatabase").GetComponent<ItemDatabase>();

		AddItem (new Item ("1", 0, "lorem ipsum", Item.ItemType.Weapon));
		AddItem (new Item ("1", 0, "lorem ipsum", Item.ItemType.Weapon));
		AddItem (new Item ("2", 0, "lorem ipsum", Item.ItemType.Weapon));
		print(InventoryContains ("2"));
	}

	void Update(){

		if (Input.GetButtonDown("Inventory")) {
			showInventory=!showInventory;

		}


	}

	void OnGUI(){
		GUI.skin = skin;
		if(showInventory){
			DrawInventory ();
		}
	}



	void DrawInventory(){
		int i = 0;
		for (int y=0; y<slotsY; y++) {
			for (int x=0; x<slotsX; x++){
				Rect slotRect= new Rect(x*32,y*32,32,32);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
				slots[i]=inventory[i];

				if(slots[i].itemName!=null){
					GUI.DrawTexture(slotRect, slots[i].itemIcon);
				}
				i++;
			}
		}
	}

	public void AddItem(Item item){

		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemName==null){
				inventory[i]=item;
				break;
			}
		}
	}

	bool InventoryContains(string itemName){
		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemName==itemName){
				return true;
			}
		}
		return false;
	}


}














