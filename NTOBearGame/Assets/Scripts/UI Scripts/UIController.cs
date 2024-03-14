using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class UIController : MonoBehaviour
{
    private TextMeshProUGUI AntidoteTextMPro;
    public GameObject AntidotePanelObj;
    public GameObject BriefcaseObj;
    public GameObject BearOSPanel;
    public Transform characterPosition;
    public Transform CameraPosition;
    public Transform[] CheckPointArrayPosition;
    public Transform HomeCheckPoint;
    private QuestClass QuestClassInstance;
    public GameObject DetailPanelObj;
    public GameObject ProgressPanel;
    public GameObject PauseMenu;
    public TextMeshProUGUI TextTeleportButton;
    private void Start()
    {
        AntidoteTextMPro = AntidotePanelObj.transform.GetChild(1).GetComponent<TextMeshProUGUI>();
        QuestClassInstance = new QuestClass();
    }
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.E))
        {
            BriefcaseButtonOpen();
        }
        if(Input.GetKeyDown(KeyCode.Q))
        {
            BearOS();
            AntidotePanel();
        }
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            PauseButton();
        }

        if (Input.GetKeyDown(KeyCode.M))
        {
            Debug.Log("ИСПОЛЬЗОВАНЫ ЧИТ КОДЫ!!!!!!!!!!!");
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
    }
    #region Buttons Methods


    //Выполняется при нажатии на паузу(кнопка esc)
    public void PauseButton(){
        if (StaticStorage.IsPause)
        {
            Time.timeScale = 1f;
        }
        else
        {
            Time.timeScale = 0f;
        }
        PauseMenu.SetActive(!PauseMenu.activeSelf);
        StaticStorage.IsPause = !StaticStorage.IsPause;
        if(BearOSPanel.activeSelf){
            BearOSPanel.SetActive(!BearOSPanel.activeSelf);
        }
        ProgressPanel.SetActive(true);
    }


    //Активация/Дезактивация панели BearOS
    public void BearOS(){
        BearOSPanel.SetActive(!BearOSPanel.activeSelf);
        if(DetailPanelObj.activeSelf){
            DetailPanelObj.SetActive(!ProgressPanel.activeSelf);
        }
        if(BriefcaseObj.activeSelf){
            BriefcaseObj.SetActive(!BriefcaseObj.activeSelf);
        }
        ProgressPanel.SetActive(!ProgressPanel.activeSelf);
        Building.is_agregat_canvas_activated = !Building.is_agregat_canvas_activated;
        if (PlayerPrefs.GetInt("ProgressInt") == 1)
        {
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
        if (PlayerPrefs.GetInt("ProgressInt") == 7)
        {
            QuestClassInstance.StartNewQuest(PlayerPrefs.GetInt("ProgressInt"));
        }
    }

    public void AntidotePanel()
    {
        if (PlayerPrefs.GetInt("ProgressInt") < 19)
        {
            AntidoteTextMPro.text = "NaOCl";
        }
        else
        {
            AntidoteTextMPro.text = "Na₂S₂O₃";
        }
    }

    //Активация / деактивация панели инвентаря
    public void BriefcaseButtonOpen(){
        BriefcaseObj.SetActive(!BriefcaseObj.activeSelf);
        if(BearOSPanel.activeSelf){
            BearOSPanel.SetActive(!BearOSPanel.activeSelf);
        }
        Building.is_agregat_canvas_activated = !Building.is_agregat_canvas_activated;
    }
    

    public void TeleportMethod(){
        int CPNumber = PlayerPrefs.GetInt("CPNumber");
        if (StaticStorage.IsInLab){
            Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[CPNumber].position.x, CheckPointArrayPosition[CPNumber].position.y, CheckPointArrayPosition[CPNumber].position.z + 5);
            characterPosition.position = newPositionCharacter;
            TextTeleportButton.text = "В лабораторию";
            switch (CPNumber)
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
            }
        }
        else{
            Vector3 newPositionCharacter = new Vector3(HomeCheckPoint.position.x, HomeCheckPoint.position.y, HomeCheckPoint.position.z + 5);
            characterPosition.position = newPositionCharacter;
            TextTeleportButton.text = "В Контрольную точку";
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
        }
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        Debug.Log(StaticStorage.IsInLab);

        BearOSPanel.SetActive(false);
        ProgressPanel.SetActive(true);
        DetailPanelObj.SetActive(false);

        Debug.Log(CPNumber);
    }
    #endregion
}
