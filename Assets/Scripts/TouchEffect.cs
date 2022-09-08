using UnityEngine;

public class TouchEffect : MonoBehaviour
{
    [SerializeField]ParticleSystem touchEffect;
    public void Effect(Vector2 position)
    {
       // touchEffect.transform.position = position;
        touchEffect.Play();
    }    
}