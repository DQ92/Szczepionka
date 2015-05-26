using UnityEngine;
using System.Collections;
using System;

public class gun : MonoBehaviour {

	public Texture icon;
	public String gunName;
	public Transform Effect;
	public Transform blood;
	public Transform muzzle;
	public Transform muzzlePosition;

	public int TheDammage = 100;
	
	public string drawAnim = "draw";
	public string fireLeftAnim = "fire";
	public string reloadAnim = "reload";
	public GameObject animationGO;

	public AudioClip shot;
	public AudioClip reload;
	
	public Vector3 hipPose;
	public Vector3 aimPose;
	public LayerMask layerMask;
	
	public int ammo = 20;
	public int maxAmmo = 128;
	public int magazineSize = 8;
	
	public int inMagazine;

	public bool automatic = false;
	public float shotDelay = 0;
	public float reloadTime = 1;

	protected bool drawWeapon = false;
	protected bool reloading = false;
	protected GameObject mainCamera;
	protected int numberOfMagazines;
	protected WeaponManager weaponManager;
	protected bool canShoot = true;

	// Use this for initialization
	protected void Start () {

		DrawWeapon();
		transform.localPosition = hipPose;
		mainCamera = GameObject.FindGameObjectWithTag("MainCamera");
		addAmmo (ammo);
		weaponManager = gameObject.GetComponentInParent<WeaponManager>();
	}

	void OnEnable()
	{
		if(reloading)
			StartCoroutine(Reloading());
	}
	
	// Update is called once per frame
	protected void Update () 
	{
		if (ammo == 0 && inMagazine==0 || !weaponManager.weaponIsActivated)
			return;

		if(!automatic)
		{
			if(Input.GetButtonDown ("Fire1") && reloading == false && drawWeapon == false)
			{
				StartCoroutine(Fire());
			}
		}
		else
		if(canShoot && Input.GetButton ("Fire1") && reloading == false && drawWeapon == false)
		{
			StartCoroutine(Fire());
		}

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
	
	public bool addAmmo(int v){
		if(ammo == maxAmmo)
			return false;

		if (v <= magazineSize) {
			inMagazine = v;
			ammo = 0;
			
		}else{
			inMagazine = magazineSize;
			ammo += v - inMagazine;
			
			if (ammo > maxAmmo)
				ammo = maxAmmo;
		}
		numberOfMagazines = (int)Math.Ceiling((float)ammo/magazineSize);
		return true;
	}
	
	public int getNumberOfMagazines()
	{
		return numberOfMagazines;
	}
	
	public IEnumerator Fire ()
	{
		if (!canShoot)
			yield return new WaitForSeconds(0.0f);
		
		canShoot = false;
		animationGO.animation.CrossFadeQueued(fireLeftAnim, 0.08f, QueueMode.PlayNow);
		audio.PlayOneShot(shot);

		//Vector3 middleScreen = new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0);



		RaycastHit hit;
		Ray ray  = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));

		Instantiate(muzzle, muzzlePosition.position, Quaternion.LookRotation(ray.direction.normalized));

		if (Physics.Raycast (ray, out hit, 100,layerMask))
		{
			if(hit.transform.tag == "Enemy")
				Instantiate(blood, hit.point, Quaternion.LookRotation(hit.normal));
			else
				Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
			
			if (hit.rigidbody)
				hit.rigidbody.AddForceAtPosition(400 * ray.direction , hit.point);
			hit.transform.SendMessage("ApplayDamage",TheDammage,SendMessageOptions.DontRequireReceiver);
		}

		inMagazine--;
		if(inMagazine == 0 && ammo != 0)
			StartCoroutine(Reloading());

		yield return new WaitForSeconds(shotDelay);
		canShoot = true;

	}

	public IEnumerator DrawWeapon ()
	{
		if(drawWeapon)
			yield return new WaitForSeconds(0.0f);
		
		//animationGO.animation.Play(drawAnim);
		drawWeapon = true;
		yield return new WaitForSeconds(0.6f);
		drawWeapon = false;
	}

	public IEnumerator Reloading()
	{
		if(reloading)
			yield return new WaitForSeconds(0.0f);
		
		animationGO.animation.Play(reloadAnim);
		reloading = true;
		yield return new WaitForSeconds(0.15f);
		audio.PlayOneShot(reload);
		yield return new WaitForSeconds(reloadTime);

		addAmmo (ammo);
		yield return new WaitForSeconds(0.0f);
		reloading = false;
	}
}
