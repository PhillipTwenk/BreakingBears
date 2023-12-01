using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class ElementListMenu : MonoBehaviour
{
    private List<string> ElementsNames; 
    private List<string> ElementsReactions;
    public Dictionary<string, string> ElementInfo;
    private List<string> ElemColumns = new List<string>(){"name", "contain_temp", "state"};
    private List<string> ElemColumnsTranslation = new List<string>(){"Название","Температура хранения °C","Состояние"};
    private Dictionary<string, string> ElemStateTranslations = new Dictionary<string, string>(){
        {"liquid","Жидкость"}, 
        {"solid","Твердое"}, 
        {"gas","Газ"}
    };
    [SerializeField] Dropdown ListOfElements;
    [SerializeField] Text ElementReactionsText;
    [SerializeField] Text ElementInfoText;
    void Start()
    {
        ListOfElements.ClearOptions();
        ElementsNames = Building.ElementsChoiceInfo();
        ListOfElements.AddOptions(ElementsNames);
        gameObject.SetActive(false);
    }

    public void ElementsAndReactions(){
        ElementInfoText.text = "";
        ElementReactionsText.text = "";

        ElementInfo = Building.ElementInfo(element_id: ListOfElements.value);
        for(int i = 0; i < ElemColumnsTranslation.Count; i++){
            ElementInfoText.text += $"{ElemColumnsTranslation[i]}: {ElementInfo[ElemColumns[i]]}\n";
        }

        ElementsReactions = Building.ReactionsWithElement(ListOfElements.value);
        for(int i = 0; i < ElementsReactions.Count; i++){
            ElementReactionsText.text += $"{ElementsReactions[i]}\n";
        }
    }
}
