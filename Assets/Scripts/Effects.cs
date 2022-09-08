using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine;

public class Effects : MonoBehaviour
{
    DepthOfField DOF;
    [SerializeField] Volume volume;
    public float FocusDistance;
    public bool focalLength;
    void Start()
    {
        focalLength = true;
        FocusDistance = 3;
    }
    private void Update()
    {
        BlurEffect();
    }
    void BlurEffect()
    {
        volume.profile.TryGet(out DOF);

        DOF.focusDistance.value = FocusDistance;
        DOF.focalLength.overrideState = focalLength;
    }
}