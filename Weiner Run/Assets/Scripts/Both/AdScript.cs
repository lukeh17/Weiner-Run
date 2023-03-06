using System;
using System.Collections;
using AppodealStack.Monetization.Api;
using AppodealStack.Monetization.Common;
using UnityEngine;
using UnityEngine.Serialization;

namespace Both
{
    public class AdScript : MonoBehaviour
    {
        #region set up
        public static AdScript _as;
        [FormerlySerializedAs("NoMoreAds")] public GameObject noMoreAds;
    
        private void Awake()
        {
            _as = this;
        }

#if UNITY_EDITOR && !UNITY_ANDROID && !UNITY_IPHONE
            private const string AppKey = "";
    
#elif UNITY_ANDROID
        private const string AppKey = "dc52c1829cf0baebde7f78f07343f8b21965cf1f00ca9734";
        
#elif UNITY_IPHONE
             private const string AppKey = "";
    
#else
            private const string AppKey = "";
#endif
        #endregion
    
        private void Start()
        {
            Appodeal.Initialize(AppKey, AppodealAdType.Interstitial | AppodealAdType.RewardedVideo);
            Appodeal.SetTesting(true); //Set to false on published build
        
            Appodeal.SetLocationTracking(false);
        }
    
        public static void ShowInterstitial() {
            if(Appodeal.IsLoaded(AppodealAdType.Interstitial) && !Appodeal.IsPrecache(AppodealAdType.Interstitial)) {
                Appodeal.Show(AppodealAdType.Interstitial);
            } else {
                Appodeal.Cache(AppodealAdType.Interstitial);
            }
        }
    
        public void ShowRewardedVideo() {
            if(Appodeal.CanShow(AppodealAdType.RewardedVideo)) {
                Appodeal.Show(AppodealAdType.RewardedVideo);
            }
        }

        #region Rewarded Videos
        public void onRewardedVideoClosed(bool finished) { }
        public void onRewardedVideoExpired() { }
        public void onRewardedVideoClicked() { }
        public void onRewardedVideoShowFailed()
        {
            StartCoroutine(nameof(NoAdsText));
        }

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
            noMoreAds.SetActive(true);
            yield return new WaitForSeconds(1.5f);
            noMoreAds.SetActive(false);
        }
        #endregion
    }
}
