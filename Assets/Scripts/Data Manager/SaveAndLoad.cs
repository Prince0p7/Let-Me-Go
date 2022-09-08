using UnityEngine;

public class SaveAndLoad : MonoBehaviour
{
    [SerializeField] ScoreManager scoreManager;
    public void Save()
    {
        SaveSystem.SavePlayer(scoreManager);
    }
    public void Load()
    {
        if (!System.IO.File.Exists(Application.persistentDataPath + "/player.save"))
            return;
        PlayerData data = SaveSystem.LoadPlayer();

        scoreManager.highScore = data.highScore;
        scoreManager.attempts = data.attempts;
        scoreManager.TotalScore = data.TotalScore;
    }
}