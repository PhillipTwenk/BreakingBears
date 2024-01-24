using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class StartGameMenu : MonoBehaviour
{
    //Получение объектов холстов
    public GameObject CanvasMain, CanvasMenus, CanvasStartGame, Buildings;

    //Ccылка на скрипт CameraController
    public CameraController CameraControllerScriptReference;

    void Start()
    {
        CanvasStartGame.SetActive(true);
        CanvasMain.SetActive(false);
        CanvasMenus.SetActive(false);
        Buildings.SetActive(false);
        StaticStorage.IsInStartMenu = true;
        MusicController.StartMusicInStartGame();
    }

    //Нажатие на кнопку старта
    public void ClickStartButton(){

        //Активирование нужных элементов UI

        CameraControllerScriptReference.StartCameraMovement();

        CanvasMain.SetActive(true);
        CanvasMenus.SetActive(true);
        Buildings.SetActive(true);
        gameObject.SetActive(false);
        CanvasStartGame.SetActive(false);

        StaticStorage.IsInStartMenu = false;

        //Запуск музыкальной темы в лаборатории
        MusicController.StartMusicInLab();

        //Запуск сообщений от профессора
        StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(10);
    }
    public void ClickQuitButton(){

        //Выход из приложения

        Application.Quit();
    }
}
