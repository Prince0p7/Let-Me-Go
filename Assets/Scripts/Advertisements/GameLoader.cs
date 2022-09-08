using UnityEngine;
using UnityEngine.Advertisements;
public class GameLoader : MonoBehaviour
{
    [SerializeField] InterstitialAds interstitialAds;
    [SerializeField] RewardedAds rewardedAds;
    [SerializeField] StartScreen startScreen;
    bool loaded;
    [SerializeField] CheckingInternetConnection connection;
    void FixedUpdate()
    {
        if (!loaded)
        {
            if (connection._checked)
            {
                if (connection.connectionAvailable)
                    CanLoadWithAds();
                else
                    CanLoadWithoutAds();
            }
        }
    }
    void CanLoadWithAds()
    {
        if (Advertisement.isInitialized)
        {
            if (rewardedAds.loaded && interstitialAds.loaded)
            {
                startScreen.StartGame();
                loaded = true;
            }
        }
    }
    void CanLoadWithoutAds()
    {
        startScreen.StartGame();
        loaded = true;
    }
}