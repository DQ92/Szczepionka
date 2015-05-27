using UnityEngine;
using System.Collections;

public class ZombieBossDamange : MonoBehaviour {

	public float damageFactor;
	public ZoombieBoss zombie;
	
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
