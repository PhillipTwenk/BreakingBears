using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class StaticStorage : MonoBehaviour
{
    public HelperController HCReference;
    public static HelperController HCReferenceStatic;
    public Text TextHelperST;
    public TextMeshProUGUI TextDetialPanelST;
    public static Text TextHelperSTstatic;
    public static TextMeshProUGUI TextDetialPanelSTstatic;
    public TextMeshPro TextHelperQuest;
    public static TextMeshPro TextHelperQuestStatic;
    public TutorialClass TutorialClass;
    public static TutorialClass TutorialClassStatic;
    public NewStaticStorage NSS;
    public static NewStaticStorage NSSStatic;
    public TextMeshProUGUI TextMProTutorial;
    public static TextMeshProUGUI TextMProTutorialStatic;
    public static Text ProgressPanelTextStatic;
    public static TextMeshProUGUI DetailPanelTextStatic;
    public Text ProgressPanelText;
    public TextMeshProUGUI DetailPanelText;
    public static bool isChatRead;
    public GameObject textObjectB, textObjectL;
    public GameObject TextingMessageAnimationObj;
    public static GameObject TextingMessageAnimationObjStatic;
    public static GameObject textObjectPrefabB, textObjectPrefabL;
    public ChatSystem ChatSystemRef;

    public StartGameMenu StartGameMenuRef;

    public static StartGameMenu StartGameMenuRefStatic;

    public static ChatSystem ChatSystemRefStatic;
    
    public static bool IsInStartMenu;
    public static bool IsInLab;
    public static bool IsInZone;

    public static bool IsPause;

    public static AudioSource MusicInLabStatic;
    public static AudioSource MusicInZoneStatic;
    public static AudioSource MusicInStartGameMenuStatic;
    public AudioSource MusicInLab;
    public AudioSource MusicInZone;
    public AudioSource MusicInStartGameMenu;
    public AudioClip HitHammer;
    public AudioClip ThornHit;
    public AudioClip NewMessage;
    public AudioClip Walking;
    public AudioClip Running;
    public static AudioClip HitHammerStatic;
    public static AudioClip ThornHitStatic;
    public static AudioClip NewMessageStatic;
    public static AudioClip WalkingStatic;
    public static AudioClip RunningStatic;
    public static AudioSource NewMessageSourceStatic;
    void Start()
    {
        HCReferenceStatic = HCReference;
        NSSStatic = NSS;
        TextHelperSTstatic = TextHelperST;
        TextDetialPanelSTstatic = TextDetialPanelST;
        TextHelperQuestStatic = TextHelperQuest;
        TutorialClassStatic = TutorialClass;
        TextMProTutorialStatic = TextMProTutorial;
        WalkingStatic = Walking;
        RunningStatic = Running;
        HitHammerStatic = HitHammer;
        ThornHitStatic = ThornHit;
        NewMessageStatic = NewMessage;
        MusicInLabStatic = MusicInLab;
        MusicInZoneStatic = MusicInZone;
        MusicInStartGameMenuStatic = MusicInStartGameMenu;
        IsInStartMenu = true;
        IsInLab = false;
        IsInZone = false;
        ChatSystemRefStatic = ChatSystemRef;
        TextingMessageAnimationObjStatic = TextingMessageAnimationObj;
        ProgressPanelTextStatic = ProgressPanelText;
        DetailPanelTextStatic = DetailPanelText;
        textObjectPrefabB = textObjectB;
        textObjectPrefabL = textObjectL;
        StartGameMenuRefStatic = StartGameMenuRef;
        IsPause = false;
    }
}
