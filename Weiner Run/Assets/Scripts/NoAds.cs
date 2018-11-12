using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NoAds : MonoBehaviour {

    public GameObject NoAdsButton;
    public GameObject BoughtButton;

    public void CheckNoAdsButton()
    {
       int a = PlayerPrefs.GetInt("Ads");
        if (a == 1)
        {
            NoAdsButton.SetActive(false);
            BoughtButton.SetActive(true);
        }
        else
            return;
    }

}
