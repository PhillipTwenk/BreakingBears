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
        SpawnElementChoice.AddOptions(Building.ElementsChoiceInfo());
    }
    public void SpawnElement(){
        Instantiate(EP.elements_prefabs[SpawnElementChoice.value-1], SpawnPoint.transform.position, transform.rotation);
    }
}
