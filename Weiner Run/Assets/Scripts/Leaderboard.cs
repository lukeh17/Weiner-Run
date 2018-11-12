using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Leaderboard : MonoBehaviour {

    const string privateCode = "LUwKkHKTFECf7JO_qo43CQrZiuxZ1ihEujNnlT5BiPUw";
    const string publicCode = "5abad6a1012b2e1068d3d021";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayLeaderboard leaderboardDisplay;
    private bool created;

    void Awake()
    {
        //instance = this;
        leaderboardDisplay = GetComponent<DisplayLeaderboard>();
    }

    public void AddHighScore(string username, int score)
    {
        StartCoroutine(UploadHighScore(username, score));
    }

    IEnumerator UploadHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            DownloadHighScores();
        }
        else
        {
            print("Error uploading " + www.error);
        }
    }

    public void DownloadHighScores()
    {
        StartCoroutine("DownloadHighScoresFromDatabase");
    }

    IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/");
        yield return www;

        if (string.IsNullOrEmpty(www.error))
        {
            FormatHighscores(www.text);
            leaderboardDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading " + www.error);
        }

    }

    void FormatHighscores(string text)
    {
        string[] entry = text.Split(new char[] { '\n' }, System.StringSplitOptions.RemoveEmptyEntries);
        highscoresList = new Highscore[entry.Length];

        for (int i = 0; i < entry.Length; i++)
        {
            string[] entryInfo = entry[i].Split(new char[] { '|' });
            string username = entryInfo[0];
            int score = int.Parse(entryInfo[1]);
            highscoresList[i] = new Highscore(username, score);
        }

    }

    public struct Highscore
    {
        public string username;
        public int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }

}
