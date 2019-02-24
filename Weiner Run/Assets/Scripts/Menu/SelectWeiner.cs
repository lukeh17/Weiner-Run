using System.Collections;
using System.Collections.Generic;
using CollabProxy.UI;
using UnityEngine;
using UnityEngine.UI;

public class SelectWeiner : MonoBehaviour
{
    
    #region Variables
    public GameObject[] Weiners;
    public Image[] WeinerParts;
    public Sprite red;
    public Sprite white;
    public Sprite redFoot;
    public Sprite boot;
    private readonly Color greyColor = new Color32(70,70,70,255);
    #endregion

    private void Start()
    {
        var w = PlayerPrefs.GetInt("Weiner", 0);
        switch (w)
        {
            case 0:
                ShowRegular();
                break;
            case 1:
                ShowSpace();
                break;
            case 2:
                ShowHisp();
                break;
            case 3:
                ShowFancy();
                break;
            default:
                ShowRegular();
                break;
        }
    }
    
    public void SelectByNumber(int i)
    {
        PlayerPrefs.SetInt("Weiner", i);
    }

    private void Deactivate()
    {
        Weiners[0].SetActive(false);
        Weiners[1].SetActive(false);
        Weiners[2].SetActive(false);
    }

    public void ShowRegular()
    {
        Deactivate();
        foreach (var t in WeinerParts)
        {
            t.sprite = red;
            t.color = Color.white;
        }
        WeinerParts[9].sprite = redFoot;
        WeinerParts[8].sprite = redFoot;
    }
    
    public void ShowHisp()
    {
        Deactivate();
        Weiners[0].SetActive(true);
        foreach (var t in WeinerParts)
        {
            t.sprite = red;
            t.color = Color.white;
        }
        WeinerParts[9].sprite = redFoot;
        WeinerParts[8].sprite = redFoot;
    }

    public void ShowFancy()
    {
        Deactivate();
        Weiners[2].SetActive(true);
        foreach (var t in WeinerParts)
        {
            t.sprite = white;
            t.color = greyColor;
        }
        WeinerParts[9].sprite = boot;
        WeinerParts[8].sprite = boot;
    }

    public void ShowSpace()
    {
        Deactivate();
        Weiners[1].SetActive(true);
        foreach (var t in WeinerParts)
        {
            t.sprite = white;
            t.color = Color.white;
        }
        WeinerParts[8].sprite = boot;
        WeinerParts[9].sprite = boot;
    }
}
