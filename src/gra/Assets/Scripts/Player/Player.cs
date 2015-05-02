using UnityEngine;
using System.Collections;

public class Player : MonoBehaviour {
	public int health = 100;
	public int maxHealth = 100;

	public GUITexture bloodScreen;

	public float bloodScreenSpeed;

	public Animator camerAnimator;

	float bloodScreenTime;
	bool isDead;

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

	void Die()
	{
		isDead = true;
		camerAnimator.enabled = true;
	}

	public bool IsDead()
	{
		return isDead;
	}
}
