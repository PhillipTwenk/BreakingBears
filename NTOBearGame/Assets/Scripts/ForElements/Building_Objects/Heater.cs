using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Heater : MonoBehaviour
{
    private List<List<string>> algorightms;
    [SerializeField] GameObject canvas;
    private bool isCanvas;
    void Start()
    {
        canvas.SetActive(false);
    }

    void Update()
    {
        if(isCanvas && Input.GetKey(KeyCode.Escape)){
            canvas.SetActive(false);
        }
    }

    void OnMouseDown(){
        Debug.Log("Clicked");
        canvas.SetActive(true);
        isCanvas = true;
        string building = "heater";
        string building_id = DatabaseManager.ExecuteQueryWithAnswer($"SELECT id_building FROM buildings WHERE building_name = '{building}'");
        DataTable actions = DatabaseManager.GetTable($"SELECT ");
    }
}
