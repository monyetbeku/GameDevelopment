using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TextBoxManager : MonoBehaviour {


	[Header("SANTA KELES")]
	public GameObject santaName;
	public GameObject santaFace;

	[Header("LOLI")]
	public GameObject loliFace;
	public GameObject loliName;

	[Header("TEXT MANAGER")]

	public GameObject textBox;

	public Text theText;

	public TextAsset textFile;
	public string[] textLines;

	public int currentLine;
	public int endLine;



	public PlayerController player; // Manggil Script
	public buttonActive button; // Manggil Script


	public bool isActive;
	public bool stopPlayerMovement;
	private bool buttonActived1 = false;

	private bool isTyping = false;
	private bool cancelTyping = false;

	public float typeSpeed;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> (); // Declarasi script yang dipanggil
		button = FindObjectOfType<buttonActive> (); // Declarasi script yang dipanggil

		if (textFile != null) {
			textLines = (textFile.text.Split ('\n'));
		}	

		if (endLine == 0) {
			endLine = textLines.Length - 1;
		}

		if (isActive) {
			EnableTextBox ();
		} 
		else {
			DisableTextBox ();
		}

	}

	void Update(){
		if (!isActive) {
			return;
		}
		//theText.text = textLines [currentLine];

		if (currentLine == 0) {
			santaFace.SetActive (true);
			santaName.SetActive (true);
		}
		else{
			santaFace.SetActive (false);
			santaName.SetActive (false);
		}

		if(currentLine == 1){
			loliFace.SetActive (true);
			loliName.SetActive (true);
		}
		else{
			loliFace.SetActive (false);
			loliName.SetActive (false);
		}

		if (Input.GetKeyDown (KeyCode.Return)) {
			if (!isTyping) {
				currentLine += 1;
				if (currentLine > endLine) { // 0,1,2,3,4,5,6,....
					DisableTextBox ();
				} 
				else {
					StartCoroutine (TextScroll(textLines[currentLine]));
				}
			} 

			else if(isTyping && !cancelTyping){
				cancelTyping = true;
			}
		}
	}

	private IEnumerator TextScroll (string lineofText){
		int letter = 0;
		theText.text = "";
		isTyping = true;
		cancelTyping = false;
		while (isTyping && !cancelTyping && (letter < lineofText.Length -1)) {
			theText.text += lineofText [letter];
			letter += 1;
			yield return new WaitForSeconds (typeSpeed);
		}
		theText.text = lineofText;
		isTyping = false;
		cancelTyping = false;
	}

	public void EnableTextBox(){
		textBox.SetActive (true);
		isActive = true;
		button.buttonOff = true;



		if (stopPlayerMovement) {
			player.canMove = false;
		}

		StartCoroutine (TextScroll(textLines[currentLine]));
	}

	public void DisableTextBox(){
		textBox.SetActive (false);
		isActive = false;
		button.buttonOff = false;

		player.canMove = true;
	}

	public void ReloadScript(TextAsset theText){
		if (theText != null) {
			textLines = new string[1];
			textLines = (theText.text.Split ('\n'));

		}

	}
}
