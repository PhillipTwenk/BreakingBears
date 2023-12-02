using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;
using TMPro;

public class Heater : MonoBehaviour
{
    [SerializeField] string building_name;
    [SerializeField] string sys_building_name;
    private string action;
    private string exit;
    private string reaction_state;
    private int parameter = 0;
    private bool is_canvas_activated = false;
    public List<int> element_ids;
    public List<string> element_names;
    public List<string> temp_storage; // хранилище элементов для агрегата 
    public List<int> temp_element_ids;
    public List<string> elements_info;

    [SerializeField] GameObject Canvas;
    [SerializeField] Dropdown ActionsChoice;
    [SerializeField] Dropdown ElementsChoice1;
    [SerializeField] Dropdown ElementsChoice2;
    [SerializeField] Dropdown ExitsChoice;
    [SerializeField] InputField ParameterInput;
    [SerializeField] ElementsPrefabs EP;
    [SerializeField] GameObject OutputPlace;
    [SerializeField] Text AlgorithmText;
    [SerializeField] GameObject PlayerMenu;
    [SerializeField] Text AgregatName;
    [SerializeField] TMP_Text ReactionStateText;
    void Start()
    {
        for(int i = 1; i < 3; i++){
            element_ids.Add(PlayerPrefs.GetInt($"{sys_building_name}ElementID{i}"));
            if(element_ids[i-1] != 0){
                element_names.Add(PlayerPrefs.GetString($"{sys_building_name}ElementName{i}"));
            } else{
                element_names.Add("-");
            }
        }
        action = PlayerPrefs.GetString($"{sys_building_name}Action");
        exit = PlayerPrefs.GetString($"{sys_building_name}Exit");
        parameter = PlayerPrefs.GetInt($"{sys_building_name}Parameter");
        AgregatName.text = $"{building_name}";

        Canvas.gameObject.SetActive(false); // сразу отключаем канвас агрегата
        ParameterInput.gameObject.SetActive(false);  // сразу отключаем поле ввода параметра действия
        PlayerMenu.SetActive(true);
    }

    void Update()
    {
        if(is_canvas_activated && Input.GetKey(KeyCode.Escape)){ // нажимая Esc при открытом канвасе(UI агрегата) -> закрываем его с полем ввода параметра
            CheckChosenAction();
            if(action != "" && (ElementsChoice1.value != 0 && ElementsChoice2.value != 0) && ExitsChoice.options[ExitsChoice.value].text != ""){
                BuildAlgorithm();
            } else {
                ParameterInput.gameObject.SetActive(false); // отключаем поле ввода для параметра
                Canvas.gameObject.SetActive(false); //отключаем канвас
                is_canvas_activated = false;
                PlayerMenu.SetActive(true); // отключаем интерфейс игрока, чтобы не было наслоения
            }
        }


    }

    void OnMouseDown(){
        if(is_canvas_activated == false){
            PlayerMenu.SetActive(false);
            Canvas.gameObject.SetActive(true);
            is_canvas_activated = true;
            // Заполнение опций для выбора алгоритма          
            // - доступные элементы для 1 позиции
            ElementsChoice1.ClearOptions(); // очищаем опции выбора
            elements_info = Building.ElementsChoiceInfo(); // заносим в список через функцию все элементы
            ElementsChoice1.AddOptions(elements_info); 

            // - доступные элементы для 2 позиции
            ElementsChoice2.ClearOptions(); // очищаем опции выбора
            elements_info = Building.ElementsChoiceInfo(); // заносим в список через функцию все элементы
            ElementsChoice2.AddOptions(elements_info); 

            // - действия(зависят от строения)
            ActionsChoice.ClearOptions(); // очищаем опции выбора
            List<string> actionsInfo = Building.ActionsChoiceInfo(building_name); // заносим в список через функцию все действия агрегата
            ActionsChoice.AddOptions(actionsInfo);

            // - доступные выходы
            ExitsChoice.ClearOptions(); // очищаем опции выбора
            List<string> exitsInfo = Building.ExitsChoiceInfo(); // заносим в список через функцию все действия выхода
            ExitsChoice.AddOptions(exitsInfo);
        }
    }

