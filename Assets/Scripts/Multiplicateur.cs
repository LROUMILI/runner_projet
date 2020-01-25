using UnityEngine;

public class Multiplicateur : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") {

			Destroy (gameObject);
		}
	}
}
