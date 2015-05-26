using UnityEngine;
using System.Collections;

public class TaskLvl1 : MonoBehaviour {

	public TaskManager manager;
	
	// Use this for initialization
	void Start () {
		string message = "Twoim zadaniem teraz\n"+
			"będzie odnalezienie \n"+
				"3 owoców kiwi, \n"+
				"jak je już znajdziesz \n"+
				"to przejdź przez most \n"+
				"i znajdź broń. \n"+
				"Potem idź do łódki. \n"+
				"\n\n"+
				"Powodzenia!\n";
		manager.addTask("kiwiTask",message);
	}
}
