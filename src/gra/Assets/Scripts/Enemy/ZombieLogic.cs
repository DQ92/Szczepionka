using UnityEngine;
using System.Collections;

public class ZombieLogic : MonoBehaviour {
	public int health = 100;
	public Transform target; // cel zombiaka
	public float attackRange; // zakres ataku
	public float chaseRange; // przy mniejszej odległości zaczyna gonić :p
	public float speedWander; // szybkość spacerku
	public float speedChase; // szybkość gonienia
	public float attackRate; // częstość ataku
	public int damage; // zadawane obrażenia

	public float distance;

	Animator anim;
	CharacterController character;

	bool isDead = false;
	float gravity = 960.0f;
	float damping = 6.0f;
	float attackTime;

	Vector3 moveDirection = Vector3.zero;

	void Awake(){
		anim = GetComponent <Animator> ();
		character = GetComponent <CharacterController> ();
	}

	void Start(){
		attackTime = Time.time;
	}

	void Update () 
	{
		if (isDead)
			return;

		if(health <= 0)
		{
			Dead();
		}

		distance = Vector3.Distance(target.position, transform.position);

		if (attackRange >= distance) 
		{
			//StartCoroutine(Attack());
			Attack();
		}
		else if (chaseRange >= distance) 
		{
			Chase();
		} else 
		{
			Wander();
		}

		moveDirection = transform.up;
		updatePosition ();
	}

	/*void ApplayDamage(int damage)
	{
		if (health <= 0)
			return;

		health -= damage;
	}*/

	void Dead()
	{
		anim.SetBool ("dead", true);
		character.enabled = false;
		character.detectCollisions = false;
		isDead = true;
	}

	void Wander()
	{
		anim.SetBool ("playerInRange", false);
	}

	void Chase()
	{
		lookAt();
		moveDirection = transform.forward;
		moveDirection *= speedChase;
		updatePosition ();
		anim.SetBool ("playerInRange", true);
	}

	void Attack()
	{
		lookAt();
		if (Time.time >= attackTime) {
			anim.SetBool ("attack", true);
			attackTime = Time.time + attackRate;
			target.SendMessage("ApplayDamage",damage,SendMessageOptions.DontRequireReceiver);

		} else {
			anim.SetBool ("attack", false);
		}
	}

	void lookAt ()
	{
		Vector3 targetPos = target.position;
		targetPos.y = transform.position.y;
		Quaternion rotation = Quaternion.LookRotation(targetPos - transform.position);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	void updatePosition(){
		moveDirection.y -= gravity * Time.deltaTime;
		if(character.enabled)
			character.Move(moveDirection * Time.deltaTime);
	}
}
