using UnityEngine;
using System.Collections;

public class lvl4Win : MonoBehaviour {

	public TaskManager manager;
	void OnDestroy()
	{
		manager.markAsCompleted("zabijBossa");
		string message = 
			"udaj się do punktu\n" +
						" zbiórki \n";
		
		manager.addTask("endOfMission",message);

	}
}
