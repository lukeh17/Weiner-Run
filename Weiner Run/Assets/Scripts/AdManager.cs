using UnityEngine;
using AppodealAds.Unity.Api;
using AppodealAds.Unity.Common;
using System.Collections;

public class AdManager : MonoBehaviour, IRewardedVideoAdListener
{
    
    public GameObject menu1;
    public GameObject menu2;

    public static int timesTriedToShowInterstitial = 0;

    // Use this for initialization
    void Start()
    {
        int a = PlayerPrefs.GetInt("Ads", 0);

        string appKey = "422478dd5be1151877f413c97d2977b6abd7a5d7e69ff967"; //Google Play
        //string appKey = "dc52c1829cf0baebde7f78f07343f8b21965cf1f00ca9734"; //Amazon
        Appodeal.disableLocationPermissionCheck();
        Appodeal.setTesting(false);

        if (a == 0)
        {
            Appodeal.initialize(appKey, Appodeal.INTERSTITIAL | Appodeal.REWARDED_VIDEO);
        }
        else
        Appodeal.initialize(appKey, Appodeal.REWARDED_VIDEO);

        Appodeal.setRewardedVideoCallbacks(this);
    }


    public static void ShowInterstitial()
    {

        if (PlayerPrefs.GetInt("Ads") == 0)
        {
            if (Appodeal.isLoaded(Appodeal.INTERSTITIAL) && !Appodeal.isPrecache(Appodeal.INTERSTITIAL))
            {
                timesTriedToShowInterstitial++;
                if (timesTriedToShowInterstitial == 4)
                {
                    Appodeal.show(Appodeal.INTERSTITIAL);
                    timesTriedToShowInterstitial = 0;
                }
            }
            else
            {
                timesTriedToShowInterstitial++;
                if (timesTriedToShowInterstitial == 4)
                {
                    Appodeal.cache(Appodeal.INTERSTITIAL);
                    timesTriedToShowInterstitial = 0;
                }
            }
        }
        else
            return;
    }

    public void ShowRewarded()
    {
        if (Appodeal.isLoaded(Appodeal.REWARDED_VIDEO))
        {
            Appodeal.show(Appodeal.REWARDED_VIDEO);            
        }
    }

    public GameObject NoMoreAds;

    IEnumerator NoMore()
    {
        NoMoreAds.SetActive(true);
        yield return new WaitForSeconds(3);
        NoMoreAds.SetActive(false);
    }

    public void onRewardedVideoLoaded() { }
    public void onRewardedVideoFailedToLoad()
    {
        StartCoroutine(NoMore());
    }
    public void onRewardedVideoShown() { }
    public void onRewardedVideoFinished(int a, string n)
    {
        ShopScript.Instance.AddPickles();
        ShopScript.Instance.UpdatePickles(); 
    }

    public void onRewardedVideoClosed(bool finished) { }
        
            
        
}
