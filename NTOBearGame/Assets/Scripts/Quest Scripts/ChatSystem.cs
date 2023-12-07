using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChatSystem : MonoBehaviour
{
    public GameObject chatPanel, textObjectPrefab;
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Transform AllMessages;
    void Start()
    {
    }

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GetMessage("pqpqpq", textObjectPrefab);
        }
    }
    public void GetMessage(string text, GameObject textObject) {

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, newObjectTransform);

        newText.transform.parent = AllMessages;

        Debug.Log(newObjectTransform.localPosition);

        newObjectTransform.localPosition = new Vector3(newObjectTransform.localPosition.x, newObjectTransform.localPosition.y - 120, newObjectTransform.localPosition.z);
        Debug.Log(newObjectTransform.localPosition);
        newMessage.textObjectClass = newText.transform.GetChild(0).gameObject.GetComponent<TextMeshProUGUI>();
        
        newMessage.textObjectClass.text = newMessage.text;

        messageList.Add(newMessage);
    }
}
public class Message
{
    public string text;
    public TextMeshProUGUI textObjectClass;
}
