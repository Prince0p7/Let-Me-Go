using UnityEngine;
using System.Collections;

public class PlayerFollow : MonoBehaviour
{
    [SerializeField] Player player;
    [SerializeField] Play play;
    public bool clicked;
    public bool cameraStarted;

    [SerializeField] Animator LimitAnimator;
    void Update()
    {
        if (cameraStarted)
        {
            if (!clicked)
                StartingMovement();
            else
                CameraMovement();
        }
    }
    public void StartingMovement()
    {
        transform.position = Vector3.Lerp(transform.position, new Vector3(transform.position.x, player.transform.position.y + 6f, transform.position.z), 10 * Time.deltaTime);
        StartCoroutine(changingMovement());
    }
    IEnumerator changingMovement()
    {
        yield return new WaitForSeconds(.5f);
        clicked = true;
    }
    void CameraMovement()
    {
        LimitAnimator.SetBool("Move", true);
        transform.position += Vector3.up * .085f;
    }
}