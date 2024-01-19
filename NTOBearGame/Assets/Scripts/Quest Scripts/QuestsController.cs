using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

    public class QuestsController : MonoBehaviour
    {
        private QuestClass QuestClassInstance;
        void Start()
        {
            QuestClassInstance = new QuestClass();
            QuestClassInstance.PlayerPrefsStartValue();
            QuestClassInstance.TextChanger();
        }
    }

