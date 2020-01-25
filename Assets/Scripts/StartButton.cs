using UnityEngine;
using UnityEngine.UI;

public class StartButton : MonoBehaviour {

	public GameObject buttonStart;
	public GameObject musique;
	public GameObject blackPanels;

	void Start ()
	{
		Time.timeScale = 0f;
	}

	public void StartLVL () 
	{
		buttonStart.SetActive (false);
		musique.SetActive (true);
		blackPanels.SetActive (false);
		Time.timeScale = 1f;
	}
}
