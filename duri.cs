using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class duri : MonoBehaviour {
	
	public PlayerController jump;
	public animatorController blink;
	public GameObject duri1;



	// Use this for initialization
	void Start () {
		jump = FindObjectOfType<PlayerController> ();
		blink = animatorController.instance;
	}
	
	// Update is called once per frame
	void Update () {
	}

	void OnCollisionEnter2D(Collision2D col){
		if (col.transform.CompareTag ("Player")) {
			jump.velocity.y = jump.jumpVelocity;
			jump.myBody.velocity = jump.velocity;
			jump.curHealth -= 2;
			blink.TriggerDamaged (jump.invicibleAfterDamaged);
		}
	}


}
