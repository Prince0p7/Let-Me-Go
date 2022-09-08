using UnityEngine;

public class Background : MonoBehaviour
{
    [SerializeField] Transform[] background;
    float size;
    void Start()
    {
        size = background[1].GetComponent<SpriteRenderer>().size.y * background[1].transform.localScale.y;
    }
    void Update()
    {
        if (transform.position.y <= background[0].position.y)
            return;

        if(transform.position.y >= background[2].position.y)
        {
            background[1].position = new Vector3(background[1].position.x, background[2].position.y + size, background[1].position.z);
            SwitchBg();
        }
    }
    void SwitchBg()
    {
        Transform temp = background[1];
        background[1] = background[2];
        background[2] = temp;
    }
}