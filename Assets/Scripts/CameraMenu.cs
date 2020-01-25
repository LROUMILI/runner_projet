using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraMenu : MonoBehaviour {

	public Transform[] views;
	public float transitionSpeed;
	Transform currentView;
	public GameObject StatsUI;
	public GameObject HomeUI;
	public GameObject LevelUI;

	void Start () {

		currentView = views [0];
		StatsUI.SetActive (false);
		HomeUI.SetActive (true);
	}

	void Update(){

		if (Input.GetKeyDown (KeyCode.A)) {
			currentView = views [0];
			StatsUI.SetActive (false);
			HomeUI.SetActive (true);
			LevelUI.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Z)) {
			currentView = views [1];
			StatsUI.SetActive (true);
			HomeUI.SetActive (false);
			LevelUI.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.E)) {
			currentView = views [2];
			StatsUI.SetActive (false);
			HomeUI.SetActive (false);
			LevelUI.SetActive (true);
		}
	}


	void LateUpdate () {

		transform.position = Vector3.Lerp (transform.position, currentView.position, Time.deltaTime * transitionSpeed);

		Vector3 currentAngle = new Vector3 (
			Mathf.LerpAngle(transform.rotation.eulerAngles.x, currentView.transform.rotation.eulerAngles.x, Time.deltaTime * transitionSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.y, currentView.transform.rotation.eulerAngles.y, Time.deltaTime * transitionSpeed),
			Mathf.LerpAngle(transform.rotation.eulerAngles.z, currentView.transform.rotation.eulerAngles.z, Time.deltaTime * transitionSpeed));

		transform.eulerAngles = currentAngle;
	}

	IEnumerator jouerDeux(){
		currentView = views [2];
		StatsUI.SetActive (false);
		HomeUI.SetActive (false);
		yield return new WaitForSeconds (1);
		LevelUI.SetActive (true);
	}

	public void JouerUn (){
		StartCoroutine(jouerDeux());
	}
	public void Reglage (){
		currentView = views [1];
		StatsUI.SetActive (true);
		HomeUI.SetActive (false);
		LevelUI.SetActive (false);
	}
	public void Retour (){
		currentView = views [0];
		StatsUI.SetActive (false);
		HomeUI.SetActive (true);
		LevelUI.SetActive (false);
	}
}
