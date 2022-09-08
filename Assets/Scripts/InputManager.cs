using UnityEngine;
using UnityEngine.InputSystem;

public class InputManager : MonoBehaviour
{
    PlayerInput _input;// Input Action Reference

    void Awake()
    {
        _input = new PlayerInput();
    }
    private void OnEnable()
    {
        _input.Enable();
    }
    private void OnDisable()
    {
        _input.Disable();
    }
    public bool TouchInput()
    {
        return _input.Input.TouchPress.triggered;
    }
    public Vector2 TouchPosition()
    {
        return _input.Input.TouchPosition.ReadValue<Vector2>();
    }
}