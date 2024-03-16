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
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Scrollbar scrollbar;
    public ScrollRect scrollrect;
    public RectTransform contentPanel;
    public GameObject ChatPanel;
    //public GameObject ButtonDownObj;

    //Создание сообщения
    public void CreateMessage(string text, bool IsBigMessage)
    {
        //Создание экземпляра нового сообщения
        Message newMessage = new Message();
        
        
        //Создание заготовок текста
        newMessage.TimeText = DateTime.Now.ToString("HH:mm:ss");

        newMessage.text = text;

        GameObject newText;

        
        //Создание объекта сообщений
        if(IsBigMessage) 
            newText = Instantiate(StaticStorage.textObjectPrefabB, newObjectTransform);
        else 
            newText = Instantiate(StaticStorage.textObjectPrefabL, newObjectTransform);
        
        newText.transform.SetParent(contentPanel);
        
        //Получение TMPro компонентов от родителя
        newMessage.textObjectClass = newText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        newMessage.TimeTextObjectClass = newText.transform.GetChild(1).gameObject.GetComponent<TextMeshProUGUI>();
        
        
        //Присваивание тексту компонентов заготовленный текст
        newMessage.textObjectClass.text = newMessage.text;

        newMessage.TimeTextObjectClass.text = newMessage.TimeText;

        
        //Добавления сообщения в динамический массив
        messageList.Add(newMessage);
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
            
            
            //Отключение анимации набора текста

            if(ProgressMessage == NumberOfMessageC)
            {
                StaticStorage.TextingMessageAnimationObjStatic.SetActive(false);
            }

            yield return new WaitForSeconds(UnityEngine.Random.Range(10, 15));
        }
    }
}
public class Message
{
    public string text;
    public TextMeshProUGUI textObjectClass;
    public TextMeshProUGUI TimeTextObjectClass;
    public string TimeText;
}
