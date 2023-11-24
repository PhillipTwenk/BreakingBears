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
    private int element_id;
    private Dictionary<string, string> algorithm_element;
    private string action;
    private int parameter;
    private string element;
    private string building = "Печь";

    [SerializeField] GameObject canvas;
    [SerializeField] Dropdown ActionsChoice;
    [SerializeField] Dropdown ElementsChoice;
    [SerializeField] Dropdown ExitsChoice;
    [SerializeField] InputField parameterInput;
    void Start()
    {
        canvas.gameObject.SetActive(false);
    }

    void Update()
    {
        if(is_canvas_activated && Input.GetKey(KeyCode.Escape)){
            canvas.gameObject.SetActive(false);
            is_canvas_activated = false;
        }
    }

    void OnMouseDown(){
        if(is_canvas_activated == false){
            canvas.gameObject.SetActive(true);
            is_canvas_activated = true;
            // Заполнение опций для выбора алгоритма
            // - действия(зависят от строения)
            ActionsChoice.ClearOptions();
            List<string> actionsInfo = Building.ActionsChoiceInfo(building);
            ActionsChoice.AddOptions(actionsInfo);
            if(PlayerPrefs.HasKey("HeaterAction")){

            }
            // - доступные элементы (позже из инвентаря)
            ElementsChoice.ClearOptions();
            List<string> elementsInfo = Building.ElementsChoiceInfo();
            ElementsChoice.AddOptions(elementsInfo);
            if(PlayerPrefs.HasKey("HeaterElement")){

            }
            // - доступные выходы
            ExitsChoice.ClearOptions();
            List<string> exitsInfo = Building.ExitsChoiceInfo();
            ExitsChoice.AddOptions(exitsInfo);
            if(PlayerPrefs.HasKey("HeaterExit")){

            }
        }
    }

    public void ActivateReaction(){
        canvas.gameObject.SetActive(false); //отключаем канвас
        is_canvas_activated = false;
    }

    public void CheckChosenAction(){ // проверка при выборе действия (всегда в одном порядке: 1 - с параметром; 2 - без параметра)
        if(ActionsChoice.value == 0){
            action = "Нагреть";
            parameterInput.gameObject.SetActive(true);
        } else if(ActionsChoice.value == 1){
            action = "Расплавить";
            parameterInput.gameObject.SetActive(false);
        } else if(ActionsChoice.value == 2){
            action = "Удалить остатки";
            parameterInput.gameObject.SetActive(false);
        }
    }
    
    public void ParameterInputResult(){
        parameter = Convert.ToInt32(parameterInput.text);
        Debug.Log(parameter);
    }

}
