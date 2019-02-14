using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    //public GameObject leaderboard;
    const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

    private int score;
    private string username;

    void Start()
    {
        //AdManager.ShowBanner();

        if (!PlayerPrefs.HasKey("Username"))
        {
            PlayerPrefs.DeleteKey("Username");
            Generate(); 
        }
        

        username = PlayerPrefs.GetString("Username");
        score = PlayerPrefs.GetInt("HighScore", 0);
        
        //leaderboard.GetComponent<Leaderboard>().AddHighScore(username, score);
    }

    public void Generate()
    {
        int charAmount = Random.Range(2, 12); 
        for (int i = 0; i < charAmount; i++)
        {
            username += characters[Random.Range(0, characters.Length)];
        }
        Debug.Log("Username: " + username);
        PlayerPrefs.SetString("Username", username);
    }

}
