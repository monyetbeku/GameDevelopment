using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fall : MonoBehaviour {

	public Transform spawnPoint;
	public PlayerController hearth;

	void Start(){
		hearth = FindObjectOfType<PlayerController> ();
	}


	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.CompareTag ("Player"))
			hearth.curHealth -= 2;
			col.transform.position = spawnPoint.position;
	}

}
