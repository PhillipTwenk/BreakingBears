using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Element : MonoBehaviour
{
    [SerializeField] Dictionary<string, string> ElementInfo;
    [SerializeField] TMP_Text element_name_text;
    void Start(){
        element_name_text.text = gameObject.name.Split('(')[0];
    }

}
