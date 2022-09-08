[System.Serializable]
public class PlayerData
{
    public int highScore;
    public int attempts;
    public int TotalScore;

    public PlayerData (ScoreManager scoreManager)
    {
        highScore = scoreManager.highScore;
        attempts = scoreManager.attempts;
        TotalScore = scoreManager.TotalScore;
    }
}