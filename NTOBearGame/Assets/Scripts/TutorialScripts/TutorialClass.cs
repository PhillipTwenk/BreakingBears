using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class TutorialClass: MonoBehaviour
{
    public static bool IsInTutorial;
    public static int TutorialCounter;

    
    //Метод для обновления состояния туториала ( при нажатии Enter появляется новый текст )
    public void UpdateTutorialStage()
    {
        TutorialCounter += 1;
        InputNewTextInProfTutorial();
    }
    
    //Метод для запроса данных из БД для получения текста и запуск корутины печатания текста
    private void InputNewTextInProfTutorial()
    {
        string TutorialTextQuery = $"SELECT Phrase FROM Tutorial_Phrases WHERE id = '{TutorialCounter}'";
        string TutorialTextOnThisStage = DBManager.ExecuteQuery(TutorialTextQuery);

        StaticStorage.TextMProTutorialStatic.text = "";
        
        StartCoroutine(TextInputCoroutine(TutorialTextOnThisStage));
    }
    
    //Корутина для "Анимации" печатания текста на панели туториала
    private IEnumerator TextInputCoroutine(string text)
    {
        foreach (char letter in text)
        {
            StaticStorage.TextMProTutorialStatic.text += letter;
            yield return new WaitForFixedUpdate();
        }
    }
}
