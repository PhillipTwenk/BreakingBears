using System;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

public static class Building_Heater
{   

    // Инициализация нужного алгоритма, который позже выполнится
    // public void Algorithm(Dictionary<string, string> _element, string _action, string _param, string _exit){
    //     Element = _element;
    //     temp_storage.Add(Element);
    //     Action = _action;
    //     Parameter = _param;
    //     if(_exit != null) Exit = _exit; 
    // }

    // Вызов соответствующей функции(действия) под алгоритм
    // P.S. плиз упростите эти три условия как нибудь
    // public void MainCheck(string _action){
    //     if (Action == "heat"){
    //         Heat();
    //     } else if (Action == "combine_with"){
    //         CombineWithPrevious();
    //     } else if (Action == "remove_remain"){
    //         RemoveRemains();
    //     }
    // }
    private static Dictionary<string, Dictionary<string, string>> temp_storages;// хранилище для текущих элементов (при алгоритме)
    private static Dictionary<string, Dictionary<string, string>> storages; // хранилище для предыдущих элементов (в агрегате после алгоритма)

    // 0) ОБЩИЕ МЕТОДЫ

    // 0.1) Вывод результата реакции
    private static void Output(Dictionary <string, string> Element, string from, string to){
        if(from == to){
            storages[to] = Element;
            return;
        }
        temp_storages[to] = Element;
    }
    // 0.2) Информация о элементе
    private static void ElementInfo(string element_name){
        DataTable element = DatabaseManager.GetTable($"SELECT * FROM elements_info WHERE name = {element_name}");
        Debug.Log(element);
        return;
    }
    // 0.3) Информация о действиях используемого агрегата
    private static void ActionsInfo(string building){
        string building_id = DatabaseManager.ExecuteQueryWithAnswer($"SELECT id FROM buildings WHERE building_name = {building}");
    }
    
    // 1) НАГРЕВАТЕЛЬ
    // 1.1) Нагреть элемент до определенной температуры
    private static void Heat(Dictionary<string, string> Element, int Parameter, string Exit = "heater"){
        string element_id = DatabaseManager.ExecuteQueryWithAnswer($"SELECT result FROM elements_reactions WHERE id_element1 = {Convert.ToInt32(Element["name"])} AND action = 1");
        if(element_id is not null){
            // ---
        } else {
            Element["temperature"] += Convert.ToInt32(Parameter);
        }
        Output(Element, "heater", Exit);
        return;
    }
    // 1.2) Смешать с элементом в storage
    private static void CombineWithPrevious(Dictionary <string, string> Element){
        return;
    }
    // 1.3) Убрать остатки после реакции, очистить storage[{Агрегат}]
    private static void RemoveRemains(string building){
        // storages[building] = null;
        // return;
    }

}
