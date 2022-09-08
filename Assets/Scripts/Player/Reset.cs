using UnityEngine;
using RDG;

public class Reset : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerFollow playerFollow;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] Play play;
    [SerializeField] UIManager uIManager;
    [SerializeField] InterstitialAds interstitialAds;
    [SerializeField] SpriteRenderer spriteRenderer;
    [SerializeField] CheckingInternetConnection connection;
    [SerializeField] RewardRequest rewardRequest;
    public GameObject continueScreen;
    [HideInInspector] public int chanceNo;
    [HideInInspector] public bool adRequested;
    [HideInInspector] public bool isLost;
    public Vector3 currentPosition;
    bool canPresentContinueText;
    [SerializeField] Animator[] continueAnimators;
    [SerializeField] ContinueTextCheck[] continueTextChecks;
    [SerializeField] Animator SpeedAnimator;
    [SerializeField] Animator NoThanksAnimator;
    [SerializeField] Animator LimitAnimator;
    [SerializeField] Animator WaveAnimator;
    void Start()
    {
        currentPosition = transform.position;
        continueScreen.SetActive(false);
        adRequested = false;
        WaveAnimator.SetFloat("Speed", 2);
    }
    void Update()
    {
        if(canPresentContinueText)
            TextPresentation();
    }
    public void ResetGame()
    {
        if (!isLost)
        {
            scoreManager.TotalScore += scoreManager.addScore.currentScore;
            scoreManager.addScore.currentScore = 0;
            scoreManager.HighScoreCount();
            play.gameStarted = false;
            playerFollow.cameraStarted = false;
            scoreManager.saveAndLoad.Save();
            SpeedAnimator.SetBool("Lost", true);
            if (uIManager.vibrationEnabled)
                Vibration.Vibrate(50, 5, true);
            spriteRenderer.enabled = false;
            LimitAnimator.SetBool("Move", false);
            ResetManager();
            if (connection.connectionAvailable)
            {
                NoThanksAnimator.SetBool("Lost", true);
                canPresentContinueText = true;
            }
            isLost = true;
        }
    }
    void ResetManager()
    {
        if (!connection.connectionAvailable)
            rewardRequest.FailedToLoadAd();
        else
            RequestingAd();
    }
    void RequestingAd()
    {
        if (chanceNo < 2)
        {
            if (!adRequested)
            {
                continueScreen.SetActive(true);
                adRequested = true;
            }
        }
        else
        {
            interstitialAds.ShowAd();
        }
    }
    public void ResetPlayer()
    {
        playerFollow.transform.position = new Vector3(0, currentPosition.y, 0);
        if(scoreManager.addScore.score != 0) playerFollow.cameraStarted = true;
        scoreManager.speedMultiplier = 1;
        SpeedAnimator.SetBool("Lost", false);
        if (connection.connectionAvailable)
        {
            NoThanksAnimator.SetBool("Lost", false);
            canPresentContinueText = false;
        }
        isLost = false;
        spriteRenderer.enabled = true;
        transform.position = new Vector3(0, currentPosition.y, 0);
        LimitAnimator.SetTrigger("Reset");
        ResetText();
        player.diedByCamera = false;
    }
    void TextPresentation()
    {
        continueAnimators[0].SetBool("CanPlay", true);
        if (continueTextChecks[0].canPlayNext == true) continueAnimators[1].SetBool("CanPlay", true);
        if (continueTextChecks[1].canPlayNext == true) continueAnimators[2].SetBool("CanPlay", true);
        if (continueTextChecks[2].canPlayNext == true) continueAnimators[3].SetBool("CanPlay", true);
        if (continueTextChecks[3].canPlayNext == true) continueAnimators[4].SetBool("CanPlay", true);
        if (continueTextChecks[4].canPlayNext == true) continueAnimators[5].SetBool("CanPlay", true);
    }
    void ResetText()
    {
        foreach (ContinueTextCheck CTC in continueTextChecks)
        {
            CTC.canPlayNext = false;
        }
    }
}