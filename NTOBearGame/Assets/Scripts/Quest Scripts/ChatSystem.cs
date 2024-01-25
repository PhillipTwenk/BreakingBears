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
    public GameObject chatPanel;
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Scrollbar scrollbar;
    public ScrollRect scrollrect;
    public RectTransform contentPanel;
    public GameObject NewMessage;
    public GameObject ChatPanel;
    public GameObject ButtonDownObj;

    public void GetMessage(string text, bool IsBigMessage) {

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
    public void StartCoroutineMethod(int NumberOfMessage)
    {
        StartCoroutine(CoroutineSendMessage(NumberOfMessage));
    }
    public IEnumerator CoroutineSendMessage(int NumberOfMessageC)
    {
        StaticStorage.TextingMessageAnimationObjStatic.SetActive(true);
        int ProgressMessage = PlayerPrefs.GetInt("ProgressMessage");
        while(ProgressMessage <= NumberOfMessageC)
        {
            string ChatQuery = $"SELECT Phrase FROM Chat_Phrases WHERE id = '{ProgressMessage + 1}'";

            string message = DBManager.ExecuteQuery(ChatQuery);

            GetMessage(message, true);

            ProgressMessage +=1;
            PlayerPrefs.SetInt("ProgressMessage", ProgressMessage);

            ButtonDownObj.SetActive(true);

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
