using UnityEngine;

public class PlayerPrefsTestController : MonoBehaviour
{
    void Start()
    {
        PlayerPrefs.SetString("ScreenMode", "Полноэкранный");
        PlayerPrefs.SetInt("CPCondition", 0);
        PlayerPrefs.SetInt("CPNumber", 0);
        PlayerPrefs.SetInt("ProgressInt", 1);
        PlayerPrefs.SetInt("ProgressMessage", 0);
        PlayerPrefs.SetInt("CPCondition", 0);
        PlayerPrefs.SetInt("FirstIntrance", 0);
    }
}
