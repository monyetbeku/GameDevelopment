using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PauseMenu : MonoBehaviour {

	public GameObject PauseUI;
	public bool paused = false;
	public buttonActive button; // Manggil Script
	PlayerController kebal;
//	public bool kebalOn;




	// Use this for initialization
	void Start () {
		button = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil
		kebal = FindObjectOfType<PlayerController>();
		PauseUI.SetActive (false);


	}






	
	// Update is called once per frame
	void Update () {

//		if (kebalOn) {
//			kebal.invicibleAfterDamaged = 0;
//		} 
//		else {
//			kebal.invicibleAfterDamaged = 2;
//		}




		if (Input.GetKeyDown (KeyCode.Escape)) {
			paused = !paused;

		}

		if (paused) {
			PauseUI.SetActive (true);
			Time.timeScale = 0;
			button.buttonOff = true;
//			kebalOn = true;
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
