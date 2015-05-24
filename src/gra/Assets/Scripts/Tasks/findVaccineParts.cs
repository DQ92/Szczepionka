using UnityEngine;
using System.Collections;

public class FindVaccineParts : MonoBehaviour {


	public TaskManager manager;
	
	// Use this for initialization
	void Start () {
		string message = "Twoim zadaniem teraz\n"+
			"będzie odnalezienie \n"+
				"składników szczepionki, \n"+
				"jak je już znajdziesz \n"+
				"to skontaktuje się \n"+
				"z Tobą i wyjaśnię jak \n"+
				"dostać się do mojego \n"+
				"laboratorium.\n\n"+
				"Powodzenia!\n";
		manager.addTask("findVaccineParts",message);
	}
}
