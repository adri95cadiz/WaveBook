using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour {

	public void goToScene(string name)
	{
		SceneManager.LoadScene(name);
	}

	public void quitGame()
	{
		Application.Quit ();
	}
}
