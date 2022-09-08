using UnityEngine;

public class LoadAds : MonoBehaviour
{
    [SerializeField] InterstitialAds interstitialAds;
    [SerializeField] RewardedAds rewardedAds;
    [SerializeField] CheckingInternetConnection connection;
    void Start()
    {
        InvokeRepeating("LoadingAds", .5f, 1);
    }
    void LoadingAds()
    {
        if (!connection.connectionAvailable)
            return;

        if (!interstitialAds.loaded)
        {
            interstitialAds.LoadAd();
            Debug.Log("Interstitial Ad Loaded");
        }
        if (!rewardedAds.loaded)
        {
            rewardedAds.LoadAd();
            Debug.Log("Rewarded Ad Loaded");
        }
    }
}