using UnityEngine;
using System.Collections.Generic;

public class NextMission : MonoBehaviour {
	public TaskManager taskManager;
	public string message;
	public string nexLevelName;

	bool triggered = false;
	int numberOfUncompletedTasks;

	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;

			List<Task> uncompleted = taskManager.uncompletedTasks();

			if(uncompleted.Count == 1 ){
				if(uncompleted[0].getName() == "endOfMission")
					taskManager.markAsCompleted("endOfMission");

			}
			uncompleted = taskManager.uncompletedTasks();
			numberOfUncompletedTasks = uncompleted.Count;
		}
	}
	
	void OnTriggerExit( Collider other)
	{
		if (other.gameObject.tag == "Player"){
			triggered = false;
		}
	}
	
	void OnGUI()
	{
		if (triggered)
		{
			
			if(numberOfUncompletedTasks > 0)
			{
				GUI.Label(new Rect(300,300,500,200), "Masz "+numberOfUncompletedTasks+" nieukończonych zadań");
			}
			else
				GUI.Label(new Rect(300,300,500,200), message);
		}
	}

	void Update()
	{
		if(!triggered || numberOfUncompletedTasks > 0)
			return;

		if(Input.GetKeyDown("e"))
		{
			Application.LoadLevel(nexLevelName);
		}

	}
}
