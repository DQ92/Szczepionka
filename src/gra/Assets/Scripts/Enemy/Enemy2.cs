using UnityEngine;
using System.Collections;

public class Enemy2 : MonoBehaviour {
	public int health = 100;
	public Transform [] waypoints;// między punktami nie może być przeszkód
	public Transform target;
	[Header("Sounds:")]
	public AudioClip shot;
	public AudioClip explode;

	[Header("Effects:")]
	public Transform destroyed;
	public Transform explosion;
	public Transform muzzle;
	public Transform lWeapon;
	public Transform rWeapon;

	[Header("Attack & watch:")]
	public float attackRange;
	public float watchSpeed;
	public float attackSpeed;
	public float damage;
	public float shotDelay;

	enum State {watch,attack};
	State state;

	Vector3 startPoint;
	Vector3 endPoint;
	float startTime;
	float duration = 5.0f;
	float damping = 6.0f;

	bool canShoot = true;

	Vector3 targetPoint;

	// Use this for initialization
	void Start () {
		newTarget(chooseTarget());

	}
	
	// Update is called once per frame
	void Update () {
		if(health>0){
			targetPoint = target.position+ new Vector3(0,1.2f,0);

			if(checkState() == State.watch)
				watch ();
			else
				attack();
			return;
		}
		Die();
	}

	void lookAt (Vector3 targetPos)
	{
		Vector3 rot = targetPos - transform.position;
		if(rot == Vector3.zero)
			return;
		Quaternion rotation = Quaternion.LookRotation(rot);
		transform.rotation = Quaternion.Slerp(transform.rotation, rotation, Time.deltaTime * damping);
	}

	State checkState()
	{
		//float distance = Vector3.Distance(target.position, transform.position);
		
		//if(attackRange <= distance)
		RaycastHit hit;
		Vector3 dir = (targetPoint - rWeapon.transform.position).normalized;
		Debug.DrawRay(rWeapon.transform.position,dir*attackRange);
		if (Physics.Raycast (rWeapon.transform.position, dir, out hit, attackRange))
		{
			if(hit.transform.tag == "Player")
				return state = State.attack;
		}

		state = State.watch;
		if(state == State.watch)
			return state;

		newTarget(chooseTarget());
		return state;

	}

	void watch()
	{
		lookAt(endPoint);
		transform.position = Vector3.Lerp(startPoint, endPoint, (Time.time - startTime) / duration);
		if(Vector3.Distance(transform.position,endPoint) <= 0.01F)
		{
			newTarget(chooseTarget());
		}
	}

	void attack()
	{
		lookAt(target.position);

		float currentDistance = Vector3.Distance(targetPoint, transform.position);
		float nearest = float.PositiveInfinity;
		Transform point = null;

		foreach (Transform t in waypoints)
		{
			float d = Vector3.Distance(targetPoint,t.position);
			if(d < nearest){
				nearest = d;
				point = t;
			}
		}

		if(nearest < currentDistance){
			if(Vector3.Distance(point.position,endPoint) > 0.01F)
				newTarget(point.position);
		}
		else{
			endPoint = transform.position;
		}

		if(Vector3.Distance(transform.position,endPoint) > 0.01F)
			transform.position = Vector3.Lerp(startPoint, endPoint, (Time.time - startTime) / duration);
		if(canShoot)
			StartCoroutine(fire());
	}

	void newTarget(Vector3 point)
	{
		startPoint = transform.position;
		endPoint = point;
		startTime = Time.time;

		if(state == State.watch)
			duration = Vector3.Distance(startPoint,endPoint)/watchSpeed;
		else
			duration = Vector3.Distance(startPoint,endPoint)/attackSpeed;
	}

	Vector3 chooseTarget()
	{
		return waypoints[Random.Range(0,waypoints.Length-1)].position;
	}

	void ApplayDamage(int damage)
	{
		health -= damage;
	}

	IEnumerator fire()
	{
		//if (!canShoot)
			//yield return new WaitForSeconds(0.0f);

		canShoot = false;

		fireRight();
		fireLeft();

		yield return new WaitForSeconds(shotDelay);
		canShoot = true;
	}

	void fireRight()
	{
		RaycastHit hit;
		Vector3 dir = (targetPoint - rWeapon.transform.position).normalized;

		audio.PlayOneShot(shot);
		Instantiate(muzzle, rWeapon.position, Quaternion.LookRotation(dir));

		if (Physics.Raycast (rWeapon.transform.position, dir, out hit, 100))
		{
			hit.transform.SendMessage("ApplayDamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}

	void fireLeft()
	{
		RaycastHit hit;
		Vector3 dir = (targetPoint - lWeapon.transform.position).normalized;

		audio.PlayOneShot(shot);
		Instantiate(muzzle, lWeapon.position, Quaternion.LookRotation(dir));

		if (Physics.Raycast (lWeapon.transform.position, dir, out hit, 100))
		{
			hit.transform.SendMessage("ApplayDamage",damage,SendMessageOptions.DontRequireReceiver);
		}
	}

	void Die()
	{
		Instantiate(explosion, transform.position, Quaternion.identity);
		Destroy(gameObject);
		Instantiate(destroyed, transform.position, Quaternion.identity);
	}
}
