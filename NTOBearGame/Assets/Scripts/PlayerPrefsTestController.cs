using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerPrefsTestController : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
    }
}
