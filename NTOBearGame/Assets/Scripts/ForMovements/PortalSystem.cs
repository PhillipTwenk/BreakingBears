using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PortalSystem : MonoBehaviour
{
    public Transform[] PointPortalTeleport;
    private Transform CharacterPosition;
    public Transform CameraPosition;
    private QuestClass QuestClassInstance;
    public Text ProgressPanelText;
    void Start()
    {
        CharacterPosition = GetComponent<Transform>();
        QuestClassInstance = new QuestClass();
    }
    void OnCollisionEnter(Collision other)
    {
        if(other.gameObject.tag == "PortalTriggerForward"){
            string name = other.gameObject.name;
            int NumberTrigger = int.Parse(name);
            CharacterPosition.position = PointPortalTeleport[NumberTrigger + 1].position;
            Vector3 newCamPosition = new Vector3(CharacterPosition.position.x, CharacterPosition.position.y, CharacterPosition.position.z);
            CameraPosition.position = newCamPosition;
        }
        if(other.gameObject.tag == "PortalTriggerBackward"){
            string name = other.gameObject.name;
            int NumberTrigger = int.Parse(name);
            CharacterPosition.position = PointPortalTeleport[NumberTrigger - 1].position;
            Vector3 newCamPosition = new Vector3(CharacterPosition.position.x, CharacterPosition.position.y, CharacterPosition.position.z);
            CameraPosition.position = newCamPosition;
        }
        if (other.gameObject.tag == "EndNDzone"){
            string name = other.gameObject.name;
            char nameNumberChar = name[10];
            int nameNumber = (nameNumberChar - '0') - 1;
            switch (nameNumber)
            {
                case 1:
                    if (PlayerPrefs.GetInt("ProgressInt") == 2)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 3);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
                case 2:
                    if (PlayerPrefs.GetInt("ProgressInt") == 14)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 15);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
                case 3:
                    if (PlayerPrefs.GetInt("ProgressInt") == 23)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 24);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
            }
            Destroy(other.gameObject);
        }
        if (other.gameObject.tag == "EndDzone"){
            string name = other.gameObject.name;
            char nameNumberChar = name[9];
            int nameNumber = (nameNumberChar - '0') - 1;
            switch (nameNumber)
            {
                case 1:
                    if (PlayerPrefs.GetInt("ProgressInt") == 12)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 13);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
                case 2:
                    if (PlayerPrefs.GetInt("ProgressInt") == 21)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 22);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
            }
            Destroy(other.gameObject);
        }
    }
}
