using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public static class Inventory 
{
    public static bool is_changed = false;
    public static Dropdown UpdateInventory(Dropdown SpawnElementChoice){
        SpawnElementChoice.AddOptions(Building.ElementsChoiceInfo(true));
        return SpawnElementChoice;
    }
    
    public static void CleanInventory()
    {
        for (int i = 0; i < 5; i++)
        {
            DBManager.ExecuteQueryWithoutAnswer($"UPDATE inventory SET element_id = 0 WHERE slot_id = {i + 1}"); 
            is_changed = true;
        }
    }

}
