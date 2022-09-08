using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using UnityEngine.SceneManagement;

public class StartScreen : MonoBehaviour
{
    public Slider LoadingSlider;
    void CanvasShowandHide(string CanvasName)
    {
        for(int i = 0; i < transform.childCount; i++)
        {
            if(transform.GetChild(i).name == CanvasName)
            {
                transform.GetChild(i).gameObject.SetActive(true);
            }
            else
            {
                transform.GetChild(i).gameObject.SetActive(false);
            }
        }
    }
    public void StartGame()
    {
        StartCoroutine(LoadAsynchronously("Level"));
    }
    IEnumerator LoadAsynchronously(string _sceneName)
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(_sceneName);

        CanvasShowandHide("Loading Screen");

        while (!operation.isDone)
        {
            float progress = Mathf.Clamp01(operation.progress / .9f);
            LoadingSlider.value = progress;
            yield return null;
        }
    }
}