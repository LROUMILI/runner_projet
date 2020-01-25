using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActiveAnim : MonoBehaviour {

	public GameObject camera;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			camera.GetComponent<Animator>().enabled = true;
		}
	}
}