    public void BuildAlgorithm(){
        // нахождение нужных переменных для последующего сохранения алгоритма
        element_ids.Clear();
        element_names.Clear();

        exit = ExitsChoice.options[ExitsChoice.value].text;
        element_ids.Add(ElementsChoice1.value);
        element_ids.Add(ElementsChoice2.value);
        element_names.Add(ElementsChoice1.options[ElementsChoice1.value].text);
        element_names.Add(ElementsChoice2.options[ElementsChoice2.value].text);
        // сохраняем все части алгоритма в PlayerPrefs
        for(int i = 1; i < 3; i++){
            PlayerPrefs.SetInt($"{sys_building_name}ElementID{i}", element_ids[i-1]);
            if(element_names[i-1] != ""){
                PlayerPrefs.SetString($"{sys_building_name}ElementName{i}", element_names[i-1]);
            } else {
                PlayerPrefs.SetString($"{sys_building_name}ElementName{i}", "-");
            }
        }
        PlayerPrefs.SetString($"{sys_building_name}Action", action);
        PlayerPrefs.SetString($"{sys_building_name}Exit", exit);
        PlayerPrefs.SetInt($"{sys_building_name}Parameter", parameter);
        ParameterInput.text = "";
        if(element_ids[1] == 0){
            AlgorithmText.text = $"{action} {element_names[0]}, Параметр = {parameter}, Вывести в {exit}";
        } else {
            AlgorithmText.text = $"{action} {element_names[0]} и {element_names[1]}, Параметр = {parameter}, Вывести в {exit}";
        }

        ParameterInput.gameObject.SetActive(false); // отключаем поле ввода для параметра
        Canvas.gameObject.SetActive(false); //отключаем канвас
        is_canvas_activated = false;
        PlayerMenu.SetActive(true); // отключаем интерфейс игрока, чтобы не было наслоения
    }

    public void CheckChosenAction(){ // проверка при выборе действия (всегда в одном порядке: 1 - с параметром; 2 - без параметра; 3 - удалить остатки)
        action = ActionsChoice.options[ActionsChoice.value].text;
        if(ActionsChoice.value == 1){
            ParameterInput.gameObject.SetActive(true);
        } else {
            ParameterInput.gameObject.SetActive(false);
        }
    }
    public void ParameterInputResult(){
        parameter = Convert.ToInt32(ParameterInput.text);
    }

    private void OnTriggerEnter(Collider coll){

        if(!elements_info.Contains(coll.name)){
            return;
        }
        string element_name = coll.name.ToString().Split('(')[0];
        Debug.Log(PlayerPrefs.GetString($"{sys_building_name}ElementName1"));
        temp_storage.Add(element_name);
        if((temp_storage.Contains(PlayerPrefs.GetString($"{sys_building_name}ElementName1")) || PlayerPrefs.GetString($"{sys_building_name}ElementName1") == "-") && (temp_storage.Contains(PlayerPrefs.GetString($"{sys_building_name}ElementName2")) || PlayerPrefs.GetString($"{sys_building_name}ElementName2") == "-") ){ // если попадает вещество, которое является условием для начала алгоритма
            temp_element_ids.Add(PlayerPrefs.GetInt($"{sys_building_name}ElementID1"));
            temp_element_ids.Add(PlayerPrefs.GetInt($"{sys_building_name}ElementID2"));
            Destroy(coll.gameObject);
            List<Dictionary<string, string>> result_element = Building.Reaction( // пример вызова функции для получения вещества по алгоритму
                building_name, // строение
                PlayerPrefs.GetString($"{sys_building_name}Action"), // действие
                temp_element_ids, // ID элементов в БД
                parameter=PlayerPrefs.GetInt($"{sys_building_name}Parameter") // параметр действия
            );
            if(result_element.Count == 0){
                reaction_state = "Нет такой реакции!";
                return;
            } else{
                reaction_state = "Реакция прошла успешно!";
            }
            foreach(Dictionary<string, string> element in result_element){
                if(Convert.ToInt32(element["element_id"]) == 0){
                    continue;
                }
                Debug.Log(element["name"]); // вывод имени элемента
                if(exit == building_name){
                    Instantiate(EP.elements_prefabs[Convert.ToInt32(element["element_id"])-1], OutputPlace.transform.position, Quaternion.identity);
                }

            }
            for(int i = 1; i < 3; i++){
                PlayerPrefs.DeleteKey($"{sys_building_name}ElementName{i}");
                PlayerPrefs.DeleteKey($"{sys_building_name}ElementID{i}");
            }

            PlayerPrefs.DeleteKey($"{sys_building_name}Parameter");
            PlayerPrefs.DeleteKey($"{sys_building_name}Action");
            PlayerPrefs.DeleteKey($"{sys_building_name}Exit");
            AlgorithmText.text = "";

            parameter = 0;
            action = "";
            element_ids.Clear();
            element_names.Clear();
            temp_storage.Clear();
            temp_element_ids.Clear();
        } 
    }

}
