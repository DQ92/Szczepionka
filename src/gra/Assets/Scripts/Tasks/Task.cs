using UnityEngine;
using System.Collections;

[System.Serializable]
public class Task  {
	private string name;

	bool completed = false;
	string description;

	public Task(string name,string description)
	{
		this.description = description;
		this.name = name;
	}

	public void markAsCompleted(){
		completed = true;
	}

	public bool isCompleted()
	{
		return completed;
	}

	public string getDescription()
	{
		return description;
	}

	public string getName()
	{
		return name;
	}
}
