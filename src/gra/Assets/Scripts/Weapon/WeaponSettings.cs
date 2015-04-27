using UnityEngine;
using System.Collections;

public class WeaponSettings : MonoBehaviour {
	public int ammo = 20;
	public int maxAmmo = 128;
	public int magazineSize = 8;

	protected int inMagazine;

	// Use this for initialization
	void Start () {
		addAmmo (ammo);
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void addAmmo(int v){
		if (v <= magazineSize) {
			inMagazine = v;
			return;
		}

		inMagazine = magazineSize;

		ammo = v - inMagazine;

		if (ammo > maxAmmo)
			ammo = maxAmmo;

	}
}
