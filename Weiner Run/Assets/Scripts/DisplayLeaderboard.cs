using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class DisplayLeaderboard : MonoBehaviour {

    public Text[] highscoreText;
    Leaderboard leaderboardManager;

	// Use this for initialization
	void Start () {

        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ". Fetching...";
        }

        leaderboardManager = GetComponent<Leaderboard>();

        StartCoroutine("RefreshHighscore");
	}

    public void OnHighscoresDownloaded(Leaderboard.Highscore[] highscoreList)
    {
        for (int i = 0; i < highscoreText.Length; i++)
        {
            highscoreText[i].text = i + 1 + ".";
            if (highscoreList.Length > i)
            {
                highscoreText[i].text += "  " + highscoreList[i].score;
                //highscoreList[i].username + " " +
            }
        }

    }

    IEnumerator RefreshHighscore()
    {
        while (true)
        {
            leaderboardManager.DownloadHighScores();
            yield return new WaitForSeconds(30);

        }
    }
}
