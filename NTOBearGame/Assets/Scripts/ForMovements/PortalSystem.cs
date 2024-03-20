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
    public List<Transform> PortalPointHelperList;
    public Transform TransformHelper;
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

            //Перемещение стубуретки
            TransformHelper.position = PortalPointHelperList[NumberTrigger + 1].position;

            // Перебор номера триггера для закрытия квестов, в которых необходимо пройти в комнату

            switch (NumberTrigger)
            {
                case 0:
                    QuestClassInstance.CheckQuest(4);
                    break;
                case 4:
                    QuestClassInstance.CheckQuest(14);
                    break;
                case 8:
                    QuestClassInstance.CheckQuest(16);
                    break;
                case 12:
                    QuestClassInstance.CheckQuest(23);
                    break;
                case 16:
                    QuestClassInstance.CheckQuest(25);
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
            
            //Перемещение стубуретки
            TransformHelper = PortalPointHelperList[NumberTrigger + 1];
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
                    QuestClassInstance.CheckQuest(3);
                    break;
                case 2:
                    // Пройдена 2 безопасная зона
                    QuestClassInstance.CheckQuest(15);
                    break;
                case 3:
                    // Пройдена 3 безопасная зона
                    QuestClassInstance.CheckQuest(24);
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
                    QuestClassInstance.CheckQuest(13);
                    break;
                // Пройдена 2 опасная зона
                case 2:
                    QuestClassInstance.CheckQuest(22);
                    break;
            }
            Destroy(other.gameObject);
        }
    }
}
