using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class finish : MonoBehaviour {

	public GameObject finish1;

	public buttonActive button; // Manggil Script

	public Transform finishpoint;


	// Use this for initialization
	void Start () {
		button = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil
		finish1.SetActive (false);

	}

	// Update is called once per frame
	void Update () {
		
	}

	public void MainMenu(){
		
	}


	void OnTriggerEnter2D(Collider2D other){

		if  (other.name == "Player") {
			Debug.Log ("Finish");

			finish1.SetActive (true);
			Time.timeScale = 0;
			button.buttonOff = true;
			other.transform.position = finishpoint.position;


		}
	}

	void OnTriggerExit2D(Collider2D other){


	}
		



}
