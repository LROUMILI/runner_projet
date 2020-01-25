using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PauseMenu : MonoBehaviour {

	public static bool GameIsPaused = false;
	public AudioSource musique;

	public GameObject pausedMenuUI;

	void Update () {

		if(Input.GetKeyDown("p"))
		{

		if (GameIsPaused) {
			
			Resume ();

		} else
		{
			Pause ();
		}

	}
}
	void Resume()
	{
		pausedMenuUI.SetActive (false);
		Time.timeScale = 1f;
		GameIsPaused = false;
		musique.enabled = true;
	}

	void Pause()
	{
		pausedMenuUI.SetActive (true);
		Time.timeScale = 0f;
		GameIsPaused = true;
		musique.enabled = false;
	}
}
