using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SettingsController : MonoBehaviour
{
    public GameObject NewStartUI;
    public GameObject PauseMenu;

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
}
