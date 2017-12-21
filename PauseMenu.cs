using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public bool paused = false;
	public buttonActive button; // Manggil Script



	// Use this for initialization
	void Start () {
		button = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil
		PauseUI.SetActive (false);

	}
	
	// Update is called once per frame
	void Update () {

//		if (Input.GetKeyDown (KeyCode.Escape)) {
//			paused = !paused;
//		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
			button.buttonOff = true;
		}


		if (!paused) {
			PauseUI.SetActive (false);
			Time.timeScale = 1;
			button.buttonOff = false;
		}

	}


	public void PauseButton(){
		paused = true;
	}


	public void Resume(){
		paused = false;
	}

	public void Restart(){
		
	}


	public void MainMenu(){
		
	}
		



}
