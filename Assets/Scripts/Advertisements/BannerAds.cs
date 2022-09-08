using UnityEngine;
using UnityEngine.Advertisements;

public class BannerAds : MonoBehaviour
{
#if UNITY_IOS
    string BannerID = "Banner_iOS";
#else
    string BannerID = "Banner_Android";
#endif
    public bool loaded;
    void Start()
    {
        Initialize();   
    }
    void Initialize()
    {
        Advertisement.Banner.SetPosition(BannerPosition.BOTTOM_CENTER);
    }
    public void LoadBanner()
    {
        // Load the Ad Unit with banner content:
        Advertisement.Banner.Load(BannerID);
        OnBannerLoaded();
    }
    void OnBannerLoaded()
    {
        Debug.Log("Banner loaded");
        ShowBannerAd();
        loaded = true;
    }
    void OnBannerError(string message)
    {
        Debug.Log($"Banner Error: {message}");
        // Optionally execute additional code, such as attempting to load another ad.
    }
    public void ShowBannerAd()
    {
        // Set up options to notify the SDK of show events:
        BannerOptions options = new BannerOptions
        {
            clickCallback = OnBannerClicked,
            hideCallback = OnBannerHidden,
            showCallback = OnBannerShown
        };

        // Show the loaded Banner Ad Unit:
        Advertisement.Banner.Show(BannerID, options);
    }
    public void HideBannerAd()
    {
        // Hide the banner:
        Advertisement.Banner.Hide();
    }

    void OnBannerClicked() { }
    void OnBannerShown() { }
    void OnBannerHidden() { }
}