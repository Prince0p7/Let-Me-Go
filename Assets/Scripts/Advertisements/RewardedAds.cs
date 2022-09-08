using UnityEngine;
using UnityEngine.Advertisements;

public class RewardedAds : MonoBehaviour, IUnityAdsLoadListener, IUnityAdsShowListener
{
#if UNITY_IOS
    string RewardedID = "Rewarded_iOS";
#else
    string RewardedID = "Rewarded_Android";
#endif
    [SerializeField] RewardRequest rewardRequest;
    public bool loaded;
    [SerializeField] AudioManager audioManager;
    public void LoadAd()
    {
        Debug.Log("Loading Ad: " + RewardedID);
        Advertisement.Load(RewardedID, this);
        OnUnityAdsAdLoaded(RewardedID);
    }
    public void OnUnityAdsAdLoaded(string adUnitId)
    {
        Debug.Log("Ad Loaded: " + adUnitId);
        loaded = true;
    }
    public void ShowAd()
    {
        // Then show the ad:
        Advertisement.Show(RewardedID, this);
    }
    public void OnUnityAdsShowComplete(string adUnitId, UnityAdsShowCompletionState showCompletionState)
    {
        if (adUnitId.Equals(RewardedID) && showCompletionState.Equals(UnityAdsShowCompletionState.COMPLETED))
        {
            Debug.Log("Unity Ads Rewarded Ad Completed");
            // Grant a reward.
            rewardRequest.CollectingReward();
            audioManager.Play();
            loaded = false;
        }
    }
    public void OnUnityAdsFailedToLoad(string adUnitId, UnityAdsLoadError error, string message)
    {
        Debug.Log($"Error loading Ad Unit {adUnitId}: {error.ToString()} - {message}");
        rewardRequest.FailedToLoadAd();
        // Use the error details to determine whether to try to load another ad.
    }

    public void OnUnityAdsShowFailure(string adUnitId, UnityAdsShowError error, string message)
    {
        Debug.Log($"Error showing Ad Unit {adUnitId}: {error.ToString()} - {message}");
        rewardRequest.FailedToLoadAd();
        // Use the error details to determine whether to try to load another ad.
    }
    public void OnUnityAdsShowStart(string adUnitId)
    {
        audioManager.Pause();
    }
    public void OnUnityAdsShowClick(string adUnitId)
    {

    }
}