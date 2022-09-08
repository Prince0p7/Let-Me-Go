using UnityEngine;
using System.Collections.Generic;

public class LevelGenerator : MonoBehaviour
{
    [SerializeField] Transform Platform;
    Vector2 lastEndPosition;
    [SerializeField] List<AnimatorOverrideController> animator;
    [SerializeField] Transform player;
    public int level;
    public AnimatorOverrideController animatorOverride;
    public int platformNo;
    void Awake()
    {
        lastEndPosition = new Vector2(0, 50);
    }
    void Update()
    {
        if (Vector2.Distance(player.transform.position, lastEndPosition) < 35)
            SpawnLevelPart();
    }
    void SpawnLevelPart()
    {
        Transform lastSpawnPoint = SpawnLevelPart(Platform, lastEndPosition);
        lastEndPosition = lastSpawnPoint.Find("End Point").position;
        platformNo++;
        LevelIncrease();
    }
    Transform SpawnLevelPart(Transform platform, Vector3 spawnPosition)
    {
        Transform levelPartTransform = Instantiate(platform, spawnPosition, Quaternion.identity, transform);
        Animator anim = levelPartTransform.GetComponentInChildren<Animator>();
        overrideController();
        anim.runtimeAnimatorController = animatorOverride;
        return levelPartTransform;
    }
    void overrideController()
    {
       // if (level == 0)
            animatorOverride = animator[Random.Range(0, 1)];
       /* else
        {
                animatorOverride = animator[Random.Range((level * 2), (level * 2) + 1)];
        }*/
    }
    void LevelIncrease()
    {
        if(platformNo % 10 == 0)
            level++;
    }
}