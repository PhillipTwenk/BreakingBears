using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class QuestClass
    {
        public void PlayerPrefsStartValue(){
            PlayerPrefs.SetInt("ProgressInt", 1);
        }
        public void TextChanger(Text ProgressPanelText, Text DetailPanelText){

            // Получение значения, отображающего наше продвижение в квесте

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            //Перебор значения для установления нужного текста

            switch (Progress)
            {
                case 1:
                    ProgressPanelText.text = "Открыть карту";
                    DetailPanelText.text = " ";
                break;
                case 2:
                    ProgressPanelText.text = "Переместиться в руины";
                    DetailPanelText.text = " ";
                break;
                case 3:
                    ProgressPanelText.text = "Пройти через руины";
                    DetailPanelText.text = " ";
                break;
                case 4:
                    ProgressPanelText.text = "Пройти в портал";
                    DetailPanelText.text = " ";
                break;
                case 5:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                    DetailPanelText.text = "";
                break;
                case 6:
                    ProgressPanelText.text = "Вернуться назад";
                    DetailPanelText.text = "";
                break;
                case 7:
                    ProgressPanelText.text = "Узнать противоядие";
                    DetailPanelText.text = "";
                break;
                case 8:
                    ProgressPanelText.text = "Открыть справочник";
                    DetailPanelText.text = "";
                break;
                case 9:
                    ProgressPanelText.text = "Узнать рецепт";
                    DetailPanelText.text = "";
                break;
                case 10:
                    ProgressPanelText.text = "Получить противоядие";
                    DetailPanelText.text = "";
                break;
                case 11:
                    ProgressPanelText.text = "Вернуться в комнату";
                    DetailPanelText.text = "";
                break;
                case 12:
                    ProgressPanelText.text = "Употребить вещество";
                    DetailPanelText.text = "";
                break;
                case 13:
                    ProgressPanelText.text = "Пройти ядовитую зону";
                    DetailPanelText.text = "";
                break;
                case 14:
                    ProgressPanelText.text = "Пройти в комнату";
                    DetailPanelText.text = "";
                break;
                case 15:
                    ProgressPanelText.text = "Пройти руины";
                    DetailPanelText.text = "";
                break;
                case 16:
                    ProgressPanelText.text = "Пройти в комнату";
                    DetailPanelText.text = "";
                break;
                case 17:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                    DetailPanelText.text = "";
                break;
                case 18:
                    ProgressPanelText.text = "Вернуться назад";
                    DetailPanelText.text = "";
                break;
                case 19:
                    ProgressPanelText.text = "Получить противоядие";
                    DetailPanelText.text = "";
                break;
                case 20:
                    ProgressPanelText.text = "Вернуться в комнату";
                    DetailPanelText.text = "";
                break;
                case 21:
                    ProgressPanelText.text = "Употребить вещество";
                    DetailPanelText.text = "";
                break;
                case 22:
                    ProgressPanelText.text = "Пройти ядовитую зону";
                    DetailPanelText.text = "";
                break;
                case 23:
                    ProgressPanelText.text = "Пройти в комнату";
                    DetailPanelText.text = "";
                break;
                case 24:
                    ProgressPanelText.text = "Пройти руины";
                    DetailPanelText.text = "";
                break;
                case 25:
                    ProgressPanelText.text = "Пройти в комнату";
                    DetailPanelText.text = "";
                break;
                case 26:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                    DetailPanelText.text = "";
                break;
                case 27:
                    ProgressPanelText.text = "Вернуться назад";
                    DetailPanelText.text = "";
                break;
                case 28:
                    ProgressPanelText.text = "Получить вещество";
                    DetailPanelText.text = "";
                break;
                case 29:
                    ProgressPanelText.text = "Отправить вещество";
                    DetailPanelText.text = "";
                break;
            }
        }
        public void StartNewQuest(int ActiveQuest, Text ProgressPanelText, Text DetailPanelText){
            PlayerPrefs.SetInt("ProgressInt", ActiveQuest + 1);
            TextChanger(ProgressPanelText, DetailPanelText);
            Debug.Log($"{ActiveQuest} квест выполнен! ");
        }
    }


