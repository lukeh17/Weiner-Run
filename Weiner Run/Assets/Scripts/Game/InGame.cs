using System.Collections;
using System.Collections.Generic;
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

    private void Start()
    {
        ObjectSpawn._os.SpawnGrass();
        ObjectSpawn._os.SpawnCondiment();
    }

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

        BackgroundMove.Enabled = false;
    }
    
    public void PlayerScored()
    {
        score++;
        UpdateText();
    }

    public void UpdateText()
    {
        int p = PlayerPrefs.GetInt("Pickles", 0);
        scoreText.text = "Score: " + score;
        pickleText.text = p.ToString();
    }

}
