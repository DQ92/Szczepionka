using UnityEngine;
using System.Collections;

[System.Serializable]
public class KillBoss: MonoBehaviour {

	public TaskManager manager;



	void Start () {

		string message = "Zabij Bossa\n" +
			"\n" +
				"Powodzenia leszczu!";
		manager.addTask("zabijBossa",message);
	}
}
