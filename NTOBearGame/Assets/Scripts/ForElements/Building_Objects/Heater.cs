using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using Mono.Data.Sqlite;
using System.Data;
using System;

public class Heater : MonoBehaviour
{
    private static Dictionary<string, string> temp_storage;
    public bool is_canvas_activated = false;
    public string action;
    public int parameter = 0;
    public int heater_element_id;
    public string heater_element_name;
    public string building = "Печь";
    public string exit;
    [SerializeField] GameObject canvas;
    [SerializeField] Dropdown ActionsChoice;
    [SerializeField] Dropdown ElementsChoice;
    [SerializeField] Dropdown ExitsChoice;
    [SerializeField] InputField parameterInput;
    void Start()
    {
        heater_element_id = PlayerPrefs.GetInt("HeaterElementID");
        heater_element_name = PlayerPrefs.GetString("HeaterElementName");
        action = PlayerPrefs.GetString("HeaterAction");
        exit = PlayerPrefs.GetString("HeaterExit");
        parameter = PlayerPrefs.GetInt("HeaterParameter");

        canvas.gameObject.SetActive(false); // сразу отключаем канвас агрегата
        parameterInput.gameObject.SetActive(false);  // сразу отключаем поле ввода параметра действия
    }

    void Update()
    {
        if(is_canvas_activated && Input.GetKey(KeyCode.Escape)){ // нажимая Esc при открытом канвасе(UI агрегата) -> закрываем его с полем ввода параметра
            parameterInput.gameObject.SetActive(false);
            canvas.gameObject.SetActive(false);
            is_canvas_activated = false;
        }
    }

    void OnMouseDown(){
        if(is_canvas_activated == false){
            canvas.gameObject.SetActive(true);
            is_canvas_activated = true;
            // Заполнение опций для выбора алгоритма          
            // - доступные элементы (позже из инвентаря)
            ElementsChoice.ClearOptions(); // очищаем опции выбора
            List<string> elementsInfo = Building.ElementsChoiceInfo(); // заносим в список через функцию все элементы
            ElementsChoice.AddOptions(elementsInfo); 

            // - действия(зависят от строения)
            ActionsChoice.ClearOptions(); // очищаем опции выбора
            List<string> actionsInfo = Building.ActionsChoiceInfo(building); // заносим в список через функцию все действия агрегата
            ActionsChoice.AddOptions(actionsInfo);

            // - доступные выходы
            ExitsChoice.ClearOptions(); // очищаем опции выбора
            List<string> exitsInfo = Building.ExitsChoiceInfo(); // заносим в список через функцию все действия выхода
            ExitsChoice.AddOptions(exitsInfo);
   
        }
    }

    public void BuildAlgorithm(){
        // нахождение нужных переменных для последующего сохранения алгоритма
        heater_element_id = Convert.ToInt32(ElementsChoice.value);
        heater_element_name = ElementsChoice.options[ElementsChoice.value].text;
        exit = ExitsChoice.options[ExitsChoice.value].text;

        // сохраняем все части алгоритма в PlayerPrefs
        PlayerPrefs.SetInt("HeaterElementID", heater_element_id);
        PlayerPrefs.SetString("HeaterElementName", heater_element_name);
        PlayerPrefs.SetString("HeaterAction", action);
        PlayerPrefs.SetString("HeaterExit", exit);
        PlayerPrefs.SetInt("HeaterParameter", parameter);

        parameterInput.gameObject.SetActive(false); // отключаем поле ввода для параметра
        canvas.gameObject.SetActive(false); //отключаем канвас
        is_canvas_activated = false;
    }

    public void CheckChosenAction(){ // проверка при выборе действия (всегда в одном порядке: 1 - с параметром; 2 - без параметра; 3 - удалить остатки)
        action = ActionsChoice.options[ActionsChoice.value].text;
        Debug.Log(action);
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
        if(coll.name == PlayerPrefs.GetString("HeaterElementName")){ // если попадает вещество, которое является условием для начала алгоритма
            Debug.Log("ok");
            Dictionary<string, string> result_element = Building.Reaction( // пример вызова функции для получения вещества по алгоритму
                building, // строение
                PlayerPrefs.GetString("HeaterAction"), // действие
                PlayerPrefs.GetInt("HeaterElementID"), // ID элемента в БД
                parameter=PlayerPrefs.GetInt("HeaterParameter") // параметр действия
            );

            Debug.Log(result_element["name"]); // вывод имени элемента
        } 
    }

}
