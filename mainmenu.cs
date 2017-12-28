using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class mainmenu : MonoBehaviour {

	PlayerController darah;
	door2 doorOn;


	public bool restart7;

	void Start(){
		darah = FindObjectOfType<PlayerController>();
		doorOn = FindObjectOfType<door2>();
		Time.timeScale = 1;
		restart7 = false;
	}


	public void PlayGame(){
		SceneManager.LoadScene ("Scene01");
		darah.curHealth = darah.maxHealth;
	}

	public void QuitGame(){
		Debug.Log ("QUIT");
		Application.Quit ();
	}

	public void RestartGame(){
		restart7 = true;
		Debug.Log ("RESTART Scene 1");
		SceneManager.LoadScene ("Scene01");
//		if (doorOn.doorBool) {
//			restart7 = true;
//			Debug.Log ("RESTART Scene 2");
//			SceneManager.LoadScene ("Scene02");
//		} 
//		else {
//			restart7 = true;
//			Debug.Log ("RESTART Scene 1");
//			SceneManager.LoadScene ("Scene01");
//		}

	}

	public void ToMenu(){
		doorOn.doorBool = false;
		Debug.Log ("Main Menu");
		SceneManager.LoadScene ("MainMenu");
	}


}
