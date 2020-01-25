using UnityEngine;

public class Orbes : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") {

			Destroy (gameObject);
		}
	}
}
