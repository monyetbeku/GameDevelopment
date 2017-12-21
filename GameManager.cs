using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour 
{
	public void toGame()
	{
		SceneManager.LoadScene ("Scene01");
	}
	public void toMenu()
	{
		SceneManager.LoadScene ("MainMenu");
	}
}
