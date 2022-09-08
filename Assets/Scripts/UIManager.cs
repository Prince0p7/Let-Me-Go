using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
using UnityEngine.InputSystem;
using RDG;

public class UIManager : MonoBehaviour
{
    public bool settingButton, volumeEnabled;
    [HideInInspector] public bool vibrationEnabled;
    [SerializeField] GraphicRaycaster ui_Raycaster;
    [SerializeField] InputManager inputManager; 
    PointerEventData click_data;
    List<RaycastResult> click_results;
    public bool touchingButton;
    [SerializeField] AudioManager audioManager;
    void Start()
    {
        vibrationEnabled = true;
        VolumeButton();
        click_data = new PointerEventData(EventSystem.current);
        click_results = new List<RaycastResult>();
    }
    public void SettingButton(GameObject settingOptions)
    {
        settingButton = !settingButton;
        settingOptions.SetActive(settingButton);
    }
    public void VolumeButton()
    {
        volumeEnabled = !volumeEnabled;

        if (volumeEnabled)
        {
            audioManager.Play();
        }
        else
        {
            audioManager.Pause();
        }
    }
    public void VibrationButton(Image image)
    {
        vibrationEnabled = !vibrationEnabled;

        if (vibrationEnabled)
        {
            image.color = Color.green;
            Vibration.Vibrate(50, 2, false);
        }
        else
        {
            image.color = Color.red;
        }
    }
    public void GetuiElementsClicked()
    {
        click_data.position = inputManager.TouchPosition();
        click_results.Clear();
        touchingButton = false;

        ui_Raycaster.Raycast(click_data, click_results);
        foreach(RaycastResult result in click_results)
        {
            GameObject ui_elements = result.gameObject;
            if(ui_elements != null)
            {
                if (ui_elements.layer == 6)
                {
                    touchingButton = true;
                    Debug.Log(ui_elements.name);
                }
            }
        }
    }
}