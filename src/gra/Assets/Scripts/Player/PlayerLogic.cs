using UnityEngine;
using System.Collections;

public class PlayerLogic : MonoBehaviour {
	public int health = 100;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	void ApplayDamage(int damage){
		health -= damage;
	}
}
