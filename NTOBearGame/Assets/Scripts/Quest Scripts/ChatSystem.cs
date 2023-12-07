using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class ChatSystem : MonoBehaviour
{
    public GameObject chatPanel, textObject;
    List<Message> messageList = new List<Message>();
    void Start()
    {
        
    }

    void Update()
    {
        
    }
    public void GetMessage(string text) {

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, chatPanel.transform);

        newMessage.textObject = newText.GetComponent<Text>();

        newMessage.textObject.text = newMessage.text;
        messageList.Add(newMessage);
    }
}
public class Message
{
    public string text;
    public Text textObject;
}
