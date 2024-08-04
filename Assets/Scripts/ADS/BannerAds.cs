using System.Collections;
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class BannerAds : MonoBehaviour
{
    private string _adUnitId = "ca-app-pub-4970995456882391/5810897439";
    public float WaitForSC = 60f;

      BannerView _bannerView;

    // Start is called before the first frame update
    void Start()
    {
         MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            StartCoroutine(showAds());
        });
    }
    public void CreateBannerView()
    {

      // If we already have a banner, destroy the old one.
      if (_bannerView != null)
      {
          DestroyBannerView();
      }
      // Create a 320x50 banner at top of the screen
      _bannerView = new BannerView(_adUnitId, AdSize.Banner, AdPosition.Bottom);
      ListenToAdEvents();
    }
    /// Creates the banner view and loads a banner ad.

    public void LoadAd()  
    {
    // create an instance of a banner view first.
    if(_bannerView == null)
    {
        CreateBannerView();
    }

    // create our request used to load the ad.
    var adRequest = new AdRequest();

    // send the request to load the ad.
    // Create a 320x50 banner views at coordinate (0,50) on screen.
    // _bannerView = new BannerView(_adUnitId, AdSize.Banner, 450, 100);
    _bannerView.LoadAd(adRequest);
    }
        /// listen to events the banner view may raise.

    private void ListenToAdEvents()
    {
        // Raised when an ad is loaded into the banner view.
        _bannerView.OnBannerAdLoaded += () =>
        {
            Debug.Log("Banner view loaded an ad with response : "
                + _bannerView.GetResponseInfo());
        };
        // Raised when an ad fails to load into the banner view.
        _bannerView.OnBannerAdLoadFailed += (LoadAdError error) =>
        {
            Debug.LogError("Banner view failed to load an ad with error : "
                + error);
        };
        // Raised when the ad is estimated to have earned money.
        _bannerView.OnAdPaid += (AdValue adValue) =>
        {
            Debug.Log(string.Format("Banner view paid {0} {1}.",
                adValue.Value,
                adValue.CurrencyCode));
        };
        // Raised when an impression is recorded for an ad.
        _bannerView.OnAdImpressionRecorded += () =>
        {
            Debug.Log("Banner view recorded an impression.");
        };
        // Raised when a click is recorded for an ad.
        _bannerView.OnAdClicked += () =>
        {
            Debug.Log("Banner view was clicked.");
        };
        // Raised when an ad opened full screen content.
        _bannerView.OnAdFullScreenContentOpened += () =>
        {
            Debug.Log("Banner view full screen content opened.");
        };
        // Raised when the ad closed full screen content.
        _bannerView.OnAdFullScreenContentClosed += () =>
        {
            Debug.Log("Banner view full screen content closed.");
        };
    }
    public void DestroyBannerView()
    {
        if (_bannerView != null)
        {
            _bannerView.Destroy();
            _bannerView = null;
        }
    }
    

    // Update is called once per frame
    IEnumerator showAds()
    {
            CreateBannerView();
            LoadAd();
            yield return new WaitForSeconds(WaitForSC);
            DestroyBannerView();

    }
}
