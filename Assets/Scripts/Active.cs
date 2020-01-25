using UnityEngine;

public class Active : MonoBehaviour {

	public GameObject Object;

	void OnTriggerEnter(Collider col)
	{
		if (col.tag == "Player") 
		{
			Object.SetActive (true);
		}
	}
}
