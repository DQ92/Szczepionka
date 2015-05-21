using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : MonoBehaviour {
	public int health = 100;
	public int maxHealth = 100;

	public GUITexture bloodScreen;
	public GUISkin skin;

	public float bloodScreenSpeed;

	public Animator camerAnimator;

	public LockUnlock lockUnlock;

	[Header("Falling Damege:")]

	public float damegeHeight = 2;
	public float damageFactor = 6;

	float bloodScreenTime;
	bool isDead;
	bool showMenu;
	bool falling;
	Vector3 startFallingPosition;

	// Use this for initialization
	void Start () {
		bloodScreenTime = Time.time;
		isDead = false;
	}

	public void onLadder()
	{
		falling = false;
	}

	// Update is called once per frame
	void Update () 
	{

		if(Input.GetKeyDown(KeyCode.Escape))
		{
			showMenu = !showMenu;
			if(showMenu)
			{
				lockUnlock.mouseLookLock();
				lockUnlock.weaponLock();
			}
			else
			{
				lockUnlock.mouseLookUnlock();
				lockUnlock.weaponUnlock();
			}

		}

		if(bloodScreen.gameObject.activeSelf)
		{
			if (Time.time >= bloodScreenTime && !isDead) {
				bloodScreenTime = Time.time + bloodScreenSpeed;

				Color t = bloodScreen.color;
				t.a -= 0.01f;

				if(t.a <= 0f)
					bloodScreen.gameObject.SetActive(false);
				else
					bloodScreen.color = t;
			}
		}
		
	}

	public bool addHealth(int value)
	{
		if(health < maxHealth){
			health +=value;
			if(health>maxHealth)
				health = maxHealth;
			return true;
		}
		return false;
	}
	public void ApplayDamage(int damage){

		health -= damage;
		if(health<0){
			health = 0;
			Die ();
		}

		bloodScreen.gameObject.SetActive(true);
		bloodScreen.pixelInset = new Rect(-Screen.width/2,-Screen.height/2,Screen.width,Screen.height);


		Color t = bloodScreen.color;
		t.a += (float)damage/maxHealth;
		bloodScreen.color = t;
		//bloodScreen.color = new Color(bloodScreen.color,10);

	}

	void OnGUI()
	{
		if(!showMenu && !isDead)
			return;
		GUI.skin = skin;

		float x = (Screen.width/2) - 100;
		float y = (Screen.height/2) - 15;

		if (GUI.Button(new Rect(x, y-20, 200, 30),"RESTART"))
		{
			Application.LoadLevel(Application.loadedLevel);
		}

		if (GUI.Button(new Rect(x, y+20, 200, 30),"MENU"))
		{
			Application.LoadLevel("MainMenu");
		}

		//GUI.Label(new Rect(300,300,500,200), "Kliknij aby spróbować jeszcze raz");
	}

	void Die()
	{
		isDead = true;
		showMenu = true;
		lockUnlock.movementLock();
		lockUnlock.mouseLookLock();
		lockUnlock.weaponLock();
		camerAnimator.enabled = true;
	}

	public bool IsDead()
	{
		return isDead;
	}

	void OnFall()
	{
		falling = true;
		startFallingPosition = transform.position;
	}

	void OnJump()
	{
		falling = true;
		startFallingPosition = transform.position;
	}

	void OnLand()
	{
		if(!falling)
			return;

		float height = startFallingPosition.y-transform.position.y;
		if( height > damegeHeight)
			ApplayDamage((int)(height*damageFactor));
		falling = false;
	}


}
