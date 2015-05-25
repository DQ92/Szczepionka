using UnityEngine;
using System.Collections;

public class runAway : MonoBehaviour {
	public TaskManager manager;

	// Use this for initialization
	void Start () {
		string message = "" +
			"Znajdź drogę do \n" +
			"wyjścia, nie oglądaj się\n" +
			"i nie daj się zabić,\n" +
			"Powodzenia";
		manager.addTask("endOfMission",message);
	}

}
