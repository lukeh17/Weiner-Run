using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Pause : MonoBehaviour {

	public static bool gameIsPaused = false;
	public GameObject pauseMenu;

	public void resume()
	{
		pauseMenu.SetActive (false);
		Time.timeScale = 1f;
		gameIsPaused = false;
	}

	public void pause()
	{
		pauseMenu.SetActive (true);
		Time.timeScale = 0f;
		gameIsPaused = true;
	}

}
