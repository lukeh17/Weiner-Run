﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadScene : MonoBehaviour {

	public void LoadByIndex(int sceneIndex)
	{
		Time.timeScale = 1f;
		SceneManager.LoadScene (sceneIndex);
        if (sceneIndex == 1)
        {
            //SpawnScript.Enabled = true;
        }
	}

}
