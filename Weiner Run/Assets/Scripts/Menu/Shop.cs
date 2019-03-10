using System;
using System.Collections;
using System.Collections.Generic;
using System.Net.Mime;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    #region Variables
    //Weiner 0 is regular weiner
    public Image[] SpaceWeiner; //1
    public Image[] HispWeiner; //2
    public Image[] FancyWeiner; //3
    
    public GameObject[] Weiners;
    public Image[] WeinerParts;
    public Sprite red;
    public Sprite white;
    public Sprite redFoot;
    public Sprite boot;
    public GameObject[] prices;
    private readonly Color greyColor = new Color32(70,70,70,255);
    public Text PicklesText;
    #endregion

    private void Start()
    {
        PlayerPrefs.SetInt("0", 1);
        
        ChooseWeiner(PlayerPrefs.GetInt("Weiner", 0));
        
        for (var i = 1; i < 4; i++)
        {
            if (!CheckBought(i)) continue;
            switch (i)
            {
                case 1:
                    prices[0].SetActive(false);
                    UndarkWeiner(SpaceWeiner);
                    break;
                case 2:
                    prices[1].SetActive(false);
                    UndarkWeiner(HispWeiner);
                    break;
                case 3:
                    prices[2].SetActive(false);
                    UndarkWeiner(FancyWeiner);
                    break;
            }
        }
    }

    public void OnClick(int i)
    {
        if (CheckBought(i) == false)
        {
            BuyWeiner(i);
        }

        if (CheckBought(i))
        {
            ChooseWeiner(i);
        }
    }

    private void ChooseWeiner(int i)
    {
        switch (i)
        {
           case 0: //Regular weiner
               ShowCustomization(redFoot, red, Color.white);
               PlayerPrefs.SetInt("Weiner", i);
               break;
           
           case 1: //Space weiner
               ShowCustomization(boot, white, Color.white);
               PlayerPrefs.SetInt("Weiner", i);
               Weiners[1].SetActive(true);
               break;
           
           case 2: //spa weiner
               ShowCustomization(redFoot, red, Color.white);
               PlayerPrefs.SetInt("Weiner", i);
               Weiners[0].SetActive(true);
               break;
           
           case 3: //Fancy weiner
               ShowCustomization(boot, white, greyColor);
               PlayerPrefs.SetInt("Weiner", i);
               Weiners[2].SetActive(true);
               break;
        }
    }

    private static bool CheckBought(int i)
    {
        return PlayerPrefs.GetInt(i.ToString(), 0) == 1; //1 is bought
    }
    
    private void BuyWeiner(int i)
    {
        if (!CheckPickles(i)) return;
        switch (i)
        {
            case 1:
                UpdatePicklesAmount(200);
                ChooseWeiner(1);
                UndarkWeiner(SpaceWeiner);
                PlayerPrefs.SetInt("1", 1);
                prices[0].SetActive(false);
                break;
            case 2:
                UpdatePicklesAmount(300);
                ChooseWeiner(2);
                UndarkWeiner(HispWeiner);
                PlayerPrefs.SetInt("2", 1);
                prices[1].SetActive(false);
                break;
            case 3:
                UpdatePicklesAmount(450);
                ChooseWeiner(3);
                UndarkWeiner(FancyWeiner);
                PlayerPrefs.SetInt("3", 1);
                prices[2].SetActive(false);
                break;
            default:
                return; 
        }
    }

    private static void UndarkWeiner(IEnumerable<Image> w)
    {
        foreach (var s in w)
        {
            s.color = Color.white;
        }
    }

    private void ShowCustomization(Sprite foot, Sprite arm, Color col)
    {
        Deactivate();
        foreach (var t in WeinerParts)
        {
            t.sprite = arm;
            t.color = col;
        }
        
        WeinerParts[8].sprite = foot;
        WeinerParts[9].sprite = foot;
    }
    
    private void Deactivate()
    {
        Weiners[0].SetActive(false);
        Weiners[1].SetActive(false);
        Weiners[2].SetActive(false);
    }

    private static bool CheckPickles(int i)
    {
        var pickles = PlayerPrefs.GetInt("Pickles", 0);
        switch (i)
        {
            case 1:
                return pickles > 200; 
            case 2:
                return pickles > 350; 
            case 3:
                return pickles > 450; 
            default:
                return false;
        }
    }

    private void UpdatePicklesAmount(int p)
    {
        var pickles = PlayerPrefs.GetInt("Pickles", 0);
        pickles -= p;
        PlayerPrefs.SetInt("Pickles", pickles);
        UpdatePicklesText();
    }

    public void UpdatePicklesText()
    {
        PicklesText.text = PlayerPrefs.GetInt("Pickles", 0).ToString();
    }
}
