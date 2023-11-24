using System;
using System.Collections.Generic;
using UnityEngine;
using System.Data;


// КЛАСС ДЛЯ РАБОТЫ С ВЕЩЕСТВАМИ И РЕАКЦИЯМИ
// - Создал: @Artefok
// - Использует DBManager, (все using сверху)
// - Статичный класс для вызова элементов в других скриптах игры
public static class Building
{   
    // СТАТИЧНЫЕ ПЕРЕМЕННЫЕ В КЛАССЕ
    private static Dictionary<string, Dictionary<string, string>> temp_storages; // хранилище для предыдущих элементов (в агрегате после алгоритма)
    private static List<Dictionary<string, string>> player_storage; // хранилище игрока (soon)
    

    // ОБЩИЕ МЕТОДЫ
    // - Пояснения к комментам:
    //     INPUT: параметры функция (*param - необязательный параметр)
    //     OUTPUT: то, что возвращает функция
    // - Методы указаны в том порядке, в котором они (в основном) будут использоваться в коде


    // 1) Информация о элементе
    // INPUT: id элемента ИЛИ его название
    // OUTPUT: информация об элементе в виде словаря
    public static Dictionary<string, string> ElementInfo(int element_id = 0, string element_name = null){
        string element_info_query = "";
        if(element_id == 0){
            element_info_query = $"SELECT * FROM elements_info WHERE name = '{element_name}'";
        } else if(element_name == null){
            element_info_query = $"SELECT * FROM elements_info WHERE element_id = {element_id}";
        }

        DataTable element_info = DBManager.GetTable(element_info_query);
        Dictionary<string, string> res_element = new Dictionary<string, string>();

        for(int i = 0; i <= 4; i++){
            string value = element_info.Rows[0][i].ToString();
            res_element[$"{element_info.Columns[i]}"] = value;
        }
        return res_element;
    }

    // 2) Информация о действиях используемого агрегата
    // INPUT: -
    // OUTPUT: все возможные действия в рабочем агрегате
    public static List<string> ActionsChoiceInfo(string building){
        string building_id = DBManager.ExecuteQuery($"SELECT id_building FROM buildings WHERE building_name = '{building}'");
        DataTable actions = DBManager.GetTable($"SELECT action_name FROM actions WHERE building = {building_id}");
        List<string> res_actions = new List<string>();
        for(int i = 0; i < actions.Rows.Count; i++){
            string value = actions.Rows[i][0].ToString();
            res_actions.Add(value);
        }
        return res_actions;
    }

    // 3) Информация о всех элементах (позже внутри player_storage)
    // INPUT: -
    // OUTPUT: все возможные вещества (позже те, которые находятся в инвентаре)
    public static List<string> ElementsChoiceInfo(){
        DataTable elements = DBManager.GetTable($"SELECT name FROM elements_info");
        List<string> res_elements = new List<string>();
        for(int i = 0; i < elements.Rows.Count; i++){
            string value = elements.Rows[i][0].ToString();
            res_elements.Add(value);
        }
        return res_elements;
    }

    // 4) Информация о всех агрегатах, куда можно вывести вещество
    // INPUT: -
    // OUTPUT: все возможные строения из БД
    public static List<string> ExitsChoiceInfo(){
        DataTable buildings = DBManager.GetTable($"SELECT building_name FROM buildings");
        List<string> res_buildings = new List<string>();
        for(int i = 0; i < buildings.Rows.Count; i++){
            string value = buildings.Rows[i][0].ToString();
            res_buildings.Add(value);
        }
        return res_buildings;
    }

    // 5) Проведение реакции с веществом(-ами)
    // INPUT: название агрегата, действия, параметр, основное вещество с его хар-ками, *доп.вещество
    // OUTPUT: информация о получившемся элементе
    public static Dictionary<string, string> Reaction(string building, string action, int parameter, Dictionary<string, string> Element1, Dictionary<string, string> Element2 = null){   
        string building_reaction_id = DBManager.ExecuteQuery($"SELECT id_building FROM buildings WHERE building_name = '{building}'"); // получение id рабочего агрегата
        string action_id = DBManager.ExecuteQuery($"SELECT id_action FROM actions WHERE action_name = '{action}' AND building = {Convert.ToInt32(building_reaction_id)}"); // получение id действия через id рабочего агрегата и action
        string res_element_query = ""; // запрос в БД
        if(Element2 == null){ // если в реакции только одно вещество
            res_element_query = $"SELECT result FROM elements_reactions WHERE id_element1 = {Convert.ToInt32(Element1["element_id"])} AND action = {Convert.ToInt32(action_id)} AND parameter_for_action = {parameter}";
        } else{ // если в реакции два вещества
            res_element_query = $"SELECT result FROM elements_reactions WHERE id_element1 = {Convert.ToInt32(Element1["element_id"])} AND id_element2 = {Convert.ToInt32(Element2["element_id"])} AND action = {Convert.ToInt32(action_id)} AND parameter_for_action = {parameter}";
        }
        string res_element_id = DBManager.ExecuteQuery(res_element_query); // проведение нужного запроса в БД
        return ElementInfo(element_id: Convert.ToInt32(res_element_id)); // возвращение информации об итоговом элементе
    }

    // 6) Очищает temp_storages[агрегат] в рабочем агрегате
    public static void RemoveRemains(string building){
        temp_storages[building] = new Dictionary<string, string>();
        return;
    }

    // 7) Вывод результата реакции в нужное место
    // INPUT: элемент, имя агрегата, в который нужно направить
    // OUTPUT: - (помещает элемент в temp_storages[агрегат])
    public static void Output(Dictionary <string, string> Element, string to){
        temp_storages[to] = Element;
        return;
    }

}
