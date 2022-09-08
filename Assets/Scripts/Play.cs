using UnityEngine;

public class Play : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] PlayerFollow playerFollow;
    [HideInInspector] public bool gameStarted;
    [HideInInspector] public bool gameStartedOnce;
    [SerializeField] ScoreManager scoreManager;

    public GameObject settingsMenu;
    public GameObject startScreen;
    [SerializeField] Animator scoreAnimator;
    void Start()
    {
        gameStarted = false;
        startScreen.SetActive(true);
    }
    public void PlayButton()
    {
        gameStarted = true;
        playerFollow.cameraStarted = true;
        if (!gameStartedOnce)
        {
            scoreManager.attempts++;
            scoreAnimator.SetBool("Start", true);
            gameStartedOnce = true;
        }

        if (settingsMenu.activeSelf)
            settingsMenu.SetActive(false);
        if (startScreen.activeSelf)
            startScreen.SetActive(false);
    }
}