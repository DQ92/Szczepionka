using UnityEngine;
using System.Collections;

[System.Serializable]
public class Player : MonoBehaviour {
	public int health = 100;
	public int maxHealth = 100;

	public GUITexture bloodScreen;

	public float bloodScreenSpeed;

	public Animator camerAnimator;

	public LockUnlock lockUnlock;

	[Header("Falling Damege:")]

	public float damegeHeight = 2;
	public float damageFactor = 6;

	float bloodScreenTime;
	bool isDead;
	bool falling;
	Vector3 startFallingPosition;

	// Use this for initialization
	void Start () {
		bloodScreenTime = Time.time;
		isDead = false;
	}
	
	// Update is called once per frame
	void Update () {
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

		if(isDead)
		{
			if(Input.GetButtonDown ("Fire1"))
			   Application.LoadLevel(Application.loadedLevel);
		}
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
		if(!isDead)
			return;

		GUI.Label(new Rect(300,300,500,200), "Kliknij aby spróbować jeszcze raz");
	}

	void Die()
	{
		isDead = true;
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
