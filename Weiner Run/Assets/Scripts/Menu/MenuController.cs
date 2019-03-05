using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuController : MonoBehaviour {

    const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";

    private int score;
    private string username;

    void Start()
    {
        PlayerPrefs.SetInt("0", 1); //Sets the regular weiner to be bought;
        
        if (!PlayerPrefs.HasKey("Username"))
        {
            PlayerPrefs.DeleteKey("Username");
            Generate(); 
        }
        

        username = PlayerPrefs.GetString("Username");
        score = PlayerPrefs.GetInt("HighScore", 0);
        
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
