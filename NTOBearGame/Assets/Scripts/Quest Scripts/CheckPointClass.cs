using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointClass
{
    public void CheckPointStartValue(){
        PlayerPrefs.SetInt("CPCondition", 0);
    }
    
    public int DefiningCheckPoint(GameObject gameObjectCP){

        // Определение номера ЧекПоинта

        string name = gameObjectCP.name;
        char nameNumberChar = name[1];
        int nameNumber = (nameNumberChar - '0') - 1;
        return nameNumber;
    }

    public void ActivationCheckPoint(GameObject Mark){

        //Активация чекпоинта при условии что он ещё не активен

        if(!Mark.active){
            Mark.SetActive(true);
        }
    }

    public void DeleteCPTrigger(SphereCollider TriggerCP){
        if(TriggerCP.enabled == true){
            TriggerCP.enabled = false;
        }
    }
}
