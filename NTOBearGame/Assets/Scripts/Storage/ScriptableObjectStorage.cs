using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "ScriptableObjectStorage", menuName = "MainStorageObjects", order = 1)]
public class ScriptableObjectStorage : ScriptableObject
{
    public static ScriptableObjectStorage instance = null;
    public Text ProgressPanelText;

    public TextMeshProUGUI TextMProTutorial;
    public TextMeshProUGUI DetailPanelText;

    public GameObject textObjectB;
    public GameObject textObjectL;
    public GameObject TextingMessageAnimationObj;
}
