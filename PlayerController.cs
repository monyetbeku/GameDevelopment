﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour 
{
	public static PlayerController instance;
	PauseMenu pause1;

	//movement
	[Header("Movement")]
	public float speed = 10;
	public float jumpVelocity = 20;
	public LayerMask playerMask;
	public bool canMoveInAir = true;
	float hInput;
	Transform myTrans; 
	public Transform tagGround;
	public float radius;

	// HEALTH ======================

	public int curHealth;
	public int maxHealth = 100;
	public Transform spawnPoint;
	public Vector2 velocity;

	// HEALTH ======================



	public AudioClip jump;
	AudioSource playerJump;


	public Rigidbody2D myBody;
	public bool isGrounded = false;
	public animatorController myAnim;

	[Header("Combat")]
	//combat
	public int playerHeart = 3;
	public float invicibleAfterDamaged = 2;
	[HideInInspector]
	public Collider2D[] myCools;

	public GameObject LostPanel;
	public GameObject Player;

	public gameOver gameOver1;


	// WIDHI =================================


	public bool canMove;
	public Transform diePoint;


	// WIDHI =================================



	void Start () 
	{
		pause1 = FindObjectOfType<PauseMenu> ();
		myCools = this.GetComponents<Collider2D> ();
		myBody = this.GetComponent<Rigidbody2D> ();
		myTrans = this.transform;
		//tagGround = GameObject.Find (this.name + "/tag_Ground" ).transform;
		myAnim = animatorController.instance;
		instance = this;

		gameOver1 = FindObjectOfType<gameOver> ();

		curHealth = maxHealth;

		playerJump = GetComponent<AudioSource> ();



	}
	
	void FixedUpdate () 
	{
		
		if (curHealth > maxHealth) {
			curHealth = maxHealth;
		}

		if (curHealth <= 0) {
			Die ();
		}



		// WIDHI =======================================

		if(!canMove){

			return;
		}


		// WIDHI ======================================





		isGrounded = Physics2D.OverlapCircle (tagGround.position, radius, playerMask);
		myAnim.UpdateIsGrounded (isGrounded);




		#if !UNITY_ANDROID && !UNITY_EDITOR && !UNITY_IPHONE && !UNITY_BLACKBERRY && !UNITY_WINRT || UNITY_EDITOR
		hInput = Input.GetAxisRaw("Horizontal");
		myAnim.UpdateSpeed (hInput);
		if(Input.GetButtonDown("Jump"))
		{
			Jump();
		}
		#endif
		Move (hInput);
	}


	// DIE =====================

	public bool Die(){
		if (curHealth <= 0) {
			gameOver1.over = true;
			transform.position = diePoint.position;
			//		Physics2D.IgnoreLayerCollision (myAnim.enemyLayer, myAnim.playerLayer, false);
			//		Physics2D.IgnoreLayerCollision (myAnim.duriLayer, myAnim.playerLayer, false);
			//		Physics2D.IgnoreLayerCollision (myAnim.Snowbols, myAnim.playerLayer, false);
			return true;
		}
		return false;

	}
	// DIE ====================

	void Move(float horizontalInput)
	{
		if (!canMoveInAir && !isGrounded)
			return;
		Vector2 moveVelocity = myBody.velocity;
		moveVelocity.x = horizontalInput * speed;
		myBody.velocity = moveVelocity;
	}

	public void Jump()
	{
		if (isGrounded) 
		{
			myBody.velocity += jumpVelocity * Vector2.up;
			playerJump.clip = jump;
			playerJump.Play ();



		}
	}

	public void starMoving(float horizontalInput)
	{
		hInput = horizontalInput;
		myAnim.UpdateSpeed (horizontalInput);
	}

	void Damaged()
	{
		curHealth -= 1;
		myAnim.TriggerDamaged (invicibleAfterDamaged);
		Debug.Log ("KENA CIDUK SEKALI");
	}

	void OnCollisionEnter2D(Collision2D collision)
	{
		EnemyController2 enemy = collision.collider.GetComponent<EnemyController2>();
		if (enemy != null) 
		{
			foreach (ContactPoint2D point in collision.contacts) 
			{
				//Debug.Log (point.normal);
				Debug.DrawLine (point.point, point.point + point.normal, Color.red, 10);
				if (point.normal.y >= 0.9f) {
					velocity = myBody.velocity;
					velocity.y = jumpVelocity;
					myBody.velocity = velocity;
					enemy.Hurt ();
				} else {
					Damaged ();
				}
			}
		}
	}

}
