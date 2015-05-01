using UnityEngine;
using System.Collections;

public class Gun : MonoBehaviour {
	public WeaponManager weaponManager;
	
	public Texture underline;
	public Texture unusedBullet;
	public Texture usedBullet;

	public Rect weaponIconGeo; // pozycja liczona od prawego dolnego rogu np (10x10x64x32) to obrazek 10 px od dołu 10 px od prawej o rozmiarze 64 na 32
	public Rect underlineGeo; // jw
	public Rect bulletBarGeo; //jw
	public Rect textGeo; //jw
	public GUIStyle fontStyle;

	Rect weaponIconFixed; // przeliczona pozycja
	Rect underlineFixed; // jw
	Rect bulletBarFixed; // jw
	Rect textFixed; //jw

	Rect groupRect; 


	// Use this for initialization
	void Start () {
		fixPosition();
	}
	
	void OnGUI()
	{
		Weapon weapon = weaponManager.getSelectedWeapon(); 
		if(!weapon)
			return;

		GUI.DrawTexture( weaponIconFixed, weapon.icon,ScaleMode.ScaleToFit,true,0 );
		GUI.DrawTexture( underlineFixed, underline,ScaleMode.ScaleToFit,true,0 );

		int used = weapon.magazineSize - weapon.inMagazine;

		int width = (weapon.magazineSize * 6);
		bulletBarFixed.x = Screen.width - bulletBarGeo.x - width;


		groupRect.x = bulletBarFixed.x;
		groupRect.width = width;

		GUI.BeginGroup(groupRect);
		GUI.DrawTexture( new Rect(0,0,bulletBarFixed.width,bulletBarFixed.height), usedBullet,ScaleMode.ScaleToFit,true,0 );
		GUI.EndGroup();

		groupRect.x = bulletBarFixed.x +(used*6)+2;
		groupRect.width = width - (used*6)-2;

		GUI.BeginGroup(groupRect);
			GUI.DrawTexture( new Rect(0,0,bulletBarFixed.width,bulletBarFixed.height), unusedBullet,ScaleMode.ScaleToFit,true,0 );
		GUI.EndGroup();

		GUI.Label(textFixed,weapon.getNumberOfMagazines().ToString(),fontStyle);
	}

	void Update()
	{

	}

	void fixPosition()
	{
		weaponIconFixed = weaponIconGeo;
		weaponIconFixed.x = Screen.width - weaponIconGeo.x - weaponIconGeo.width;
		weaponIconFixed.y = Screen.height - weaponIconGeo.y;
		
		underlineFixed = underlineGeo;
		underlineFixed.x = Screen.width - underlineFixed.x - underlineFixed.width;
		underlineFixed.y = Screen.height - underlineGeo.y;

		bulletBarFixed = bulletBarGeo;
		bulletBarFixed.x = Screen.width - bulletBarFixed.x - bulletBarFixed.width;
		bulletBarFixed.y = Screen.height - bulletBarFixed.y;
		
		textFixed = textGeo;
		textFixed.x = Screen.width - textFixed.x - textFixed.width;
		textFixed.y = Screen.height - textFixed.y;

		groupRect = new Rect( bulletBarFixed.x, bulletBarFixed.y, bulletBarFixed.width, bulletBarFixed.height );
	}
}
