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
        }
        public void TextChanger(){
            // Получение значения, отображающего наше продвижение в квесте и продвижение в сообщениях

            int Progress = PlayerPrefs.GetInt("ProgressInt");

            string SmallPanelQuery = $"SELECT SmallPanel FROM Panel_Table WHERE id = '{Progress}'";
            string DetailPanelQuery = $"SELECT DetailedPanel FROM Panel_Table WHERE id = '{Progress}'";

            StaticStorage.ProgressPanelTextStatic.text = DBManager.ExecuteQuery(SmallPanelQuery);
            StaticStorage.DetailPanelTextStatic.text = DBManager.ExecuteQuery(DetailPanelQuery);

            // switch (Progress)
            // {
            //     case 1:
            //         StaticStorage.ProgressPanelTextStatic.text = "Открыть карту";
            //         StaticStorage.DetailPanelTextStatic.text = "Для открытия карты нажмите цифру 2 на клавиатуре или кнопку наверху с изображением маркера";
            //         // StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(10);
            //     break;
            //     case 2:
            //         StaticStorage.ProgressPanelTextStatic.text = "Переместиться в руины";
            //         StaticStorage.DetailPanelTextStatic.text = "Нажмите маркер на самой нижней локации на карте";
            //     break;
            //     case 3:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти через руины";
            //         StaticStorage.DetailPanelTextStatic.text = "Прыгайте по платформам, уворачивайтесь от гиганских молотов, избегайте шипов!";
            //     break;
            //     case 4:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти в портал";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в портал в самом конце локации";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(11);
            //     break;
            //     case 5:
            //         StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
            //         StaticStorage.DetailPanelTextStatic.text = "Нажмите на сундуки, стоящие в комнатах, и подберите выпавшие элементы";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(13);
            //     break;
            //     case 6:
            //         StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
            //         StaticStorage.DetailPanelTextStatic.text = "Откройте карту и нажмите маркер лаборатории в правой части карты";
            //     break;
            //     case 7:
            //         StaticStorage.ProgressPanelTextStatic.text = "Узнать противоядие";
            //         StaticStorage.DetailPanelTextStatic.text = "Снова откройте карту и посмотрите какое противоядие нужно создать против ядовитой зоны(Antidote: ...)";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(15);
            //     break;
            //     case 8:
            //         StaticStorage.ProgressPanelTextStatic.text = "Открыть справочник";
            //         StaticStorage.DetailPanelTextStatic.text = "Откройте справочник нажатием кнопки 3 или кнопки наверху с изображением колбочки";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(23);
            //     break;
            //     case 9:
            //         StaticStorage.ProgressPanelTextStatic.text = "Узнать рецепт";
            //         StaticStorage.DetailPanelTextStatic.text = "Выберите в списке элемент-антидот, и составьте цепочку реакций";
            //     break;
            //     case 10:
            //         StaticStorage.ProgressPanelTextStatic.text = "Получить противоядие";
            //         StaticStorage.DetailPanelTextStatic.text = "Используя возможности лаборатории, создайте нужный элемент по составленной цепочке";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(26);
            //     break;
            //     case 11:
            //         StaticStorage.ProgressPanelTextStatic.text = "Вернуться в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Зайдите в меню карты и нажмите на недавно открытый маркер(Второй снизу)";
            //     break;
            //     case 12:
            //         StaticStorage.ProgressPanelTextStatic.text = "Употребить вещество";
            //         StaticStorage.DetailPanelTextStatic.text = "Выкиньте вещество из инвентаря, и нажмите на него Правой кнопкой мыши - начнётся эффект противоядия";
            //     break;
            //     case 13:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти ядовитую зону";
            //         StaticStorage.DetailPanelTextStatic.text = "Прыгайте по грибам, стараясь успеть до конца действия противоядия";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(28);
            //     break;
            //     case 14:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в портал";
            //     break;
            //     case 15:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти руины";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в следующий портал, и пройдите новою полосу препятствий";
            //     break;
            //     case 16:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в портал в конце полосы препятсвий";
            //     break;
            //     case 17:
            //         StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
            //         StaticStorage.DetailPanelTextStatic.text = "Нажмите на хранилища и получите элементы";
            //     break;
            //     case 18:
            //         StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
            //         StaticStorage.DetailPanelTextStatic.text = "Откройте карту и вернитесь в лабораторию";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(32);
            //     break;
            //     case 19:
            //         StaticStorage.ProgressPanelTextStatic.text = "Получить противоядие";
            //         StaticStorage.DetailPanelTextStatic.text = "По карте узнайте новое противоядие и создайте его";

            //     break;
            //     case 20:
            //         StaticStorage.ProgressPanelTextStatic.text = "Вернуться в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Откройте карту и нажмите на последний открытый маркер";
            //     break;
            //     case 21:
            //         StaticStorage.ProgressPanelTextStatic.text = "Употребить вещество";
            //         StaticStorage.DetailPanelTextStatic.text = "Выкиньте вещество из инвентаря, и нажмите на него Правой кнопкой мыши - начнётся эффект противоядия";
            //     break;
            //     case 22:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти ядовитую зону";
            //         StaticStorage.DetailPanelTextStatic.text = "Прыгайте по грибам, стараясь успеть до конца действия противоядия";
            //     break;
            //     case 23:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в портал";
            //     break;
            //     case 24:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти руины";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в следующий портал, и пройдите новою полосу препятствий";
            //     break;
            //     case 25:
            //         StaticStorage.ProgressPanelTextStatic.text = "Пройти в комнату";
            //         StaticStorage.DetailPanelTextStatic.text = "Пройдите в портал";
            //     break;
            //     case 26:
            //         StaticStorage.ProgressPanelTextStatic.text = "Взять содержимое хранилищ";
            //         StaticStorage.DetailPanelTextStatic.text = "Нажмите на хранилища и получите элементы";
            //     break;
            //     case 27:
            //         StaticStorage.ProgressPanelTextStatic.text = "Вернуться назад";
            //         StaticStorage.DetailPanelTextStatic.text = "Откройте карту и вернитесь в лабораторию";
            //     break;
            //     case 28:
            //         StaticStorage.ProgressPanelTextStatic.text = "Получить вещество";
            //         StaticStorage.DetailPanelTextStatic.text = "Используя возможности лаборатории, создайте нужный элемент по составленной цепочке";
            //         StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(35);
            //     break;
            //     case 29:
            //         StaticStorage.ProgressPanelTextStatic.text = "На сегодня всё! До связи";
            //         StaticStorage.DetailPanelTextStatic.text = "Задач на сегодня больше нет";
            //     break;
            // }
        }
        public void StartNewQuest(int ActiveQuest){
            PlayerPrefs.SetInt("ProgressInt", ActiveQuest + 1);
            TextChanger();
            Debug.Log($"{ActiveQuest} квест выполнен! ");
        }
    }


