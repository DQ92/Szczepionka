using UnityEngine;
using System.Collections;

public class startWeapons : MonoBehaviour {
	public bool m9;
	public bool m4;

	protected WeaponManager manager;

	// Use this for initialization
	void Start () {
		GameObject o = GameObject.Find ("/Player/Main Camera/Weapon");
		manager = o.gameObject.GetComponent<WeaponManager> ();

		if(m9)
			manager.AddWeapon("weapon/m9_fp",new Vector3(0.001286317F,268.4575F,0.9307921F));
		if(m4)
			manager.AddWeapon("weapon/m4_fp",new Vector3(0F,270F,0F));
	}
}
