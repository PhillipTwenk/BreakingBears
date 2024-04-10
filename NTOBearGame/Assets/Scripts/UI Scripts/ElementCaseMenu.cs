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
    
    public void Start(){
        SpawnElementChoice.ClearOptions();
        SpawnElementChoice = Inventory.UpdateInventory(SpawnElementChoice);
    }
    private void Update(){  
        if(Inventory.is_changed){
            SpawnElementChoice.ClearOptions();
            SpawnElementChoice = Inventory.UpdateInventory(SpawnElementChoice);
            Inventory.is_changed = false;
        }
    }   
    public void SpawnElement(){
        string selected_element_name = SpawnElementChoice.options[SpawnElementChoice.value].text;
        int element_id = Convert.ToInt32(Building.ElementInfo(element_name: selected_element_name)["element_id"])-1;
        Debug.Log(selected_element_name);
        if (selected_element_name == "H")
        {
            TutorialClass.instance.ContinueTutorial(25);
        }
        Instantiate(EP.elements_prefabs[element_id], SpawnPoint.transform.position, transform.rotation);
        DBManager.ExecuteQueryWithoutAnswer($"UPDATE inventory SET element_id = 0 WHERE slot_id = {SpawnElementChoice.value+1}");
        Inventory.is_changed = true;
        return;
    }
}
