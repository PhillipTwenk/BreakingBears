using System.Collections;
using UnityEngine;

public class TutorialClass: MonoBehaviour
{
    public static bool IsInTutorial;
    public static int TutorialCounter;
    public static bool IsTextingMessage;
    public GameObject PreTutorialPanel, CanvasTutorial, ProfTutorialPanel;

    
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
        IsTextingMessage = true;
        foreach (char letter in text)
        {
            StaticStorage.TextMProTutorialStatic.text += letter;
            yield return new WaitForFixedUpdate();
        }
        IsTextingMessage = false;
    }

    //Метод для запуска туториала
    public void StartTutrorial(bool Answer)
    {
        if (Answer)
        {
            IsInTutorial = true;
            PreTutorialPanel.SetActive(false);
            ProfTutorialPanel.SetActive(true);
            TutorialCounter = 1;
            InputNewTextInProfTutorial();
        }
        else
        {
            IsInTutorial = false;
            PreTutorialPanel.SetActive(false);
        }
    }
    
    //Метод для окончания туториала
    public void EndTutrorial()
    {
        IsInTutorial = false;
        TutorialCounter = 1;
        PreTutorialPanel.SetActive(false);
        ProfTutorialPanel.SetActive(false);
        CanvasTutorial.SetActive(false);
    }
    
    //Метод проверки 
}
