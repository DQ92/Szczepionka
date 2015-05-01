using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health = 100;
	public int maxHealth = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	public void ApplayDamage(int damage){

		health -= damage;
		if(health<0)
			health = 0;
	}
}
