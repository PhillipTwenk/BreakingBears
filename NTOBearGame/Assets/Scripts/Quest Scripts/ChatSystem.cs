using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
using Mono.Data.Sqlite;
using System.Data;
using System;
public class ChatSystem : MonoBehaviour
{
    //public GameObject chatPanel;
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Scrollbar scrollbar;
    public ScrollRect scrollrect;
    public RectTransform contentPanel;
    public GameObject NewMessage;
    public GameObject ChatPanel;
    public GameObject ButtonDownObj;

    //Создание сообщения
    public void CreateMessage(string text, bool IsBigMessage) {
        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText;

        if(IsBigMessage) 
            newText = Instantiate(StaticStorage.textObjectPrefabB, newObjectTransform);
        else 
            newText = Instantiate(StaticStorage.textObjectPrefabL, newObjectTransform);

        newText.transform.parent = contentPanel;

        newMessage.textObjectClass = newText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        newMessage.textObjectClass.text = newMessage.text;

        messageList.Add(newMessage);
        NewMessageWasNotRead();
    }

    public void NewMessageWasNotRead(){
        if (ChatPanel.activeSelf == false)
        {
            StaticStorage.isChatRead = false;
            NewMessage.SetActive(true);
        }
        else
        {
            StaticStorage.isChatRead = true;
            NewMessage.SetActive(false);
        }
    }

    //Метод для запуска корутины
    public void StartCoroutineMethod(int NumberOfMessage)
    {
        StartCoroutine(CoroutineSendMessage(NumberOfMessage));
    }

    //Корутина для отправки сообщений
    public IEnumerator CoroutineSendMessage(int NumberOfMessageC)
    {
        //Запуск анимации печатания текста
        StaticStorage.TextingMessageAnimationObjStatic.SetActive(true);

        //Получение информации о прогрессе в сообщениях
        int ProgressMessage = PlayerPrefs.GetInt("ProgressMessage");


        //Отправка сообещний, до того момента как прогресс в сообщениях не совпадёт с требуемым прогрессом
        //Требуемый прогресс показывает, до какого прогресса должны дойти сообщения

        while(ProgressMessage <= NumberOfMessageC)
        {

            //Получение текста сообщения из БД 
            string ChatQuery = $"SELECT Phrase FROM Chat_Phrases WHERE id = '{ProgressMessage + 1}'";
            string message = DBManager.ExecuteQuery(ChatQuery);


            CreateMessage(message, true);


            //Звук нового сообщения
            ControllerSoundEffect.PlayNewMessageSound();

            //Обновление прогресса

            ProgressMessage +=1;
            PlayerPrefs.SetInt("ProgressMessage", ProgressMessage);


            //Активирование кнопки перехода к низу чата

            ButtonDownObj.SetActive(true);


            //Отключение анимации набора текста

            if(ProgressMessage == NumberOfMessageC)
            {
                StaticStorage.TextingMessageAnimationObjStatic.SetActive(false);
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(7, 10));
        }
    }

    public void ClickDownButton()
    {
        scrollbar.value = 0f;
        ButtonDownObj.SetActive(false);
    }
}
public class Message
{
    public string text;
    public TextMeshProUGUI textObjectClass;
}
