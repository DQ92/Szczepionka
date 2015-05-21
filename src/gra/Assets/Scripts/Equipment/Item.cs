using UnityEngine;
using System.Collections;


[System.Serializable]
public class Item  {
	public string itemName;
	public int itemPower;
	public string itemDescription;
	public Texture2D itemIcon;

	public ItemType itemType;

	private WeaponManager weaponManager;


	public enum ItemType {
		Weapon,
		VaccinePart,
		M9Ammo,
		M4Ammo,
		Medic
	}

	public Item(string name, int ID, string description, ItemType type,int power,WeaponManager weaponManager=null){
		itemName = name;
		itemPower = power;
		itemIcon = Resources.Load<Texture2D> ("Item Icons/"+ name);
		itemDescription = description;
		itemType = type;
		this.weaponManager = weaponManager;
	}
	public Item(){

	}

	public int use(){
		if (itemType == ItemType.Medic) {
			//weaponManager.addAmmo("M9",50);

			return 1;
		}
		if (itemType == ItemType.M9Ammo) {
			weaponManager.addAmmo("M9",50);
			return -1;
		}
		return 0;
	}


}
