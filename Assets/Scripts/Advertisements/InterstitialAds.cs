using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Advertisements;

public class InterstitialAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
#if UNITY_IOS
    string InterstitialID = "Interstitial_iOS";
#else
    string InterstitialID = "Interstitial_Android";
#endif
    [SerializeField] RewardRequest rewardRequest;
    public bool loaded;
    [SerializeField] AudioManager audioManager;
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + InterstitialID);
        Advertisement.Load(InterstitialID, this);
        OnUnityAdsAdLoaded(InterstitialID);
    }

    public void ShowAd()
    {
        Debug.Log("Showing Ad: " + InterstitialID);
        Advertisement.Show(InterstitialID, this);
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        // Optionally execute code if the Ad Unit successfully loads content.
        loaded = true;
    }

    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit: {adUnitId} - {error.ToString()} - {message}");
        rewardRequest.FailedToLoadAd();
        // Optionally execute code if the Ad Unit fails to load, such as attempting to try again.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        rewardRequest.FailedToLoadAd();
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        // Optionally execute code if the Ad Unit fails to show, such as loading another ad.
    }
    public void OnUnityAdsShowStart(string adUnitId)
    {
        audioManager.Pause();
    }
    public void OnUnityAdsShowClick(string adUnitId)
    {

    }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if(adUnitId == InterstitialID)
            rewardRequest.Restart();
        loaded = false;
        audioManager.Play();
    }
}