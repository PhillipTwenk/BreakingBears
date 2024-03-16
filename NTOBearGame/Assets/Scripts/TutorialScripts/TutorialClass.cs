using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using System;

public class TutorialClass: MonoBehaviour
{
    //Обычные переменные
    private int MaxValueTutorial;
    
    //Статические переменные
    public static bool IsInTutorial;
    public static int TutorialCounter;
    public static bool IsTextingMessage;
    public static bool IsTextingMessageBreak;
    public static bool IsNotEnterContinue;
    
    //Игровые объекты
    public GameObject PreTutorialPanel, CanvasTutorial, ProfTutorialPanel, TMProHint;

    //Экземпляры классов
    private QuestClass QuestClassInstance;

    //Массивы / Динамические массивы
    public List<RectTransform> PositionsProfPanelList;

    
    
    
    private void Start()
    {
        QuestClassInstance = new QuestClass();
        MaxValueTutorial = 50;
        IsNotEnterContinue = false;
    }

    //Метод для обновления состояния туториала ( при нажатии Enter появляется новый текст )
    public void UpdateTutorialStage()
    {
        TutorialCounter += 1;
        InputNewTextInProfTutorial();
    }
    
    //Метод для запроса данных из БД для получения текста и запуск корутины печатания текста
    private void InputNewTextInProfTutorial()
    {
        
        string TutorialTextQuery;
        string TutorialTextOnThisStage;
        
        
        //Если сделать запрос больше количество фраз в БД, выдаст ошибку
        if (TutorialCounter <= MaxValueTutorial)
        {
            TutorialTextQuery = $"SELECT Phrase FROM Tutorial_Phrases WHERE id = '{TutorialCounter}'";
            TutorialTextOnThisStage = DBManager.ExecuteQuery(TutorialTextQuery);
        }
        else
        {
            TutorialTextOnThisStage = "";
        }

        //Перемещение панели
        MoveProfPanel();

        //Активация подсказки, если это нужно
        HintActivate();
        
        //Обнуление перед следующим вводом текста
        StaticStorage.TextMProTutorialStatic.text = "";
        
        
        //Запуск корутины ввода текста
        StartCoroutine(TextInputCoroutine(TutorialTextOnThisStage));
    }
    
    //Корутина для "Анимации" печатания текста на панели туториала
    private IEnumerator TextInputCoroutine(string text)
    {
        IsTextingMessage = true;
        foreach (char letter in text)
        {
            StaticStorage.TextMProTutorialStatic.text += letter;
            
            //При повторном нажатии Enter текст заполняется полностью
            if (IsTextingMessageBreak && IsTextingMessage)
            {
                StaticStorage.TextMProTutorialStatic.text = text;
                IsTextingMessageBreak = false;
                break;
            }
            yield return new WaitForFixedUpdate();
        }
        IsTextingMessage = false;
    }

    //Метод для запуска туториала
    public void StartTutorial()
    {
        IsInTutorial = true;
        PreTutorialPanel.SetActive(false);
        ProfTutorialPanel.SetActive(true);
        TutorialCounter = 1;
        Building.is_agregat_canvas_activated = true;
        InputNewTextInProfTutorial();
    }

    //Метод для окончания туториала
    public void EndTutorial(bool IsOnPreTutorialPanel)
    {
        IsInTutorial = false;
        TutorialCounter = 1;
        PreTutorialPanel.SetActive(false);
        ProfTutorialPanel.SetActive(false);
        CanvasTutorial.SetActive(false);
        Building.is_agregat_canvas_activated = false;
        
        //Если мы находимся на панели, где нас спрашивают о прохождении туториала, и нажимаем нет
        if (IsOnPreTutorialPanel)
        {
            QuestClassInstance.TextChanger();
        }
    }
    
    //Метод, перемещающий панель в нужные координаты в зависимости от квеста
    private void MoveProfPanel()
    {
        //Запрос БД о том в каком месте должна находиться панель на данном этапе туториала
        string PositionOnCurrentStageTutorialQuery 
            = $"SELECT PositionInList FROM Tutorial_Phrases WHERE id = '{TutorialCounter}'";
        int PositionOnCurrentStageTutorial = int.Parse(DBManager.ExecuteQuery(PositionOnCurrentStageTutorialQuery));
        
        //Перемещение панели
        ProfTutorialPanel.GetComponent<RectTransform>().position =
            PositionsProfPanelList[PositionOnCurrentStageTutorial].position;
    }
    
    //Методы для продолжения туториала при нажатии какой - либо кнопки
    public void ContinueTutorial(int WhichStage)
    {
        if (TutorialCounter == WhichStage && IsNotEnterContinue)
        {
            IsNotEnterContinue = false;
            UpdateTutorialStage();
            TMProHint.SetActive(false);
        }
    }
    
    //Метод для активирования панели подсказки, когда это неоюходимо
    private void HintActivate()
    {
        //Запрос в БД, чтобы узнать нужно ли и какую фразу нужно вывести в подсказки
        string IsThereActivateRequirementQuery = $"SELECT ActivateRequirement FROM Tutorial_Phrases WHERE id = '{TutorialCounter}'";
        int IsThereActivateRequirement = int.Parse(DBManager.ExecuteQuery(IsThereActivateRequirementQuery));
        
        //Если больше нуля, значит фраза есть
        if (IsThereActivateRequirement > 0)
        {
            //Делаем запрос для получения фразы 
            string WhichPhraseQuery = $"SELECT Hint FROM Hints_Table WHERE id = '{IsThereActivateRequirement}'";
            string WhichPhrase = DBManager.ExecuteQuery(WhichPhraseQuery);
            TMProHint.SetActive(true);
            TMProHint.GetComponent<TextMeshProUGUI>().text = WhichPhrase;
            IsNotEnterContinue = true;
        }
    }
    
    //Метод для добавления тестовых элементов в инвентрарь
    public void AddElementsToItem()
    {
    }
    
}
