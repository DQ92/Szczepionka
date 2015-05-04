using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class WeaponManager : MonoBehaviour {
	public int currentWeapon = 0;
	public int maxWeapon = 0;

	Weapon selectedWeapon;

	public bool weaponisActivated()
	{
		if(!selectedWeapon)
			return false;
		return selectedWeapon.gameObject.activeSelf;
	}

	public Weapon getSelectedWeapon(){
		if(weaponisActivated())
			return selectedWeapon;
		return null;
	}

	// Use this for initialization
	void Start () {

		SelectWeapon (currentWeapon);
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetAxis ("Mouse ScrollWheel") > 0) {
			if (++currentWeapon > maxWeapon)
				currentWeapon = 0;
			SelectWeapon (currentWeapon);
		} else if (Input.GetAxis ("Mouse ScrollWheel") < 0) 
		{
			if (--currentWeapon < 0)
				currentWeapon = maxWeapon;
			SelectWeapon (currentWeapon);
		}
	}

	void SelectWeapon(int index)
	{	
		for(int i=0; i<transform.childCount; i++)
		{
			if(i==index){
				transform.GetChild(i).gameObject.SetActive(true);
				selectedWeapon = transform.GetChild(i).GetComponent<Weapon>();
			}
			else
				transform.GetChild(i).gameObject.SetActive(false);
		}
	}

	public void AddWeapon(string prefab,Vector3 rotation){
		//GameObject go = Instantiate(weapon, new Vector3 (0,0,0), Quaternion.identity) as GameObject;
		GameObject weapon = Instantiate(Resources.Load(prefab)) as GameObject;
		weapon.transform.parent = transform;
		weapon.transform.localEulerAngles = rotation;
		weapon.SetActive(false);

		maxWeapon = transform.childCount-1;
		if(maxWeapon == 0)
			SelectWeapon (0);
	}
}
