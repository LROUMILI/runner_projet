using UnityEngine;

public class Desactive : MonoBehaviour {

	public GameObject Object;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			Object.SetActive (false);
		}
	}
}
