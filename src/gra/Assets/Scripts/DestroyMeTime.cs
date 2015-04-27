using UnityEngine;
using System.Collections;

public class DestroyMeTime : MonoBehaviour {
	public float destroyTime = 1;

	// Use this for initialization
	void Start () {
		StartCoroutine (DestroyMe());
	}
	
	// Update is called once per frame
	void Update () {
	
	}

	IEnumerator  DestroyMe(){
		yield return new WaitForSeconds(destroyTime);
		Destroy(gameObject);
	}
}
