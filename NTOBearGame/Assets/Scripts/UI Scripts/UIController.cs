using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] ArrayButtonsMain;
    //0 - Chat
    //1 - Map
    //2 - List
    //3 - Notification
    //4 - Case
    //5 - CloseButton
    public GameObject[] ArrayMenus;
    //0 - ChatMenu
    //1 - MapMenu
    //2 - ListMenu
    //3 - CaseMenu
    public Transform characterPosition;
    public Transform CameraPosition;
    public Transform[] CheckPointArrayPosition;
    private QuestClass QuestClassInstance;
    public GameObject DetailPanelObj;
    public GameObject ProgressPanel;
    private void Start()
    {
        QuestClassInstance = new QuestClass();
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Alpha1))
        {
            ChatButtonOpen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha2))
        {
            MapButtonOpen();
        }
        if (Input.GetKeyDown(KeyCode.Alpha3))
        {
            ListButtonOpen();
        }
        if (Input.GetKeyDown(KeyCode.E))
        {
            BriefcaseButtonOpen();
        }
    }
    #region Buttons Methods
    public void MapButtonOpen(){
        // Activation Map
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(true);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[4].SetActive(false);
        ArrayButtonsMain[6].SetActive(false);
        ArrayButtonsMain[7].SetActive(false);
        //ProgressPanel.SetActive(false);
        Building.is_agregat_canvas_activated = true;
        if (PlayerPrefs.GetInt("ProgressInt") == 1)
        {
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
        if (PlayerPrefs.GetInt("ProgressInt") == 7)
        {
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
    }
    public void ChatButtonOpen(){
        // Activation chat 
        ArrayMenus[0].SetActive(true);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[3].SetActive(false);
        ArrayButtonsMain[4].SetActive(false);
        ArrayButtonsMain[6].SetActive(false);
        ArrayButtonsMain[7].SetActive(false);
        ArrayButtonsMain[8].SetActive(false);
        //ProgressPanel.SetActive(false);
        Building.is_agregat_canvas_activated = true;
    }
    public void ListButtonOpen(){
        // Activation list with Chemical elements
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(true);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[4].SetActive(false);
        ArrayButtonsMain[6].SetActive(false);
        ArrayButtonsMain[7].SetActive(false);
        ArrayButtonsMain[8].SetActive(false);
        //ProgressPanel.SetActive(false);
        Building.is_agregat_canvas_activated = true;
        if (PlayerPrefs.GetInt("ProgressInt") == 8)
        {
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
    }
    public void BriefcaseButtonOpen(){
        // Activation our portable briefcase
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(true);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[0].SetActive(false);
        ArrayButtonsMain[1].SetActive(false);
        ArrayButtonsMain[2].SetActive(false);
        ArrayButtonsMain[3].SetActive(false);
        ArrayButtonsMain[4].SetActive(false);
        ArrayButtonsMain[6].SetActive(false);
        ArrayButtonsMain[7].SetActive(false);
        ArrayButtonsMain[8].SetActive(false);
        //ProgressPanel.SetActive(false);
        Building.is_agregat_canvas_activated = true;
    }
    public void CloseButton(){
        // Close All
        Building.is_agregat_canvas_activated = false;
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[0].SetActive(true);
        ArrayButtonsMain[1].SetActive(true);
        ArrayButtonsMain[2].SetActive(true);
        ArrayButtonsMain[4].SetActive(true);
        ArrayButtonsMain[5].SetActive(false);
        ArrayButtonsMain[6].SetActive(true);
        ArrayButtonsMain[7].SetActive(true);
        ArrayButtonsMain[8].SetActive(true);
        DetailPanelObj.SetActive(false);
        ProgressPanel.SetActive(true);
    }
    public void OpenDetailPanel(){

        // Открывает панель описания квеста

        DetailPanelObj.SetActive(true);
        ArrayButtonsMain[4].SetActive(false); //Отключние кнопки, открывающей инвентарь
        ArrayButtonsMain[5].SetActive(true); //Включение кнопки закрытия
        ArrayButtonsMain[6].SetActive(false);
        ArrayButtonsMain[7].SetActive(false);
        ArrayButtonsMain[8].SetActive(false);
        ProgressPanel.SetActive(false);
        Building.is_agregat_canvas_activated = true;
    }
    public void MarksMethod(GameObject ButtonObj){

        // Определение номера метки

        string name = ButtonObj.name;
        char nameNumberChar = name[6];
        int nameNumber = (nameNumberChar - '0') - 1;

        // Перемещение персонажа с камерой в нужные координаты

        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[nameNumber].position.x, CheckPointArrayPosition[nameNumber].position.y, CheckPointArrayPosition[nameNumber].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;

        // Отключение карты

        ArrayMenus[1].SetActive(false);
        ProgressPanel.SetActive(true);
        ArrayButtonsMain[4].SetActive(true);
        switch (nameNumber)
        {
            // Телепортировались в 1 безопасную зону [квест 2]
            case 0:
                if (PlayerPrefs.GetInt("ProgressInt") == 2)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;

            // Телепортировались обратно в комнату [квест 11, 20]
            case 1:
                if (PlayerPrefs.GetInt("ProgressInt") == 11)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;
            case 2:
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;
            case 3:
                if (PlayerPrefs.GetInt("ProgressInt") == 20)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;
            case 4:
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;
            case 5:
                StaticStorage.IsInZone = true;
                StaticStorage.IsInLab = false;
                MusicController.StartMusicInZone();
            break;

            //Телепортировались обратно в лабораторию[квест 6, 18, 27]
            case 6:
                if (PlayerPrefs.GetInt("ProgressInt") == 6)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                if (PlayerPrefs.GetInt("ProgressInt") == 18)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                if (PlayerPrefs.GetInt("ProgressInt") == 27)
                {
                    QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
                }
                StaticStorage.IsInZone = false;
                StaticStorage.IsInLab = true;
                MusicController.StartMusicInLab();
            break;
        }
    }
    #endregion
}
