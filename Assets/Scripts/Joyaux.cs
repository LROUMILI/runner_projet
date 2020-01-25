using UnityEngine;

public class Joyaux : MonoBehaviour {


	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Player") {

			Destroy (gameObject);
		}
	}
}
