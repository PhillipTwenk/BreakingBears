using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneController
{
    public static void SwithScene(string NameScene)
    {
        switch (NameScene)
        {
           case "TutorialScene":
               SceneManager.LoadScene("TutorialScene");
               break;
           case "MainScene":
               SceneManager.LoadScene("MainScene");
               break;
        }
    }
}
