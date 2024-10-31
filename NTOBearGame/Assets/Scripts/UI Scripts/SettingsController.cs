using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
     
    private void Start()
    {
        PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
    }
    
    public void FullScreen()
    {
        Screen.SetResolution(Screen.width, Screen.height, true, 60);
        PlayerPrefs.SetString("ScreenMode", "Оконный");
        Debug.Log("Оконный");
    }
    public void WindowScreen()
    {
        Screen.SetResolution(Screen.width, Screen.height, false);
        PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
        Debug.Log("Полноэкранный");
    }
    
    public void QuitGame()
    {
        Application.Quit();
        Debug.Log("Quit");
    }
}
