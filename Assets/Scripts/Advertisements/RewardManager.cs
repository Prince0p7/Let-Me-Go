using UnityEngine;

public class RewardManager : MonoBehaviour
{
    [SerializeField] RewardRequest rewardRequest;
    public void Reward()
    {
        rewardRequest.PlayerResponse(true);
    }
    public void RewardIgnored()
    {
        rewardRequest.PlayerResponse(false);
    }
}