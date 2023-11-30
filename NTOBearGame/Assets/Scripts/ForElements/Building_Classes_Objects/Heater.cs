using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Heater : MonoBehaviour
{
    private bool is_canvas_activated = false;
    private string action;
    private string building_name = "Печь";
    private string exit;
    private int parameter = 0;
    public List<int> element_ids;
    public List<string> element_names;
    public List<string> temp_storage; // хранилище элементов для агрегата 
    public List<int> temp_element_ids;
    public List<string> elementsInfo;

    [SerializeField] GameObject Canvas;
    [SerializeField] Dropdown ActionsChoice;
    [SerializeField] Dropdown ElementsChoice1;
    [SerializeField] Dropdown ElementsChoice2;
    [SerializeField] Dropdown ExitsChoice;
    [SerializeField] InputField parameterInput;
    [SerializeField] ElementsPrefabs EP;
    [SerializeField] GameObject OutputPlace;
    [SerializeField] Text AlgorithmText;
    [SerializeField] GameObject PlayerMenu;
    void Start()
    {
        for(int i = 1; i < 3; i++){
            element_ids.Add(PlayerPrefs.GetInt($"HeaterElementID{i}"));
            if(element_ids[i-1] != 0){
                element_names.Add(PlayerPrefs.GetString($"HeaterElementName{i}"));
            } else{
                element_names.Add("-");
            }
        }
        action = PlayerPrefs.GetString("HeaterAction");
        exit = PlayerPrefs.GetString("HeaterExit");
        parameter = PlayerPrefs.GetInt("HeaterParameter");

        Canvas.gameObject.SetActive(false); // сразу отключаем канвас агрегата
        parameterInput.gameObject.SetActive(false);  // сразу отключаем поле ввода параметра действия
        PlayerMenu.SetActive(true);
    }

    void Update()
    {
        if(is_canvas_activated && Input.GetKey(KeyCode.Escape)){ // нажимая Esc при открытом канвасе(UI агрегата) -> закрываем его с полем ввода параметра
            BuildAlgorithm();
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
            elementsInfo = Building.ElementsChoiceInfo(); // заносим в список через функцию все элементы
            ElementsChoice1.AddOptions(elementsInfo); 

            // - доступные элементы для 2 позиции
            ElementsChoice2.ClearOptions(); // очищаем опции выбора
            elementsInfo = Building.ElementsChoiceInfo(); // заносим в список через функцию все элементы
            ElementsChoice2.AddOptions(elementsInfo); 

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
            PlayerPrefs.SetInt($"HeaterElementID{i}", element_ids[i-1]);
            if(element_names[i-1] != ""){
                PlayerPrefs.SetString($"HeaterElementName{i}", element_names[i-1]);
            } else {
                PlayerPrefs.SetString($"HeaterElementName{i}", "-");
            }
        }
        PlayerPrefs.SetString("HeaterAction", action);
        PlayerPrefs.SetString("HeaterExit", exit);
        PlayerPrefs.SetInt("HeaterParameter", parameter);
        if(element_ids[1] == 0){
            AlgorithmText.text = $"{action} {element_names[0]}, Параметр = {parameter}, Вывести в {exit}";
        } else {
            AlgorithmText.text = $"{action} {element_names[0]} и {element_names[1]}, Параметр = {parameter}, Вывести в {exit}";
        }

        parameterInput.gameObject.SetActive(false); // отключаем поле ввода для параметра
        Canvas.gameObject.SetActive(false); //отключаем канвас
        is_canvas_activated = false;
        PlayerMenu.SetActive(true);
    }

    public void CheckChosenAction(){ // проверка при выборе действия (всегда в одном порядке: 1 - с параметром; 2 - без параметра; 3 - удалить остатки)
        action = ActionsChoice.options[ActionsChoice.value].text;
        if(ActionsChoice.value == 1){
            parameterInput.gameObject.SetActive(true);
        } else {
            parameterInput.gameObject.SetActive(false);
        }
    }
    public void ParameterInputResult(){
        parameter = Convert.ToInt32(parameterInput.text);
    }

    private void OnTriggerEnter(Collider coll){
        if(!elementsInfo.Contains(coll.name)){
            return;
        }

        string element_name = coll.name.ToString().Split('(')[0];
        Debug.Log(PlayerPrefs.GetString("HeaterElementName1"));
        temp_storage.Add(element_name);
        if((temp_storage.Contains(PlayerPrefs.GetString("HeaterElementName1")) || PlayerPrefs.GetString("HeaterElementName1") == "-") && (temp_storage.Contains(PlayerPrefs.GetString("HeaterElementName2")) || PlayerPrefs.GetString("HeaterElementName2") == "-") ){ // если попадает вещество, которое является условием для начала алгоритма
            temp_element_ids.Add(PlayerPrefs.GetInt("HeaterElementID1"));
            temp_element_ids.Add(PlayerPrefs.GetInt("HeaterElementID2"));
            Destroy(coll.gameObject);
            List<Dictionary<string, string>> result_element = Building.Reaction( // пример вызова функции для получения вещества по алгоритму
                building_name, // строение
                PlayerPrefs.GetString("HeaterAction"), // действие
                temp_element_ids, // ID элементов в БД
                parameter=PlayerPrefs.GetInt("HeaterParameter") // параметр действия
            );

            foreach(Dictionary<string, string> element in result_element){
                if(Convert.ToInt32(element["element_id"]) == 0){
                    continue;
                }
                Debug.Log(element["name"]); // вывод имени элемента
                if(exit == building_name){
                    PlayerPrefs.DeleteAll();
                    Instantiate(EP.elements_prefabs[Convert.ToInt32(element["element_id"])-1], OutputPlace.transform.position, Quaternion.identity);
                }

            }
            parameter = 0;
            action = "";
            element_ids.Clear();
            element_names.Clear();
            temp_storage.Clear();
            temp_element_ids.Clear();
        } 
    }

}
