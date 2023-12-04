using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class QuestClass
    {
        public void PlayerPrefsStartValue(){
            PlayerPrefs.SetInt("ProgressInt", 1);
        }
        public void TextChanger(Text ProgressPanelText){

            // Получение значения, отображающего наше продвижение в квесте

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            //Перебор значения для установления нужного текста

            switch (Progress)
            {
                case 1:
                    ProgressPanelText.text = "Открыть карту";
                break;
                case 2:
                    ProgressPanelText.text = "Переместиться в руины";
                break;
                case 3:
                    ProgressPanelText.text = "Пройти через руины";
                break;
                case 4:
                    ProgressPanelText.text = "Пройти в портал";
                break;
                case 5:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                break;
                case 6:
                    ProgressPanelText.text = "Вернуться в лабораторию";
                break;
                case 7:
                    ProgressPanelText.text = "Узнать опасность";
                break;
                case 8:
                    ProgressPanelText.text = "Открыть справочник";
                break;
                case 9:
                    ProgressPanelText.text = "Узнать противоядие";
                break;
                case 10:
                    ProgressPanelText.text = "Создать противоядие";
                break;
                case 11:
                    ProgressPanelText.text = "Вернуться в комнату";
                break;
                case 12:
                    ProgressPanelText.text = "Употребить вещество";
                break;
                case 13:
                    ProgressPanelText.text = "Пройти ядовитую зону";
                break;
                case 14:
                    ProgressPanelText.text = "Пройти в комнату";
                break;
                case 15:
                    ProgressPanelText.text = "Пройти руины";
                break;
                case 16:
                    ProgressPanelText.text = "Пройти в комнату";
                break;
                case 17:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                break;
                case 18:
                    ProgressPanelText.text = "Вернуться в лабораторию";
                break;
                case 19:
                    ProgressPanelText.text = "Создать противоядие";
                break;
                case 20:
                    ProgressPanelText.text = "Вернуться в комнату";
                break;
                case 21:
                    ProgressPanelText.text = "Употребить вещество";
                break;
                case 22:
                    ProgressPanelText.text = "Пройти ядовитую зону";
                break;
                case 23:
                    ProgressPanelText.text = "Пройти в комнату";
                break;
                case 24:
                    ProgressPanelText.text = "Пройти руины";
                break;
                case 25:
                    ProgressPanelText.text = "Пройти в комнату";
                break;
                case 26:
                    ProgressPanelText.text = "Взять содержимое хранилищ";
                break;
                case 27:
                    ProgressPanelText.text = "Вернуться в лабораторию";
                break;
                case 28:
                    ProgressPanelText.text = "Создать вещество";
                break;
                case 29:
                    ProgressPanelText.text = "Отправить вещество";
                break;
            }
        }
    }


