using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gameOver : MonoBehaviour {

	public GameObject gameOver1;

	public bool over = false;
	public buttonActive button; // Manggil Script


	// Use this for initialization
	void Start () {
		button = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil
		gameOver1.SetActive (false);

	}

	// Update is called once per frame
	void Update () {



		if (over) {
			gameOver1.SetActive (true);
			Time.timeScale = 0;
			button.buttonOff = true;
		}


		if (!over) {
			gameOver1.SetActive (false);
			Time.timeScale = 1;
			button.buttonOff = false;
		}

	}







	public void Restart(){
		
	}


	public void MainMenu(){
		
	}
		



}
