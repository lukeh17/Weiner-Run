using System;
using System.Collections;
using System.Collections.Generic;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using UnityEngine;

public class AdScript : MonoBehaviour, IRewardedVideoAdListener
{
    #region set up
    public static AdScript _as;
    public GameObject NoMoreAds;
    
    private void Awake()
    {
        _as = this;
    }

    #if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
            private const string AppKey = "";
    
        #elif UNITY_ANDROID
            private const string AppKey = "422478dd5be1151877f413c97d2977b6abd7a5d7e69ff967";
            
        #elif UNITY_IPHONE
             private const string AppKey = "";
    
        #else
            private const string AppKey = "";
    #endif
    #endregion
    
    private void Start()
    {
        Appodeal.initialize(AppKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        Appodeal.setTesting(true); //Set to false on published build
        
        Appodeal.disableLocationPermissionCheck();
    }
    
    public void ShowInterstitial() {
        if(Appodeal.isLoaded(Appodeal.INTERSTITIAL) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL)) {
            Appodeal.show (Appodeal.INTERSTITIAL);
        } else {
            Appodeal.cache(Appodeal.INTERSTITIAL);
        }
    }
    
    public void ShowRewardedVideo() {
        if(Appodeal.canShow(Appodeal.REWARDED_VIDEO)) {
            Appodeal.show (Appodeal.REWARDED_VIDEO);
        }
    }

    #region Rewarded Videos
    public void onRewardedVideoClosed(bool finished) { }
    public void onRewardedVideoExpired() { }
    public void onRewardedVideoShown() { }
    public void onRewardedVideoLoaded(bool precache) { }
    public void onRewardedVideoFailedToLoad()
    {
        StartCoroutine(nameof(NoAdsText));
    }
    public void onRewardedVideoFinished(double amount, string cname)
    {
        var p = PlayerPrefs.GetInt("Pickles", 0);
        p += 25;
        PlayerPrefs.SetInt("Pickles", p);
    }

    private IEnumerator NoAdsText()
    {
        NoMoreAds.SetActive(true);
        yield return new WaitForSeconds(1.5f);
        NoMoreAds.SetActive(false);
    }
    #endregion
}
