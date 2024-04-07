using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject NewStartUI;
    public GameObject PauseMenu;
    [SerializeField]private string SR;
    public TextMeshProUGUI SRtextMP;

    private void Start()
    {
        PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
        SR = PlayerPrefs.GetString("ScreenMode");
        SRtextMP.text = SR;
    }
    public void BackButton()
    {
        if (StaticStorage.IsInStartMenu)
        {
            NewStartUI.SetActive(true);
        }
        
        if (StaticStorage.IsInLab || StaticStorage.IsInZone)
        {
            PauseMenu.SetActive(true);
        }
    }
    public void ChangeScreenResolution()
    {
        if (!Screen.fullScreen)
        {
            Screen.SetResolution(Screen.width, Screen.height, true, 60);
            PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
            SRtextMP.text = PlayerPrefs.GetString("ScreenMode");
        }
        else
        {
            Screen.SetResolution(Screen.width, Screen.height, false);
            PlayerPrefs.SetString("ScreenMode", "Оконный");
            SRtextMP.text = PlayerPrefs.GetString("ScreenMode");
        }
    }
}
