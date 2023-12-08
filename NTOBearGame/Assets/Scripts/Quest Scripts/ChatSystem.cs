using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChatSystem : MonoBehaviour
{
    public GameObject chatPanel, textObjectPrefabB, textObjectPrefabL;
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Scrollbar scrollbar;
    public ScrollRect scrollrect;
    public RectTransform contentPanel;
    public GameObject NewMessage;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GetMessage("YEASHHHHH", textObjectPrefabB);
        }
    }
    public void GetMessage(string text, GameObject textObject) {

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, newObjectTransform);

        newText.transform.parent = contentPanel;

        newMessage.textObjectClass = newText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        newMessage.textObjectClass.text = newMessage.text;

        messageList.Add(newMessage);
        NewMessageWasNotRead();
    }
    public void NewMessageWasNotRead(){
        StaticStorage.isChatRead = false;
        NewMessage.SetActive(true);
    }
    public void NewMessageWasRead(){
        StaticStorage.isChatRead = true;
        NewMessage.SetActive(false);
    }
}
public class Message
{
    public string text;
    public TextMeshProUGUI textObjectClass;
}
