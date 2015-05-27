using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour {
	public GUITexture background;
	public GUIStyle titleStyle;
	public GUIStyle buttonStyle;
	
	int buttonWidth = 200;
	int buttonHeight = 30;

	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		
	}
	
	void OnGUI()
	{
		background.pixelInset = new Rect(-Screen.width/2,-Screen.height/2,Screen.width,Screen.height);

		GUI.Label(new Rect(50,50,Screen.width,70),"Szczepionka",titleStyle);

		int xPos = 150;
		if (GUI.Button(new Rect(Screen.width - buttonWidth - xPos ,
		                        Screen.height - buttonHeight - 250, buttonWidth, buttonHeight),
		               			"Nowa Gra",buttonStyle))
		{
			Application.LoadLevel("Level1");
		}

		if (GUI.Button(new Rect(Screen.width - buttonWidth - xPos ,
		                        Screen.height - buttonHeight - 200, buttonWidth, buttonHeight),
		               "Wznów",buttonStyle))
		{

		}

		if (GUI.Button(new Rect(Screen.width - buttonWidth - xPos ,
		                        Screen.height - buttonHeight - 150, buttonWidth, buttonHeight),
		               "Wyjdź",buttonStyle))
		{
			Application.Quit();
		}
	}
}
