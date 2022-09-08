using UnityEngine;

public class AddScore : MonoBehaviour
{
    [HideInInspector]
    public int score, currentScore;
    public void Score()
    {
        score++;
        currentScore++;
    }
}