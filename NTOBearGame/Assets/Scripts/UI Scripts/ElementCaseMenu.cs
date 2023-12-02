using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class ElementCaseMenu : MonoBehaviour
{
    [SerializeField] Dropdown SpawnElementChoice;
    [SerializeField] ElementsPrefabs EP;
    [SerializeField] GameObject SpawnPoint;
    
    void Start(){
        SpawnElementChoice.ClearOptions();
        SpawnElementChoice.AddOptions(Building.ElementsChoiceInfo(true));
    }
    public void SpawnElement(){
        string selected_element_name = SpawnElementChoice.options[SpawnElementChoice.value].text;
        int element_id = Convert.ToInt32(Building.ElementInfo(element_name: selected_element_name)["element_id"])-1;
        Debug.Log(selected_element_name);
        Debug.Log(element_id);
        Instantiate(EP.elements_prefabs[element_id], SpawnPoint.transform.position, transform.rotation);
    }
}
