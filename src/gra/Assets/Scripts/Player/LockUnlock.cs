using UnityEngine;
using System.Collections;

public class LockUnlock : MonoBehaviour {
	public CharacterMotor controller;
	public MouseLook mouseLookX;
	public MouseLook mouseLookY;
	public Transform weapon;

	public void movementLock()
	{
		controller.enabled = false;
	}

	public void mouseLookLock()
	{
		mouseLookX.enabled = false;
		mouseLookY.enabled = false;
	}

	public void weaponLock()
	{
		weapon.gameObject.SetActive(false);
	}

	public void movementUnlock()
	{
		controller.enabled = true;
	}
	
	public void mouseLookUnlock()
	{
		mouseLookX.enabled = true;
		mouseLookY.enabled = true;
	}

	public void weaponUnlock()
	{
		weapon.gameObject.SetActive(true);
	}
}
