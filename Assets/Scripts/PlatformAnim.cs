using UnityEngine;
using System.Collections.Generic;

public class PlatformAnim : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Play play;
    [SerializeField] ScoreManager scoreManager;
    [HideInInspector] public List<Platform> platforms;
    void Awake()
    {
        platforms = new List<Platform>(GetComponentsInChildren<Platform>());
    }
    void Update()
    {
        foreach (Platform Pl in GetComponentsInChildren<Platform>())
        {
            if (!platforms.Contains(Pl))
            {
                platforms.Add(Pl);
            }
            PlatformDestroyer(Pl);
        }

        for (int i = 0; i < platforms.Count; i++)
        {
            if (platforms[i].GetComponentInChildren<Animator>() != null)
            {
                {
                    ChangingSpeed(i, platforms[i].GetComponentInChildren<Animator>().GetBool("Speed Changed"));
                }

                {
                    if (i <= player.platformNo)
                        platforms[i].GetComponentInChildren<Animator>().enabled = false;
                    else
                        platforms[i].GetComponentInChildren<Animator>().enabled = true;
                }
            }
        }
    }
    void ChangingSpeed(int i, bool speedChanged)
    {
        if (!speedChanged)
        {
            if (i <= 3)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", i * .4f);
            else if(i > 3 && i <= 8)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(.8f, 1f));
            else if(i > 8 && i <= 15)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(1f, 1.2f));
            else if(i > 15 && i <= 25)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(1.2f, 1.4f));
            else if(i > 25 && i <= 50)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(1.3f, 1.5f));
            else if(i > 40 && i <= 50)
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(1.5f, 2f));
            else
                platforms[i].GetComponentInChildren<Animator>().SetFloat("Speed", Random.Range(1.8f, 2.4f));
            platforms[i].GetComponentInChildren<Animator>().SetBool("Speed Changed", true);
        }

        foreach (Platform A in platforms)
        {
            if (A.GetComponentInChildren<Animator>() == null)
                return;

            A.GetComponentInChildren<Animator>().speed *= scoreManager.speedMultiplier;
            Debug.Log(A.GetComponentInChildren<Animator>().speed);
        }
    }
    void PlatformDestroyer(Platform platform)
    {
        if (Vector2.Distance(player.transform.position, platform.transform.position) > 100)
        {
            foreach (Transform T in platform.GetComponentInChildren<Transform>())
            {
                if (T != platform.transform)
                    Destroy(T.gameObject);
            }
        }
    }
}