using UnityEngine;
using System.Collections;

public class Eating : MonoBehaviour {

	public Player player;
	private float time = 0.0f;

	private float timeMax = 10.0f;
	
	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if ( time >= timeMax ) {
			print ("Czas coś zjeść" + time);
			time = 0;
			player.ApplayDamage(2);

		}else {
			print ("!");
		}
	}

	public void resetTimer(){
		time = 0.0f;
	}

}
