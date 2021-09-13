using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class AdsManager : MonoBehaviour, IUnityAdsListener
{
    private string gameId = "4196836";
    string mySurfacingId = "Rewarded_Android";
    bool testMode = false;  // set to false to view actual ads
    public PlayerMovement pmmm;
    void Start()
    {
        Advertisement.AddListener(this);
        // Initialize the Ads service:
        Advertisement.Initialize(gameId, testMode);
    }
    public void ShowInterstitialAd()
    {
        Debug.Log(string.Format("Platform is {0}supported\nUnity Ads {1}initialized", Advertisement.isSupported ? "" : "not ", Advertisement.isInitialized ? "" : "not "));
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady("Interstitial_Android"))
     {
        Advertisement.Show("Interstitial_Android");
        // Replace mySurfacingId with the ID of the placements you wish to display as shown in your Unity Dashboard.
     }
    else
     {
        Debug.Log("Interstitial ad not ready at the moment! Please try again later!");
     }
    }

    public void ShowRewardedVideo()
    {
        Debug.Log(string.Format("Platform is {0}supported\nUnity Ads {1}initialized", Advertisement.isSupported ? "" : "not ", Advertisement.isInitialized ? "" : "not "));
        // Check if UnityAds ready before calling Show method:
        if (Advertisement.IsReady(mySurfacingId))
        {
            Advertisement.Show(mySurfacingId);
        }
        else
        {
            Debug.Log("Rewarded video is not ready at the moment! Please try again later!");
        }
    }
    public void ShowBanner()
    {
        //Debug.Log(string.Format("Platform is {0}supported\nUnity Ads {1}initialized", Advertisement.isSupported ? "" : "not ", Advertisement.isInitialized ? "" : "not "));
        if (Advertisement.IsReady("Banner_Android"))
        {
            Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
            Advertisement.Banner.Show("Banner_Android");
            Debug.Log("Banner function accessed");

        }
        else
        {
            StartCoroutine(RepeatShowBanner());
        }
    }

    IEnumerator RepeatShowBanner()
    {
        yield return new WaitForSeconds(0.5f);
        ShowBanner();
    }

    public void HideBanner()
    {
        Advertisement.Banner.Hide();
    }
    public void InitialiseAd()
    {
        Advertisement.Initialize(gameId, testMode);
        Debug.Log(string.Format("Platform is {0}supported\nUnity Ads {1}initialized", Advertisement.isSupported ? "" : "not ", Advertisement.isInitialized ? "" : "not "));
    }
    // Implement IUnityAdsListener interface methods:
    public void OnUnityAdsDidFinish(string surfacingId, ShowResult showResult)
    {
        // Define conditional logic for each ad completion status:
        if (showResult == ShowResult.Finished)
        {
            pmmm.Revive();
        }
        else if (showResult == ShowResult.Skipped)
        {
            pmmm.ReloadLevel();
        }
        else if (showResult == ShowResult.Failed)
        {
            pmmm.ReloadLevel();
        }
    }

    public void OnUnityAdsReady(string surfacingId)
    {
        // If the ready Ad Unit or legacy Placement is rewarded, show the ad:
        if (surfacingId == mySurfacingId)
        {
            // Optional actions to take when theAd Unit or legacy Placement becomes ready (for example, enable the rewarded ads button)
        }
    }

    public void OnUnityAdsDidError(string message)
    {
        // Log the error.
    }

    public void OnUnityAdsDidStart(string surfacingId)
    {
        // Optional actions to take when the end-users triggers an ad.
    }

    // When the object that subscribes to ad events is destroyed, remove the listener:
    public void OnDestroy()
    {
        Advertisement.RemoveListener(this);
    }
}
