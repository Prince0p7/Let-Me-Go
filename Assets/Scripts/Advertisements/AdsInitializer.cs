using UnityEngine;
using UnityEngine.Advertisements;

public class AdsInitializer : MonoBehaviour, IUnityAdsInitializationListener
{
#if UNITY_IOS
    string GameID = "4862450";
#else
    string GameID = "4862451";
#endif
    [SerializeField] bool testMode = true;
    [SerializeField] InterstitialAds interstitialAds;
    [SerializeField] RewardedAds rewardedAds;
    [SerializeField] CheckingInternetConnection connection;
    public bool gamePauseForLoading;
    void Start()
    {
        InvokeRepeating("Initialize", 0.1f, 1);
    }
    public void Initialize()
    {
        if (connection.connectionAvailable)
        {
            if (!Advertisement.isInitialized)
            {
                gamePauseForLoading = true;
                Advertisement.Initialize(GameID, testMode, this);
                if (!interstitialAds.loaded) interstitialAds.LoadAd();
                if (!rewardedAds.loaded) rewardedAds.LoadAd();
            }
        }
    }
    public void OnInitializationComplete()
    {
        Debug.Log("Unity Ads initialization complete.");
        gamePauseForLoading = false;
    }
    public void OnInitializationFailed(UnityAdsInitializationError error, string message)
    {
        Debug.Log($"Unity Ads Initialization Failed: {error.ToString()} - {message}");
    }
}