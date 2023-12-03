using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

    public class QuestsController : MonoBehaviour
    {
        public Text ProgressPanelText;
        private QuestClass QuestClassInstance;
        void Start()
        {
            QuestClassInstance = new QuestClass();
            QuestClassInstance.PlayerPrefsStartValue();
            QuestClassInstance.TextChanger(ProgressPanelText);
        }
    }

