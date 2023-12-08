using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


    public class QuestClass
    {
        public void PlayerPrefsStartValue(){
            PlayerPrefs.SetInt("ProgressInt", 1);
        }
        public void TextChanger(){

            ChatSystem ChatSystemScriptReference = new ChatSystem();

            // Получение значения, отображающего наше продвижение в квесте

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            //Перебор значения для установления нужного текста

            switch (Progress)
            {
                case 1:
                    StaticStorage.ProgressPanelTextStatic.text = "Открыть карту";
                    StaticStorage.DetailPanelTextStatic.text = "Для ";
                break;
                case 2:
                    StaticStorage.ProgressPanelTextStatic.text = "Переместиться в руины";
                    StaticStorage.DetailPanelTextStatic.text = " ";
                break;
                case 3:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти через руины";
                    StaticStorage.DetailPanelTextStatic.text = " ";
                break;
                case 4:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти в портал";
                    StaticStorage.DetailPanelTextStatic.text = " ";
                break;
                case 5:
                    StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 6:
                    StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 7:
                    StaticStorage.ProgressPanelTextStatic.text = "Узнать противоядие";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 8:
                    StaticStorage.ProgressPanelTextStatic.text = "Открыть справочник";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 9:
                    StaticStorage.ProgressPanelTextStatic.text = "Узнать рецепт";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 10:
                    StaticStorage.ProgressPanelTextStatic.text = "Получить противоядие";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 11:
                    StaticStorage.ProgressPanelTextStatic.text = "Вернуться в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 12:
                    StaticStorage.ProgressPanelTextStatic.text = "Употребить вещество";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 13:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти ядовитую зону";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 14:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 15:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти руины";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 16:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 17:
                    StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 18:
                    StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 19:
                    StaticStorage.ProgressPanelTextStatic.text = "Получить противоядие";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 20:
                    StaticStorage.ProgressPanelTextStatic.text = "Вернуться в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 21:
                    StaticStorage.ProgressPanelTextStatic.text = "Употребить вещество";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 22:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти ядовитую зону";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 23:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 24:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти руины";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 25:
                    StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 26:
                    StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 27:
                    StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 28:
                    StaticStorage.ProgressPanelTextStatic.text = "Получить вещество";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
                case 29:
                    StaticStorage.ProgressPanelTextStatic.text = "Отправить вещество";
                    StaticStorage.DetailPanelTextStatic.text = "";
                break;
            }
        }
        public void StartNewQuest(int ActiveQuest){
            PlayerPrefs.SetInt("ProgressInt", ActiveQuest + 1);
            TextChanger();
            Debug.Log($"{ActiveQuest} квест выполнен! ");
        }
    }


