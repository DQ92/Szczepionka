using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class TaskManager: MonoBehaviour {
	public TextMesh messageText;

	List<Task> tasks = new List<Task>(); // lista smsów

	public bool isEnabled = false;

	public Transform weapons; // Menadżer broni
	private int activeWeaponIndex = -1; // index aktywnej broni
	private int currentTaskIndex = 0;

	// Use this for initialization
	void Start () {
		tasks.Add (new Task("findWeapon","Witam, jeśli czytasz \n" +
			"tą wiadomość to masz \n" +
		    "pecha zostałeś wybrany \n" +
		    "przez los do uratowania\n" +
		    "świata.\n" +
		    "\n" +
			"Znajdź broń m9"));
		selectTask (0);
		toggleVisiblity();
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown ("t")) 
		{
			toggleVisiblity();
		}
		else
		if (Input.GetAxis ("Mouse ScrollWheel") < 0) {
			if (++currentTaskIndex >= tasks.Count)
				currentTaskIndex = tasks.Count-1;
			selectTask (currentTaskIndex);
		} else if (Input.GetAxis ("Mouse ScrollWheel") > 0) 
		{
			if (--currentTaskIndex < 0)
				currentTaskIndex = 0;
			selectTask (currentTaskIndex);
		}
	}

	void toggleVisiblity()
	{
		if (isEnabled){
			isEnabled = false;
			showWeapons();
		}
		else{
			isEnabled = true;
			hideWeapons();
		}

		for (int i=0; i<transform.childCount; i++) 
			transform.GetChild(i).gameObject.SetActive(isEnabled);
	}

	void hideWeapons()
	{
		activeWeaponIndex = -1;// brak broni
		for(int i=0; i<weapons.childCount; i++)
		{
			GameObject o = weapons.GetChild(i).gameObject;

			if(o.activeSelf)
				activeWeaponIndex = i;

			o.SetActive(false);
		}

		weapons.gameObject.SetActive(false);
	}

	void showWeapons()
	{
		weapons.gameObject.SetActive(true);
		if(activeWeaponIndex != -1)
			weapons.GetChild(activeWeaponIndex).gameObject.SetActive(true);
	}


	public void addTask(string name,string task)
	{
		tasks.Add (new Task(name,task));
		selectTask (tasks.Count-1);
	}

	void selectTask(int taskIndex)
	{
		if(taskIndex < 0 || taskIndex >=tasks.Count)
			return;

		if(!messageText)
			return;

		Task t = tasks[taskIndex];
		messageText.text = t.getDescription();

		if(t.isCompleted())
			messageText.color = new Color(0,200,0);
		else
			messageText.color = new Color(255,255,255);
	}

	public void markAsCompleted(string taskName)
	{
		foreach(Task s in tasks){
			if(s.getName() == taskName)
				s.markAsCompleted();
		}
	}
}
