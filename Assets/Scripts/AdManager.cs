/*using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GoogleMobileAds.Api;*/

/*public class AdManager : MonoBehaviour
{
    public string appId;
    public string adBannerId;
    public string adInterstitialId;
    public AdPosition bannerPosition;

    private bool testDevice = false;

    private BannerView _bannerView;
    private InterstitialAd _interstitial;
    public static AdManager Instance;

    public void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(this);
        }
        else
        {
            Destroy(this);
        }
    }

    void Start()
    {
        MobileAds.Initialize(initStatus => { });
        CreateBanner(CreateRequest());
        CreateInterstitialAd(CreateRequest());
    }

    private AdRequest CreateRequest()
    {
        AdRequest request;

        if (testDevice)
        {
            request = new AdRequest.Builder().AddTestDevice(AdRequest.TestDeviceSimulator).Build();
        }
        else
        {
            request = new AdRequest.Builder().Build();
        }

        return request;
    }

    public void CreateInterstitialAd(AdRequest request)
    {
        this._interstitial = new InterstitialAd(adInterstitialId);
       // this._interstitial.OnAdLoaded += HandleOnAdLoaded;
        ///this._interstitial.OnAdFailedToLoad += HandleOnAdFailedToLoad;
        //this._interstitial.OnAdOpening += HandleOnAdOpened;
       // this._interstitial.OnAdClosed += HandleOnAdClosed;
       // this._interstitial.OnAdLeavingApplication += HandleOnAdLeavingApplication;
        this._interstitial.LoadAd(request);
    }

    public void ShowInterstitialAd()
    {
        if (this._interstitial.IsLoaded())
        {
            this._interstitial.Show();
        }
    }

    public void CreateBanner(AdRequest request)
    {
        this._bannerView = new BannerView(adBannerId, AdSize.SmartBanner, bannerPosition);
        this._bannerView.LoadAd(request);
        HideBanner();
    }

    public void HideBanner()
    {
        _bannerView.Hide();
    }

    public void ShowBanner()
    {
        _bannerView.Show();
    }

    // Handle events for Interstitial Ads
   // public void HandleOnAdLoaded(object sender, EventArgs args)
   //// {
    //    MonoBehaviour.print("HandleAdLoaded event received");
   // }

   // public void HandleOnAdFailedToLoad(object sender, AdFailedToLoadEventArgs args)
    //{
    //    MonoBehaviour.print("HandleFailedToReceiveAd event received with message: " + args.Message);
   // }

  //  public void HandleOnAdOpened(object sender, EventArgs args)
   // {
    //    MonoBehaviour.print("HandleAdOpened event received");
    //}

   // public void HandleOnAdClosed(object sender, EventArgs args)
   // {
   //    MonoBehaviour.print("HandleAdClosed event received");
    //}

    //public void HandleOnAdLeavingApplication(object sender, EventArgs args)
    //{
       // MonoBehaviour.print("HandleAdLeavingApplication event received");
    //}
}
*/