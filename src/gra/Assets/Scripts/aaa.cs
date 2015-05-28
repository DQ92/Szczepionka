using UnityEngine;
using System.Collections;

public class aaa : MonoBehaviour {
	public Player player;
	void OnTriggerEnter()
	{
		player.ApplayDamage (2000000);
	}
}
