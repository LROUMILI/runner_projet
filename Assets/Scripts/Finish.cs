using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class Finish : MonoBehaviour {

	public GameObject fade;
	public GameObject musique;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			fade.SetActive (true);
			musique.GetComponent<Animator>().enabled = true;
		}
	}
		
}
