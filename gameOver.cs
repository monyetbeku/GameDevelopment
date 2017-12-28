using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour {

	public GameObject gameOver1;

	public bool over = false;
	public buttonActive button1; // Manggil Script


	// Use this for initialization
	void Start () {
		button1 = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil
		gameOver1.SetActive (false);

	}

	// Update is called once per frame
	void Update () {



		if (over) {
			gameOver1.SetActive (true);

			button1.buttonOff = true;
		}


		if (!over) {
			gameOver1.SetActive (false);

			button1.buttonOff = false;
		}

	}







	public void Restart(){
		
	}


	public void MainMenu(){
		
	}
		



}
