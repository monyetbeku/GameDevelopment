using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class buttonActive : MonoBehaviour {

	public GameObject buttonLeft;
	public GameObject buttonRight;
	public GameObject buttonJump;
	public GameObject buttonPause;
	public GameObject heart;

	public bool buttonOff;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
		if (buttonOff) {
			buttonLeft.SetActive (false);
			buttonRight.SetActive (false);
			buttonJump.SetActive (false);
			buttonPause.SetActive (false);
			heart.SetActive (false);
		} 
		else {
			buttonLeft.SetActive (true);
			buttonRight.SetActive (true);
			buttonJump.SetActive (true);
			buttonPause.SetActive (true);
			heart.SetActive (true);
		}
	}
}
