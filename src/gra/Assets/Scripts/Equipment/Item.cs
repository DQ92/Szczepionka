using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item  : MonoBehaviour{
	public string itemName;
	public int itemPower;
	public string itemDescription;
	public Texture2D itemIcon;

	public ItemType itemType;



	public enum ItemType {
		Weapon,
		VaccinePart,
		M9Ammo,
		M4Ammo,
		Ammo,
		Medic
	}

	public Item(string name, int ID, string description, ItemType type,int power){
		itemName = name;
		itemPower = power;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/"+ name);
		itemDescription = description;
		itemType = type;

	}
	public Item(){

	}

	public int use(){
		if (itemType == ItemType.Medic) {

			return 1;
		}
		return 0;
	}


}
