using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class LevelLoader : MonoBehaviour {

	public GameObject slideractive;
	public Slider slider;
	public Text pourcentage;

	public void LoadLevel(int sceneIndex)
	{
		StartCoroutine(LoadAsync(sceneIndex));
	}

	IEnumerator LoadAsync(int sceneIndex)
	{
		AsyncOperation operation = SceneManager.LoadSceneAsync(sceneIndex);

		slideractive.SetActive (true);

		while (!operation.isDone) 
		{
			float progress = Mathf.Clamp01(operation.progress / 0.9f);

			slider.value = progress;

			pourcentage.text = progress * 100 + "%";

			yield return null;
		}
	}
}