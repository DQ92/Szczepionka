using UnityEngine;
using System.Collections;

public class DestroyMeAndChildren : MonoBehaviour {
	[Header("Time:")]
	public float min = 1F;
	public float max = 2F;

	void Awake () {
		for(int i=0; i<transform.childCount; i++)
		{
			Destroy(transform.GetChild(i).gameObject,Random.Range(min, max));
		}
		Destroy(gameObject,max+0.1F);
	}

}
