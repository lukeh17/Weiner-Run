using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameController : MonoBehaviour {

    //private GameObject leaderboard;
	public GameObject pauseButton;
	public GameObject backToMain;
	public GameObject restartButton;
	public static GameController instance;
    public bool gameOver = false;
    public GameObject gameOverText;
	public Text scoreText;
    public GameObject highScore;
    public GameObject plus20;
    public GameObject marks;
    public Text pickleAmount;
   

	public int score;
    private int x = 0;

    // Use this for initialization
    void Awake () 
	{
        //AdManager.HideBanner();
        if (instance == null)
        {
            instance = this;
        }

        UpdatePickleCount();
	}//end Awake
	
	// Update is called once per frame
	void Update () {
		if (gameOver == true) 
		{
			pauseButton.SetActive (false);
			

		}//end if
	}//end update

  
    public void UpdatePickleCount()
    {
        pickleAmount.text = PlayerPrefs.GetInt("Pickles").ToString();
    }

	public void playerScored()
	{
		if (gameOver) 
		{
			return;
		}
		score++;
		scoreText.text = "Score: " + score.ToString ();
	}

    public void ShowPlus20()
    {
        StartCoroutine(Plus20());
    }

    IEnumerator Plus20()
    {
        //Debug.Log("+20 should be shown");
        plus20.SetActive(true);
        yield return new WaitForSeconds(1);
        plus20.SetActive(false);
        //Debug.Log("+20 should be hidden");
    }

    public void ShowSpeedMarks()
    {
        StartCoroutine(SpeedMarks());
    }

    IEnumerator SpeedMarks()
    {
        if (marks != null)
        {
            marks.SetActive(true);
            yield return new WaitForSeconds(2);
            marks.SetActive(false);
        }
    }

    public void playerDied()
	{
        

		gameOverText.SetActive (true);
		gameOver = true;
		restartButton.SetActive (true);
		backToMain.SetActive (true);
		Player.onDeath ();
		pauseButton.SetActive (false);
        SpawnScript.Enabled = (false);

        if (x == 0)
        {
            AdManager.ShowInterstitial();
            x++;
        }



        if (score > PlayerPrefs.GetInt ("HighScore", 0)) 
		{
            
			PlayerPrefs.SetInt ("HighScore", score);
            highScore.SetActive (true);
		}


	}//end playerDied

    public void AddScore()
    {
        score += 10;
        //Debug.Log("Adding 20 to score " + score);
    }
}//end gameController
