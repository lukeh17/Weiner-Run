using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;

public class Leaderboard : MonoBehaviour {

    const string privateCode = "LUwKkHKTFECf7JO_qo43CQrZiuxZ1ihEujNnlT5BiPUw";
    const string publicCode = "5abad6a1012b2e1068d3d021";
    const string webURL = "http://dreamlo.com/lb/";

    public Highscore[] highscoresList;
    DisplayLeaderboard leaderboardDisplay;
    private bool _created;

    private void Awake()
    {
        leaderboardDisplay = GetComponent<DisplayLeaderboard>();
    }

    public void AddHighScore()
    {
        var username = PlayerPrefs.GetString("Username");
        var score = PlayerPrefs.GetInt("HighScore", 0);
        StartCoroutine(UploadHighScore(username, score));
    }

    private IEnumerator UploadHighScore(string username, int score)
    {
        WWW www = new WWW(webURL + privateCode + "/add/" + WWW.EscapeURL(username) + "/" + score);
        //UnityWebRequest www = new UnityWebRequest(webURL + privateCode + "/add/" + UnityWebRequest.EscapeURL(username) + "/" + score);
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
        StartCoroutine(nameof(DownloadHighScoresFromDatabase));
    }

    private IEnumerator DownloadHighScoresFromDatabase()
    {
        WWW www = new WWW(webURL + publicCode + "/pipe/" + "9");
        //UnityWebRequest www = UnityWebRequest.Get(webURL + publicCode + "/pipe/");
        
        yield return www;
        
        if (string.IsNullOrEmpty(www.error))
        {
            //FormatHighscores(www.downloadHandler.text);
            FormatHighscores(www.text);
            leaderboardDisplay.OnHighscoresDownloaded(highscoresList);
        }
        else
        {
            print("Error Downloading " + www.error);
        }
    }

    private void FormatHighscores(string text)
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
        private string username;
        public readonly int score;

        public Highscore(string _username, int _score)
        {
            username = _username;
            score = _score;
        }
    }
}
