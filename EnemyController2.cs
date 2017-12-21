using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController2 : MonoBehaviour {

	public LayerMask enemyMask;
	public float speed;
	Rigidbody2D myBody;
	Transform myTrans;
	float myWidth,myHeight;


	Animator myAnim;

	void Start () 
	{
		myTrans = this.transform;
		myAnim = this.GetComponent<Animator> ();
		myBody = this.GetComponent<Rigidbody2D> (); 
		SpriteRenderer mySprite = this.GetComponent<SpriteRenderer> ();
		myWidth = mySprite.bounds.extents.x;
		myHeight = mySprite.bounds.extents.y;
	}
	
	void FixedUpdate () 
	{
		//check to see if there's ground below before moving forward
		Vector2 lineCastPos = myTrans.position.toVector2() - myTrans.right.toVector2() * myWidth + Vector2.up *myHeight;
		Debug.DrawLine(lineCastPos, lineCastPos + Vector2.down);
		bool isGrounded = Physics2D.Linecast (lineCastPos, lineCastPos + Vector2.down, enemyMask);
		Debug.DrawLine(lineCastPos, lineCastPos - myTrans.right.toVector2() * .01f);
		bool isBlocked = Physics2D.Linecast (lineCastPos, lineCastPos - myTrans.right.toVector2() * .01f, enemyMask);

		//if there's no ground or if its blocked then turn around
		if (!isGrounded || isBlocked) 
		{
			Vector3 currentRotation = myTrans.eulerAngles;
			currentRotation.y += 180;
			myTrans.eulerAngles = currentRotation;
		}

		//always move forward
		Vector2 myVelocity = myBody.velocity;
		myVelocity.x = -myTrans.right.x * speed;
		myBody.velocity = myVelocity;
	}

	public void Hurt()
	{
		myAnim.SetBool ("Hurted", true);
		Destroy (this.gameObject);
	}
}
