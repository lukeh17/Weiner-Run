using System.Collections;
using System.Collections.Generic;
using Both;
using UnityEngine;
using UnityEngine.UI;

public class InGame : MonoBehaviour
{
    #region variables
    public GameObject[] UI;
    public Text scoreText;
    public Text pickleText;
    
    [HideInInspector]
    public int score = 0;
    #endregion
    
    #region instance
    public static InGame _IG;

    private void Awake()
    {
        _IG = this;
    }
    #endregion

    public void GameOver()
    {
        for (int i = 0; i < 3; i++)
        {
            UI[i].SetActive(true);
        }
        UI[4].SetActive(false);
        Destroy(gameObject.GetComponent<ObjectSpawn>());
        
        if (score > PlayerPrefs.GetInt ("HighScore", 0)) 
        {
            PlayerPrefs.SetInt ("HighScore", score);
            UI[3].SetActive (true);
        }
        
        PowerUp._PU.HideFire();
        Player.moveSpeed = 0f;
        BackgroundMove.Enabled = false;
        ShowAd();
    }
    
    public void PlayerScored()
    {
        score++;
        UpdateText();
    }

    private static void ShowAd()
    {
        var adShown = PlayerPrefs.GetInt("ad", 0);
        if (adShown > 6)
        {
            adShown = 0;
            PlayerPrefs.SetInt("ad", adShown);
            AdScript._as.ShowInterstitial();
        }

        adShown++;
        PlayerPrefs.SetInt("ad", adShown);
    }

    public void UpdateText()
    {
        int p = PlayerPrefs.GetInt("Pickles", 0);
        scoreText.text = "Score: " + score;
        pickleText.text = p.ToString();
    }

}
