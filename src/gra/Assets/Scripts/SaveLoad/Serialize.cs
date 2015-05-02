using UnityEngine;
using System.Collections;
using System;

public class Serialize : MonoBehaviour {
	string uuid="";

	void Awake()
	{
		if(uuid.Equals(""))
			uuid = System.Guid.NewGuid().ToString();
	}


}
