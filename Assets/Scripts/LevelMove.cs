using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelMove : MonoBehaviour {

	public Transform[] views;
	public float transitionSpeed;
	Transform currentView;

	public GameObject B1;
	public GameObject B2;
	public GameObject B3;

	void Start () {

		currentView = views [0];
	}

	void Update(){

		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
		//	currentView = views [0];
		//}

		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
		//	currentView = views [1];
		//}

		//if (Input.GetKeyDown (KeyCode.RightArrow)) {
		//	currentView = views [2];
		//}
	}


	void LateUpdate () {

		transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionSpeed);

		Vector3 currentAngle = new Vector3 (
			Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

		transform.eulerAngles = currentAngle;
	}
		
    public void to1 (){
	currentView = views [0];
		B1.SetActive (true);
		B2.SetActive (false);
		B3.SetActive (false);
}
	public void to2 (){
		currentView = views [1];
		B1.SetActive (false);
		B2.SetActive (true);
		B3.SetActive (false);
	}
	public void to3 (){
		currentView = views [2];
		B1.SetActive (false);
		B2.SetActive (false);
		B3.SetActive (true);
	}
}