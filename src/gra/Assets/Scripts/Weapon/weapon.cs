using UnityEngine;
using System.Collections;
using System;

public class Weapon : MonoBehaviour {

	public Texture icon;
	public Transform Effect;
	public int TheDammage = 100;
	
	public string drawAnim = "draw";
	public string fireLeftAnim = "fire";
	public string reloadAnim = "reload";
	public GameObject animationGO;
	public AudioClip shotSound;
	public AudioClip clipOutSound;
	public AudioClip clipInSound;
	
	public Vector3 hipPose;
	public Vector3 aimPose;
	public LayerMask layerMask;

	public int ammo = 20;
	public int maxAmmo = 128;
	public int magazineSize = 8;
	
	public int inMagazine;

	protected bool drawWeapon = false;
	protected bool reloading = false;
	protected GameObject mainCamera;
	protected int numberOfMagazines;

	// Use this for initialization
	protected virtual void Start () {
		DrawWeapon();
		transform.localPosition = hipPose;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		addAmmo (ammo);
	}
	
	// Update is called once per frame
	protected virtual void Update () {

		if(Input.GetButton ("Fire2") && reloading == false && drawWeapon == false)
		{
			transform.localPosition = aimPose;
			mainCamera.camera.fieldOfView = 50;
		}else{
			transform.localPosition = hipPose;
			mainCamera.camera.fieldOfView = 60;
		}
		
		if (Input.GetKeyDown ("r") && reloading == false && drawWeapon == false)
		{
			StartCoroutine(Reloading());
		}

	}

	public void addAmmo(int v){
		if (v <= magazineSize) {
			inMagazine = v;
			ammo = 0;

		}else{
			inMagazine = magazineSize;
			ammo = v - inMagazine;
			
			if (ammo > maxAmmo)
				ammo = maxAmmo;
		}
			numberOfMagazines = (int)Math.Ceiling((float)ammo/magazineSize);
	}

	public int getNumberOfMagazines()
	{
		return numberOfMagazines;
	}

	public virtual IEnumerator Fire ()
	{
		inMagazine--;
		if(inMagazine == 0 && ammo != 0)
			StartCoroutine(Reloading());
		yield return new WaitForSeconds (0.0f);
	}
	public virtual IEnumerator DrawWeapon (){yield return new WaitForSeconds(0.0f);}
	public virtual IEnumerator Reloading()
	{
		addAmmo (ammo);
		yield return new WaitForSeconds(0.0f);
	}
}
