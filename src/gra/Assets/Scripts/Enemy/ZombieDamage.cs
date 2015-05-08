using UnityEngine;
using System.Collections;

public class ZombieDamage : MonoBehaviour {
	public float damageFactor;
	public ZombieLogic zombie;

	void Awake()
	{
		//zombie = transform.root.GetComponentInChildren<ZombieLogic>() as ZombieLogic;
	}

	void ApplayDamage(int damage)
	{
		if (zombie.health <= 0)
			return;
		
		zombie.health -= (int)((float)damage*damageFactor);
	}
}
