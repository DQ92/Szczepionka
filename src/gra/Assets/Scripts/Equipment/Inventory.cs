using UnityEngine;
using System.Collections;
using System.Collections.Generic;



public class Inventory : MonoBehaviour {
	public List<Item> inventory = new List<Item>();
	public GUISkin skin;

	public int posX, posY;
	public int boxSizeX,boxSizeY;


	public int slotsX, slotsY;
	//public List<Item> slots = new List<Item>();


	private bool showInventory;
	private bool showToolTip;
	private string tooltip;

	private bool draggingItem;
	private Item draggedItem;
	private int dragIndex;
	private Rect inventoryRect;

	private float showMessage;
	private string message;

	public CharacterController playerControl;

	// Use this for initialization
	void Start () {
		showInventory = false;
		showMessage = Time.time-2;
		for (int i=0; i<(slotsX*slotsY); i++) {
//			slots.Add(new Item());
			inventory.Add(new Item());
		}

		inventoryRect = new Rect (posX,posY,slotsX*boxSizeX,slotsY*boxSizeY);

		AddItem (new Item ("apteczka", 10, "użyta leczy\nSkład: wyciąg z kaloryfera Chuck'a Norris'a, panele podłogowe, majeranek(dla smaku), esencja z odchodów wróżek. Może zaiwerać śladowe ilości zakrętek po wodzie mineralnej.", Item.ItemType.Medic,5));
		AddItem (new Item ("apteczka", 10, "użyta leczy\nSkład: wyciąg z kaloryfera Chuck'a Norris'a, panele podłogowe, majeranek(dla smaku), esencja z odchodów wróżek. Może zaiwerać śladowe ilości zakrętek po wodzie mineralnej.", Item.ItemType.Medic,5));
		AddItem (new Item ("apteczka", 10, "użyta leczy\nSkład: wyciąg z kaloryfera Chuck'a Norris'a, panele podłogowe, majeranek(dla smaku), esencja z odchodów wróżek. Może zaiwerać śladowe ilości zakrętek po wodzie mineralnej.", Item.ItemType.Medic,5));


	}

	void Update(){

		if (Input.GetButtonDown("Inventory")) {
			showInventory=!showInventory;
			if(showInventory){

				GameObject.FindGameObjectWithTag("Player").GetComponent<LockUnlock>().mouseLookLock();
				GameObject.FindGameObjectWithTag("Player").GetComponent<LockUnlock>().weaponLock();
			}else{
				GameObject.FindGameObjectWithTag("Player").GetComponent<LockUnlock>().mouseLookUnlock();
				GameObject.FindGameObjectWithTag("Player").GetComponent<LockUnlock>().weaponUnlock();
			}

		}


	}

	void OnGUI(){

		tooltip = "";
		GUI.skin = skin;
		if(showInventory){
			DrawInventory ();
			if (showToolTip) {
				GUI.Box(new Rect(Event.current.mousePosition.x+10,Event.current.mousePosition.y+10,200,200),tooltip,skin.GetStyle("ToolTip"));
			}
		}
		if(draggingItem){
			GUI.DrawTexture(new Rect(Event.current.mousePosition.x,Event.current.mousePosition.y,50,50),draggedItem.itemIcon);
		}

		if (showMessage>Time.time) {
			GUI.Label(new Rect(400,300,600,200), message);
			//showMessage=!showMessage;
		}

	}



	void DrawInventory(){
		Event e = Event.current;
		int i = 0;
		for (int y=0; y<slotsY; y++) {
			for (int x=0; x<slotsX; x++){
				Rect slotRect= new Rect(posX+x*boxSizeX,posY+y*boxSizeY,boxSizeX,boxSizeY);
				GUI.Box(slotRect, "", skin.GetStyle("Slot"));
				//slots[i]=inventory[i];

				if(inventory[i].itemName!=null){
					//GUI.DrawTexture(slotRect, slots[i].itemIcon);
					GUI.DrawTexture(slotRect, inventory[i].itemIcon);
					if(slotRect.Contains(e.mousePosition)){
						tooltip=CreateToolTip (inventory[i]);
						showToolTip=true;

						if(e.button ==0 && e.type == EventType.mouseDrag && !draggingItem){
							draggingItem=true;
							dragIndex=i;
							draggedItem=inventory[i];
							inventory[i]=new Item();
						}
						if(e.button ==1 && e.type == EventType.mouseDown ){
							if(inventory[i].use()==-1){
								RemoveItem(i);
								message="Przedmiotu użyłeś Ty hawk!";
								showMessage=Time.time+2;
							}else{
								message="Przedmiotu nie użyjesz Ty hawk!";
								showMessage=Time.time+2;
							}
						}
					}
				}
				if(e.type == EventType.mouseUp){
					if(draggingItem){
						if(inventoryRect.Contains(e.mousePosition)){
							if(slotRect.Contains(e.mousePosition)){
								inventory[dragIndex]=inventory[i];
								inventory[i]=draggedItem;
								draggingItem=false;
							}
						}else{
							draggingItem=false;
						}
					}


				}

				if(tooltip==""){
					showToolTip=false;
				}

				i++;
			}
		}
	}

	string CreateToolTip(Item item){
		tooltip = "<color=#4DA4BF>"+item.itemName+"</color>\n\n"+"<color=#f2f2f2>"+item.itemDescription+"</color>";
		return tooltip;
	}

	public void AddItem(Item item){

		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemName==null){
				inventory[i]=item;
				break;
			}
		}
	}

	public bool InventoryContains(string itemName){
		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemName==itemName){
				return true;
			}
		}
		return false;
	}

	public int CountItem(string itemName){
		int sum = 0;
		for (int i=0; i<inventory.Count; i++) {
			if(inventory[i].itemName==itemName){
				sum++;
			}
		}
		return sum;
	}


	void RemoveItem(string name){
		for (int i =0; i<inventory.Count; i++) {
			if(inventory[i].itemName==name){
				inventory[i]=new Item();
				break;
			}
		}
	}

	void RemoveItem(int index){
		if (inventory [index].itemName != "") {
			inventory[index]=new Item();
		}

	}




}














