using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;
public class ChatSystem : MonoBehaviour
{
    public GameObject chatPanel, textObjectPrefab, LittletextObjectprefab;
    List<Message> messageList = new List<Message>();
    public RectTransform newObjectTransform;
    public Scrollbar scrollbar;
    public ScrollRect scrollrect;
    public RectTransform contentPanel;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.C))
        {
            GetMessage("YEASHHHHH", textObjectPrefab);
        }
    }
    public void GetMessage(string text, GameObject textObject) {

        Message newMessage = new Message();

        newMessage.text = text;

        GameObject newText = Instantiate(textObject, newObjectTransform);

        newText.transform.parent = contentPanel;

        //newObjectTransform.localPosition = new Vector3(newObjectTransform.localPosition.x, newObjectTransform.localPosition.y - 1000, newObjectTransform.localPosition.z);

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
