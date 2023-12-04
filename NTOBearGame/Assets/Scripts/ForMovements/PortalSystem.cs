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
        // Игрок вошёл в портал
        if(other.gameObject.tag == "PortalTriggerForward"){

            // Определение Номера Триггера

            string name = other.gameObject.name;
            int NumberTrigger = int.Parse(name);

            // Перемещение персонажа с камерой  в точку с определёнными координатами из массива PointPortalTeleport

            CharacterPosition.position = PointPortalTeleport[NumberTrigger + 1].position;
            Vector3 newCamPosition = new Vector3(CharacterPosition.position.x, CharacterPosition.position.y, CharacterPosition.position.z);
            CameraPosition.position = newCamPosition;

            // Перебор номера триггера для закрытия квестов, в которых необходимо пройти локацию

            switch (NumberTrigger)
            {
                case 0:
                    if (PlayerPrefs.GetInt("ProgressInt") == 4)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 5);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                        Debug.Log("4 квест выполнен!");
                    }
                break;
            }
        }

        // Игрок вошёл в обратный портал

        if(other.gameObject.tag == "PortalTriggerBackward"){

            // Определение номера триггера

            string name = other.gameObject.name;
            int NumberTrigger = int.Parse(name);

            // Перемещение персонажа с камерой

            CharacterPosition.position = PointPortalTeleport[NumberTrigger - 1].position;
            Vector3 newCamPosition = new Vector3(CharacterPosition.position.x, CharacterPosition.position.y, CharacterPosition.position.z);
            CameraPosition.position = newCamPosition;
        }

        // Игрок прошёл безопасную зону

        if (other.gameObject.tag == "EndNDzone"){

            // Определение номера Триггера

            string name = other.gameObject.name;
            char nameNumberChar = name[9];
            int nameNumber = (nameNumberChar - '0');
            switch (nameNumber)
            {
                case 1:
                // Пройдена 1 безопасная зона
                    if (PlayerPrefs.GetInt("ProgressInt") == 3)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 4);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                        Debug.Log("3 квест выполнен!");
                    }
                break;
                case 2:
                // Пройдена 2 безопасная зона
                    if (PlayerPrefs.GetInt("ProgressInt") == 14)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 15);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
                case 3:
                // Пройдена 3 безопасная зона
                    if (PlayerPrefs.GetInt("ProgressInt") == 23)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 24);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
            }
            Destroy(other.gameObject);
        }
        // Игрок прошёл опасную зону
        if (other.gameObject.tag == "EndDzone"){
            string name = other.gameObject.name;
            char nameNumberChar = name[8];
            int nameNumber = (nameNumberChar - '0');
            switch (nameNumber)
            {
                // Пройдена 1 опасна зона
                case 1:
                    if (PlayerPrefs.GetInt("ProgressInt") == 12)
                    {
                        PlayerPrefs.SetInt("ProgressInt", 13);
                        QuestClassInstance.TextChanger(ProgressPanelText);
                    }
                break;
                // Пройдена 2 опасная зона
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
