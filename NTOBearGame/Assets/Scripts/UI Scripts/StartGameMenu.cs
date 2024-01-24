using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StartGameMenu : MonoBehaviour
{
    public GameObject CanvasMain, CanvasMenus, CanvasStartGame, Buildings;
    void Start()
    {
        CanvasStartGame.SetActive(true);
        CanvasMain.SetActive(false);
        CanvasMenus.SetActive(false);
        Buildings.SetActive(false);
        StaticStorage.IsInStartMenu = true;
        MusicController.StartMusicInStartGame();
    }
    public void ClickStartButton(){
        CanvasMain.SetActive(true);
        CanvasMenus.SetActive(true);
        Buildings.SetActive(true);
        gameObject.SetActive(false);
        Debug.Log(1);
        CanvasStartGame.SetActive(false);
        Debug.Log(2);
        StaticStorage.IsInStartMenu = false;
        MusicController.StartMusicInLab();
        StaticStorage.ChatSystemRefStatic.StartCoroutineMethod(10);
    }
}
