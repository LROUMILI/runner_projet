using UnityEngine;

public class PlayerCollision : MonoBehaviour {

	public GameObject playerlight;
	public GameObject deathparticle;
	public GameObject panel;
	public GameObject rejouer;
	public GameObject menu;
	public GameObject fade;
	public GameObject pourcentage;
	public GameObject musique;

	public GameObject OrbesUI;
	public GameObject NumOrbesUI;

	void OnControllerColliderHit (ControllerColliderHit hit) 
	{
		if (hit.collider.tag == "Obstacle") 
		{
			musique.GetComponent<Animator>().enabled = true;

			gameObject.GetComponent<Movement>().enabled = false;
			gameObject.GetComponent<MeshRenderer>().enabled = false;
			playerlight.SetActive(false);
			deathparticle.SetActive(true);

			fade.SetActive (true);
			panel.SetActive(true);
			rejouer.SetActive (true);
			menu.SetActive (true);
			pourcentage.SetActive (true);

			OrbesUI.SetActive (false);
			NumOrbesUI.SetActive (false);

		}
	}
}
