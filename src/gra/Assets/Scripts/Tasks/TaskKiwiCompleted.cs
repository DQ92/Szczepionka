using UnityEngine;
using System.Collections;

public class TaskKiwiCompleted : MonoBehaviour {

	int count = 0;
	public TaskManager taskManager;

	public void add(){
		count++;
		print ("Po dodaniu: " + count);
	}

	void Update(){
		if(count>=3){
			taskManager.markAsCompleted("kiwiTask");
		}
		if ( Input.GetKey(KeyCode.LeftControl) ) {

			if (Input.GetKeyDown ("k")){
				count = 3;
				print ("Już masz 3 kiwi!");
			}
		}
	}

}
