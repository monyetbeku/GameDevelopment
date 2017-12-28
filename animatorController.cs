using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class animatorController : MonoBehaviour {

	public static animatorController instance;
	PlayerController playercont;
	mainmenu restartOn;

	public int enemyLayer;
	public int playerLayer;
	public int duriLayer;
	public int Snowbols;
	bool playerdie;
	bool restart6;



	Transform myTrans;
	Animator myAnim;
	public Vector3 sansScaleCache;

	void Start () 
	{
		myTrans = this.transform;
		myAnim = this.gameObject.GetComponent<Animator> ();
		playercont = FindObjectOfType<PlayerController> ();
		restartOn = FindObjectOfType<mainmenu> ();
		instance = this;
		sansScaleCache = myTrans.localScale;
		playerdie = false;
	}

	void Awake()
	{
		instance = this;
	}

	void FlipAnimation(float currentSpeed)
	{
		if ((currentSpeed < 0 && sansScaleCache.x > 0) || //going to left and facing right OR
			(currentSpeed > 0 && sansScaleCache.x < 0)) //going right and facing left
		{
			//flip the player
			sansScaleCache.x *= -1;
			myTrans.localScale = sansScaleCache;
		}
	}

	public void UpdateSpeed (float currentSpeed) 
	{
		myAnim.SetFloat("Speed", currentSpeed);
		FlipAnimation (currentSpeed);
	}

	public void UpdateIsGrounded (bool isGrounded)
	{
		myAnim.SetBool ("isGrounded", isGrounded); 
	}

	public void TriggerDamaged(float damagedTime)
	{
		StartCoroutine (DamagerBlinker (damagedTime));
	}

	IEnumerator DamagerBlinker(float damagedTime)
	{
		//ignore collision with enemy layer
		enemyLayer = LayerMask.NameToLayer("Enemy");
		playerLayer = LayerMask.NameToLayer("Player");
		duriLayer = LayerMask.NameToLayer("Duri");
		Snowbols = LayerMask.NameToLayer("Snowbol");
		playerdie = playercont.Die ();
		restart6 = restartOn.restart7;




		Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, true);
		Physics2D.IgnoreLayerCollision (duriLayer, playerLayer, true);
		Physics2D.IgnoreLayerCollision (Snowbols, playerLayer, true);
		foreach (Collider2D collider in PlayerController.instance.myCools) 
		{
			collider.enabled = false;
			collider.enabled = true;

		}

		if (playerdie || restart6) {
			Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);
			Physics2D.IgnoreLayerCollision (duriLayer, playerLayer, false);
			Physics2D.IgnoreLayerCollision (Snowbols, playerLayer, false);
		}





		//start blink animation
		myAnim.SetLayerWeight(1,1);

		//blinking animation start till end
		yield return new WaitForSeconds(damagedTime);

		//stop blinking and re-enable player layer collision with enemy layer
		Physics2D.IgnoreLayerCollision (enemyLayer, playerLayer, false);
		Physics2D.IgnoreLayerCollision (duriLayer, playerLayer, false);
		Physics2D.IgnoreLayerCollision (Snowbols, playerLayer, false);
		myAnim.SetLayerWeight (1, 0);
	}
}
