using UnityEngine;
using System.Collections;

public class HealthBar : MonoBehaviour {
	public Player playerStats;
	public Texture healthLevel;
	public Texture healthIcon;
	public Texture background;

	public Rect healthLevelGeo;
	public Rect healthIconGeo;
	public Rect backgroundGeo;

	Rect groupRect; 
	Rect healthIconFixed;
	Rect backgroundFixed;

	void Start()
	{
		fixPosition();
	}

	void OnGUI()
	{
		groupRect.width = (int)healthLevelGeo.width*((float)playerStats.health/(float)playerStats.maxHealth);

		GUI.DrawTexture(healthIconFixed,healthIcon,ScaleMode.ScaleToFit,true,0);
		GUI.DrawTexture(backgroundFixed,background,ScaleMode.ScaleToFit,true,0);

		GUI.BeginGroup(groupRect);
		GUI.DrawTexture( new Rect(0,0, healthLevelGeo.width, healthLevelGeo.height), healthLevel,ScaleMode.ScaleToFit,true,0 );
		GUI.EndGroup();
	}

	void fixPosition()
	{
		groupRect = healthLevelGeo;
		groupRect.y = Screen.height -healthLevelGeo.y - healthLevelGeo.height;

		healthIconFixed = healthIconGeo;
		healthIconFixed.y = Screen.height -healthIconGeo.y - healthIconGeo.height;

		backgroundFixed = backgroundGeo;
		backgroundFixed.y = Screen.height -backgroundGeo.y - backgroundGeo.height;
	}
}
