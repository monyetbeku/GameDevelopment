using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class door2 : MonoBehaviour {

	public bool doorBool;


	void Start(){
		
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.CompareTag ("Player"))
			doorBool = true;
			Debug.Log ("DoorBool True");
			SceneManager.LoadScene ("Scene02");
			
	}

}
