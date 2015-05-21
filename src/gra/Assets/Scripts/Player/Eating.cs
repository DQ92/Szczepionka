using UnityEngine;
using System.Collections;

public class Eating : MonoBehaviour {

	public Player player;
	private float time = 0.0f;
	private bool triggered = false;

	private float timeMax = 30.0f;
	private int addHealth = 25;
	private int demageHealth = 5;


	// Update is called once per frame
	void Update () {
		time += Time.deltaTime;

		if ( time >= timeMax ) {
			//print ("Czas coś zjeść " + time);
			time = 0;
			triggered = true;
			player.ApplayDamage(demageHealth);
		}

	}

	public void resetTimer(){
		triggered = false;
		time = 0.0f;
		player.addHealth (addHealth);
		print ("RESET timer");

	}

	void OnGUI()
	{
		if (triggered)
		{
			//GUI.Label(new Rect(650,500,500,200), "Zjedz coś ");
		}
	}

}
