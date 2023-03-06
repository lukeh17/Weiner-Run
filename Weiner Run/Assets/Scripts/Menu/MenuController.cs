using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Networking;
using Random = UnityEngine.Random;

public class MenuController : MonoBehaviour
{
    #region variables
    public GameObject SoundOn;
    public GameObject SoundOff;
    private const string PublicCode = "5abad6a1012b2e1068d3d021";
    private const string WebUrl = "http://dreamlo.com/lb/";
    private string username;
    const string characters = "abcdefghijklmnopqrstuvwxyz0123456789";
    #endregion
    
    private void Start()
    {
        if (PlayerPrefs.HasKey("Username")) return;
        PlayerPrefs.SetInt("0", 1); //Sets the regular weiner to be bought;
        PlayerPrefs.DeleteKey("Username");
        Generate();
    }

    private void Generate()
    {
        var charAmount = Random.Range(5, 25); 
        
        for (var i = 0; i < charAmount; i++)
        {
            username += characters[Random.Range(0, characters.Length)];
        }
        PlayerPrefs.SetString("Username", username);
        CheckUser();
    }

    private void CheckUser()
    {
        StartCoroutine(nameof(Check));
    }

    private IEnumerator Check()
    {
        var user = PlayerPrefs.GetString("Username");
        UnityWebRequest uwr = UnityWebRequest.Get(WebUrl + PublicCode + "/pipe-get/" + user);
        yield return uwr;
        
        if (string.IsNullOrEmpty(uwr.error))
        {
            CheckString(uwr.downloadHandler.text);
        }
        else
        {
            print("Error Downloading " + uwr.error);
        }
    }

    private void CheckString(string w)
    {
        if (w == "")
        {
            //Debug.Log("Valid Username: " + username);
        }
        else
        {
            //Debug.Log("Invalid username restarting: " + username);
            Generate();
        }
    }
    
    public void CheckButton()
    {
        var a = PlayerPrefs.GetInt("Pause", 1);
        if (a != 0) return;
        SoundOn.SetActive(false);
        SoundOff.SetActive(true);
    }
}
