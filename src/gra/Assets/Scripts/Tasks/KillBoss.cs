using UnityEngine;
using System.Collections;

[System.Serializable]
public class KillBoss: MonoBehaviour {

	public TaskManager manager;



	void Start () {

		string message = 
						"Zabij Zoombie Matkę,\n" +
						"jest to źródło zarazy\n" +
						"śmierć tej kreatury\n" +
						"powstrzyma ekspansję \n" +
						"zoombie\n" +
						"\n" +
						"Powodzenia żołnierzu!";
		manager.addTask("zabijBossa",message);
	}
}
