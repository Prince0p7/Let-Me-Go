using UnityEngine;
using System.Collections.Generic;
using RDG;

public class Player : MonoBehaviour
{
    [SerializeField] InputManager inputManager;
    [SerializeField] ScoreManager scoreManager;
    [SerializeField] AdsInitializer adsInitializer;
    public Animator[] animator;
    public Animator playerEyes;
    [SerializeField] Play play;
    [SerializeField] Reset reset;
    [SerializeField] CheckingInternetConnection connection;
    public int platformNo;
    [SerializeField] LayerMask whatIsGround;
    public float radius;
    [SerializeField] UIManager uIManager;
    Collider2D[] col;
    [SerializeField] ParticleSystem jumpEffect;
    public bool diedByCamera;
    bool clicked;
    float nextTimeToBlink;
    void Awake()
    {
        Time.timeScale = 1;
    }
    void Update()
    {
        if (reset.isLost || adsInitializer.gamePauseForLoading)
            return;

        Blink();
        col = Physics2D.OverlapCircleAll(transform.position, radius, whatIsGround);

        if (col.Length != 0)
        {
            if (inputManager.TouchInput())
            {
                clicked = false;
                if (!clicked)
                {
                    uIManager.GetuiElementsClicked();

                    if (uIManager.touchingButton)
                        return;
                    if (!play.gameStarted)
                        play.PlayButton();
                    transform.position = new Vector3(transform.position.x, Mathf.RoundToInt(transform.position.y));
                    platformNo++;
                    jumpEffect.Play();
                    foreach (Animator A in animator)
                        A.SetBool("Jump", true);

                    if (uIManager.vibrationEnabled)
                    {
                        Vibration.Vibrate(25, 1, true);
                    }
                    clicked = true;
                }
            }
        }
        else
        {
            foreach (Animator A in animator)
                A.SetBool("Jump", false);
        }

            PlayerFall();
    }
    public void CheckGroundStatus()
    {
        if (col.Length == 0)
        {
            reset.ResetGame();
            return;
        }
        else
        {
            reset.currentPosition = transform.position;
            scoreManager.ScoreCount();
        }
    }
    void PlayerFall()
    {
        if (col.Length == 0)
            return;

        foreach (Collider2D c in col)
        {
            if (c.name == "Limit")
            {
                diedByCamera = true;
                reset.ResetGame();
            }
        }
    }
    void Blink()
    {
        nextTimeToBlink += Time.deltaTime;
        playerEyes.SetBool("Blink", false);
        if (nextTimeToBlink >= Random.Range(5, 10))
        {
            playerEyes.SetBool("Blink", true);
            nextTimeToBlink = 0;
        }
    }
    /*
    void ScreenPosition(Vector2 _screenPosition)
    {
        Vector3 screenCoordinates = new Vector3(_screenPosition.x, _screenPosition.y, Camera.main.nearClipPlane);
        Vector3 worldCoordinates = Camera.main.ScreenToWorldPoint(screenCoordinates);
        worldCoordinates.z = 0;
    }*/
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.white;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}