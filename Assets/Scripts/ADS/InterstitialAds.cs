
using UnityEngine;
using GoogleMobileAds;
using GoogleMobileAds.Api;
using System;

public class InterstitialAds : MonoBehaviour
{
      private string _adUnitId = "ca-app-pub-4970995456882391/4856908414";

    private InterstitialAd _interstitialAd;
    // Start is called before the first frame update
    void Start()
    {
        // Initialize the Google Mobile Ads SDK.
        MobileAds.Initialize((InitializationStatus initStatus) =>
        {
            // This callback is called once the MobileAds SDK is initialized.
            LoadLoadInterstitialAd();
            ShowInterstitialAd();
        });
    }

     public void LoadLoadInterstitialAd()
  {
      // Clean up the old ad before loading a new one.
      if (_interstitialAd != null)
      {
            _interstitialAd.Destroy();
            _interstitialAd = null;
      }

      Debug.Log("Loading the interstitial ad.");

      // create our request used to load the ad.
      var adRequest = new AdRequest();

      // send the request to load the ad.
      InterstitialAd.Load(_adUnitId, adRequest,
          (InterstitialAd ad, LoadAdError error) =>
          {
              // if error is not null, the load request failed.
              if (error != null || ad == null)
              {
                  Debug.LogError("interstitial ad failed to load an ad " +
                                 "with error : " + error);
                  return;
              }

              Debug.Log("Interstitial ad loaded with response : "
                        + ad.GetResponseInfo());

              _interstitialAd = ad;
              RegisterEventHandlers(_interstitialAd);
          });

  }
    
    public void ShowInterstitialAd()
{
    if (_interstitialAd != null && _interstitialAd.CanShowAd())
    {
        Debug.Log("Showing interstitial ad.");
        _interstitialAd.Show();
    }
    else
    {
        Debug.LogError("Interstitial ad is not ready yet.");
    }
}
    private void RegisterEventHandlers(InterstitialAd interstitialAd)
{
    // Raised when the ad is estimated to have earned money.
    interstitialAd.OnAdPaid += (AdValue adValue) =>
    {
        Debug.Log(String.Format("Interstitial ad paid {0} {1}.",
            adValue.Value,
            adValue.CurrencyCode));
    };
    // Raised when an impression is recorded for an ad.         
    interstitialAd.OnAdImpressionRecorded += () =>
    {
        Debug.Log("Interstitial ad recorded an impression.");
    };
    // Raised when a click is recorded for an ad.
    interstitialAd.OnAdClicked += () =>
    {
        Debug.Log("Interstitial ad was clicked.");
    };
    // Raised when an ad opened full screen content.
    interstitialAd.OnAdFullScreenContentOpened += () =>
    {
        Debug.Log("Interstitial ad full screen content opened.");
    };
    // Raised when the ad closed full screen content.
    interstitialAd.OnAdFullScreenContentClosed += () =>
    {
        Debug.Log("Interstitial ad full screen content closed.");
        LoadLoadInterstitialAd();
    };
    // Raised when the ad failed to open full screen content.
    interstitialAd.OnAdFullScreenContentFailed += (AdError error) =>
    {
        Debug.LogError("Interstitial ad failed to open full screen content " +
                       "with error : " + error);
        LoadLoadInterstitialAd();

    };
}
    
    void Update()
    {
        
    }
}
