using UnityEngine;
using System.Collections;

[System.Serializable]
public class ColtM9 : Weapon {

	protected override void Start ()
	{
		base.Start ();
	}
	
	protected override void Update ()
	{
		if (ammo == 0 && inMagazine==0)
			return;

		if(Input.GetButtonDown ("Fire1") && reloading == false && drawWeapon == false)
		{
			StartCoroutine(Fire());
		}
		base.Update ();
	}
	
	public override IEnumerator Fire ()
	{
		animationGO.animation.CrossFadeQueued(fireLeftAnim, 0.08f, QueueMode.PlayNow);
		audio.PlayOneShot(shotSound);
		
		RaycastHit hit;
		Ray ray  = Camera.main.ScreenPointToRay(new Vector3(Screen.width*0.5f, Screen.height*0.5f, 0));
		
		if (Physics.Raycast (ray, out hit, 100,layerMask))
		{
			Instantiate(Effect, hit.point, Quaternion.LookRotation(hit.normal));
			if (hit.rigidbody)
				hit.rigidbody.AddForceAtPosition(200 * ray.direction , hit.point);
			hit.transform.SendMessage("ApplayDamage",TheDammage,SendMessageOptions.DontRequireReceiver);
		}
		StartCoroutine( base.Fire ());
		yield return new WaitForSeconds(0.0f);
	}
	
	public override IEnumerator DrawWeapon ()
	{
		if(drawWeapon)
			yield return new WaitForSeconds(0.0f);
		
		animationGO.animation.Play(drawAnim);
		drawWeapon = true;
		yield return new WaitForSeconds(0.6f);
		drawWeapon = false;
	}
	
	public override IEnumerator Reloading ()
	{
		//ran out ammo or already reloading
		if(reloading)
			yield return new WaitForSeconds(0.0f);
		
		animationGO.animation.Play(reloadAnim);
		reloading = true;

		yield return new WaitForSeconds(0.2f);
		audio.PlayOneShot(clipOutSound);
		yield return new WaitForSeconds(1.1f);
		audio.PlayOneShot(clipInSound);
		yield return new WaitForSeconds(1.5f);
		StartCoroutine(base.Reloading ());
		reloading = false;
	}
}