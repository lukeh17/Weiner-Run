﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShowHighScore : MonoBehaviour {

	public Text highScore;

	// Use this for initialization
	void Start () {
		highScore.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }



}
