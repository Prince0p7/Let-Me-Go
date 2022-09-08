using UnityEngine;

public class RewardRequest : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Player player;
    [SerializeField] Reset reset;
    [SerializeField] InterstitialAds interstitialAds;
    [SerializeField] RewardedAds rewardedAds;
    bool restarting;
    bool rewardRequested;
    bool adFailedToLoad;
    int showAdOnExit;
    void Awake()
    {

        restarting = false;
        reset.chanceNo = 0;
    }
    void Update()
    {
        RestartGame();
    }
    void RestartGame()
    {
        if (!rewardRequested || adFailedToLoad || reset.chanceNo > 1)
        {
            if (restarting)
                UnityEngine.SceneManagement.SceneManager.LoadScene(UnityEngine.SceneManagement.SceneManager.GetActiveScene().name);
        }
    }
    public void PlayerResponse(bool requested)
    {
        rewardRequested = requested;
        reset.continueScreen.SetActive(false);
        if (requested)
        {
            rewardedAds.ShowAd();
        }
        else
        {
            showAdOnExit = Random.Range(0, 10);
            if (showAdOnExit == 2)
            {
                interstitialAds.ShowAd();
            }
            else
            {
                Restart();
            }
        }
    }
    public void CollectingReward()
    {
        restarting = false;
        reset.chanceNo++;
        Time.timeScale = 1;
        player.animator[0].enabled = false;
        player.animator[1].enabled = false;
        player.transform.position = new Vector3(transform.position.x, transform.position.y - 10);
        player.animator[0].enabled = true;
        player.animator[1].enabled = true;
        if (!player.diedByCamera)
        {
            player.platformNo--;
        }
        reset.adRequested = false;
        reset.ResetPlayer();
    }
    public void Restart()
    {
        if (reset.isLost)
        {
            restarting = true;
        }
    }
    public void FailedToLoadAd()
    {
        adFailedToLoad = true;
        restarting = true;
        Restart();
    }
}