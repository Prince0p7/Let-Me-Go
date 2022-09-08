using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class CheckingInternetConnection : MonoBehaviour
{
    public bool connectionAvailable;
    public bool _checked;
    void Start()
    {
        InvokeRepeating("Check", .1f, 2);
    }
    public void Check()
    {
        StartCoroutine(CheckConnection());
    }
    public IEnumerator CheckConnection()
    {
        UnityWebRequest request = new UnityWebRequest("https://www.google.com");
        yield return request.SendWebRequest();

        if (request.error != null)
            connectionAvailable = false;
        else
            connectionAvailable = true;
        if (!_checked)
            _checked = true;
    }
}