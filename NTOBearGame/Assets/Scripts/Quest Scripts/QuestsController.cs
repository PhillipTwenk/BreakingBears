using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class QuestsController : MonoBehaviour
    {
        public Text ProgressPanelText;
        public Text DetailPanelText;
        private QuestClass QuestClassInstance;
        void Start()
        {
            QuestClassInstance = new QuestClass();
            QuestClassInstance.PlayerPrefsStartValue();
            QuestClassInstance.TextChanger(ProgressPanelText, DetailPanelText);
        }
        void Update()
        {

            // ТЕСТ!!!!!!!!  Пока не сделана механика взятия элементов из сундука

            if (Input.GetKeyDown(KeyCode.T))
            {
                switch (PlayerPrefs.GetInt("ProgressInt"))
                {
                    case 5:
                        QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"), ProgressPanelText, DetailPanelText);
                    break;
                    case 17:
                        QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"), ProgressPanelText, DetailPanelText);
                    break;
                    case 26:
                        QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"), ProgressPanelText, DetailPanelText);
                    break;
                }
            }
            if (Input.GetKeyDown(KeyCode.Y))
            {
                switch (PlayerPrefs.GetInt("ProgressInt"))
                {
                    case 12:
                        QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"), ProgressPanelText, DetailPanelText);
                    break;
                    case 21:
                        QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"), ProgressPanelText, DetailPanelText);
                    break;
                }
            }
        }
    }

