using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;


    public class QuestClass
    {
        public void PlayerPrefsStartValue(){
            PlayerPrefs.SetInt("ProgressInt", 1);
            PlayerPrefs.SetInt("ProgressMessage", 0);
            PlayerPrefs.SetInt("CPCondition", 0);
        }
        public void TextChanger(){
            // Получение значения, отображающего наше продвижение в квесте и продвижение в сообщениях

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            string SmallPanelQuery = $"SELECT SmallPanel FROM Panel_Table WHERE id = '{Progress}'";
            string DetailPanelQuery = $"SELECT DetailedPanel FROM Panel_Table WHERE id = '{Progress}'";

            StaticStorage.ProgressPanelTextStatic.text = DBManager.ExecuteQuery(SmallPanelQuery);
            StaticStorage.DetailPanelTextStatic.text = DBManager.ExecuteQuery(DetailPanelQuery);


            SendQuestMessage(Progress);
        }

        //Отправка сообщений, если на текущем квесте это необходимо
        public void SendQuestMessage(int progress){

            //Получение информации о том, нужно ли отправлять сообщение на текущем квесте

            string QueryBoolMessage = $"SELECT AreThereMessages FROM Panel_Table WHERE id = '{progress}'".ToString();
            bool AreThereMessagesOnTheQuest = bool.Parse(DBManager.ExecuteQuery(QueryBoolMessage));

            //Проверка

            if(AreThereMessagesOnTheQuest){

                //Получение информации о том, какой номер прогресса сообщений в текущем квесте

                string MessageQueryNumber = $"SELECT MessageNumber FROM QuestsWithMessages WHERE QuestNumber = '{progress}'";

                //Запуск корутины с отправкой сообщений
                StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(int.Parse(DBManager.ExecuteQuery(MessageQueryNumber)));
            }
        }
        public void StartNewQuest(int ActiveQuest){
            PlayerPrefs.SetInt("ProgressInt", ActiveQuest + 1);
            TextChanger();
            Debug.Log($"{ActiveQuest} квест выполнен! ");
        }
    }


