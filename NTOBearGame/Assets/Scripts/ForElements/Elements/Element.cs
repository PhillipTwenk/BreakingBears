using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using TMPro;

public class Element : MonoBehaviour
{
    private Dictionary<string, string> element_info;
    [SerializeField] TMP_Text element_name_text;
    private void Start(){
        element_info = Building.ElementInfo(element_name: gameObject.name.Split('(')[0]);
        gameObject.name = gameObject.name.Split('(')[0];
        element_name_text.text = gameObject.name.Split('(')[0];
    }

    private void OnMouseDown(){
        DBManager.ExecuteQueryWithoutAnswer($"UPDATE elements_info SET studied_state = 1 WHERE name = '{element_name_text.text}' AND studied_state = 0");
        string empty_slot_id = DBManager.ExecuteQuery($"SELECT MIN(slot_id) FROM inventory WHERE element_id = 0");
        DBManager.ExecuteQueryWithoutAnswer($"UPDATE inventory SET element_id = {element_info["element_id"]} WHERE slot_id = {Convert.ToInt32(empty_slot_id)}"); 
        Inventory.is_changed = true;
        Destroy(gameObject);
    }

}
