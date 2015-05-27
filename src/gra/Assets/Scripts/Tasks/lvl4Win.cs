using UnityEngine;
using System.Collections;

public class lvl4Win : MonoBehaviour {

	public TaskManager manager;
	void OnDestroy()
	{
		manager.markAsCompleted("zabijBossa");
		string message = 
						"Udało Ci się!!\n\n\n" +
						"Teraz odszukaj palmę,\n" +
						"tam wykop grób i spocznij\n" +
						"Twa misja dobiegła końca żołnierzu.";

		
		manager.addTask("endOfMission",message);

	}
}
