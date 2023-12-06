using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StaticStorage : MonoBehaviour
{
    public static Text ProgressPanelTextStatic;
    public static Text DetailPanelTextStatic;
    public Text ProgressPanelText;
    public Text DetailPanelText;
    void Start()
    {
        ProgressPanelTextStatic = ProgressPanelText;
        DetailPanelTextStatic = DetailPanelText;
    }

}
