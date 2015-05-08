using UnityEngine;
using System.Collections;

public class Door : MonoBehaviour {
	public Transform door;
	public string closeAnimation;
	public string openAnimation;

	bool triggered = false;
	bool isOpen=false;

	void OnTriggerEnter( Collider other) {
		if (other.gameObject.tag == "Player") {
			triggered = true;
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
			if(!isOpen)
				GUI.Label(new Rect(300,300,500,200), "Wciśnij E aby otworzyć ");
			else
				GUI.Label(new Rect(300,300,500,200), "Wciśnij E aby zamknąć ");
		}
	}

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
		if(triggered && Input.GetKeyDown("e"))
		{
			if(!isOpen)
				Open();
			else
				Close();
		}
	}

	void Open()
	{
		isOpen = true;
		door.parent.gameObject.animation.Play(openAnimation);
	}

	void Close()
	{
		isOpen = false;
		door.parent.gameObject.animation.Play(closeAnimation);
	}
}
