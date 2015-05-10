using UnityEngine;
using System.Collections;

[System.Serializable]
public class TaskFindWeaponCompleted : MonoBehaviour {

	public TaskManager manager;

	void OnDestroy()
	{
		manager.markAsCompleted("findWeapon");
		string message = "Sieć jest uszkodzona\n" +
			"nie możesz się ze mną \n" +
			"porozumieć, będę cię\n" +
			"obserwował przez\n" +
			"satelitę i kamery\n" +
			"poprowadzę cię do\n" +
			"miasta.\n" +
			"\n" +
			"Ruszaj w drogę!";

		manager.addTask("endOfMission",message);
	}
}
