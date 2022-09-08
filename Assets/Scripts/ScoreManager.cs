using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI Score, HighScore, SARatio, Attempts;
    [HideInInspector] public int highScore;
    public int attempts, TotalScore;
    public float saRatio;
    public SaveAndLoad saveAndLoad;
    [SerializeField] Animator ScoreAnimator;
    public AddScore addScore;
    public float speedMultiplier = 1;
    void Start()
    {
        saveAndLoad.Load();
        SARatioCount();
        if (highScore == 0)
            HighScore.gameObject.SetActive(false);
        else
            HighScore.gameObject.SetActive(true);
        if (attempts == 0)
        {
            SARatio.gameObject.SetActive(false);
            Attempts.gameObject.SetActive(false);
        }
        else
        {
            SARatio.gameObject.SetActive(true);
            Attempts.gameObject.SetActive(true);
        }
    }
    void Update()
    {
        TextUpdate();
    }
    void TextUpdate()
    {
        Score.text = addScore.score.ToString();
        HighScore.text = highScore.ToString();
        Attempts.text = attempts.ToString();
    }
    public void ScoreCount()
    {
        ScoreAnimator.SetTrigger("Score");
    }
    public void HighScoreCount()
    {
        if (addScore.score > highScore)
            highScore = addScore.score;
    }
    public void SARatioCount()
    {
        if (attempts == 0)
            return;

        saRatio = (float)TotalScore / (float)attempts;
        SARatio.text = saRatio.ToString("0.00");
    }
}