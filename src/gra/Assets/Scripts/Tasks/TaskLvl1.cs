using UnityEngine;
using System.Collections;

public class TaskLvl1 : MonoBehaviour {

	public TaskManager manager;
	
	// Use this for initialization
	void Start () {
		string message= "Twoim zadaniem będzie\n"+
						"odnalezienie 3 owoców\n"+
						"kiwi. Musisz je jeść, by\n"+
						"mieć energię. \n\n"+
						"Celem jest dotarcie \n"+
						"do łodzi, ale pamiętaj,\n"+
						"że będziesz potrzebował\n"+
						"broń. Znajdziesz ją\n"+
						"w opuszczonym domku,\n"+
						"do którego wiedzie\n"+
						"droga tylko przez wiszący\n" +
						"most...\n\n"+
						"Powodzenia!\n";
		manager.addTask("kiwiTask",message);
	}
}
