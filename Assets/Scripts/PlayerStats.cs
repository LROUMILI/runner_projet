using UnityEngine;
using System.Collections;
using UnityEngine.UI;

public class PlayerStats : MonoBehaviour {

	//stats principale
	public int orbesTotale;
	//public Text orbesTotaleUi;

	public int joyauxTotale;
	//public Text joyauxTotaleUi;


	//Stats en jeu
	public int multiScore = 1;

	public int joyaux;
	public Text numJoyaux;

	int joyauxMax = 3;

	public int orbes;
	public Text numOrbes;

	public int score;
	public Text Score;


	void Update () 
	{

		//orbesTotaleUi.text = orbesTotale.ToString("0");
		//joyauxTotaleUi.text = joyauxTotale.ToString("0");

		score = (orbes + (joyaux * 10))* multiScore;

		numOrbes.text = orbes.ToString("0");
		Score.text = score.ToString("0");

		numJoyaux.text = joyaux.ToString("0")  + "/3";

		if (joyaux > joyauxMax) 
		{
			joyaux = joyauxMax;
		}
	}

	//RECUPERATION D'OBJETS ET COLLISIONS
	void OnTriggerEnter (Collider col)
	{
		if (col.tag == "Orbe") {

			orbes += 1;
		}

		if (col.tag == "Joyau") {

			joyaux += 1;
		}

		if (col.tag == "multiScore") {

			multiScore *= 2;
		}

		//Ajoueter les orbes trouvé au totale
		if (col.tag == "FinishBox") 
		{
			orbesTotale += orbes;
		}
	}
}
