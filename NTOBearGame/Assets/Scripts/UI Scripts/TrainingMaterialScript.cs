using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingMaterialScript : MonoBehaviour
{
    public GameObject[] SlidesMainTutorial;
    public GameObject[] SlidesEquipmentTutorial;
    public GameObject Next;
    public GameObject Back;
    private int OnWhichSlide;
    private bool IsWhichTutorialActive;
    public GameObject TutorialMain;
    public GameObject TutorialEquipment;
    public GameObject CloseButton;
    public GameObject ButtonMainTutorial;
    public GameObject ButtonSettings;
    public void ClickMainTutorial(){
        TutorialMain.SetActive(true);
        TutorialEquipment.SetActive(false);
        CloseButton.SetActive(true);
        Next.SetActive(true);
        Building.is_agregat_canvas_activated = true;
        OnWhichSlide = 0;
        IsWhichTutorialActive = true;
        foreach (GameObject item in SlidesMainTutorial)
        {
            item.SetActive(false);
            if(SlidesMainTutorial[OnWhichSlide].activeSelf == false)
            {
                SlidesMainTutorial[OnWhichSlide].SetActive(true);
            }
        }
    }
    public void ClickEquipmentTutorial(){
        TutorialEquipment.SetActive(true);
        TutorialMain.SetActive(false);
        CloseButton.SetActive(true);
        Next.SetActive(true);
        Building.is_agregat_canvas_activated = true;
        OnWhichSlide = 0;
        IsWhichTutorialActive = false;
        foreach (GameObject item in SlidesEquipmentTutorial)
        {
            item.SetActive(false);
            if(SlidesEquipmentTutorial[OnWhichSlide].activeSelf == false)
            {
                SlidesEquipmentTutorial[OnWhichSlide].SetActive(true);
            }
        }
    }
    public void ClickNext(){
        OnWhichSlide += 1;
        if (IsWhichTutorialActive)
        {
            foreach (GameObject item in SlidesMainTutorial)
            {
                item.SetActive(false);
                if(SlidesMainTutorial[OnWhichSlide].activeSelf == false)
                {   
                    SlidesMainTutorial[OnWhichSlide].SetActive(true);
                }
            }
            if (OnWhichSlide == 14)
            {
                Next.SetActive(false);
            }
            if (OnWhichSlide == 1)
            {
                Back.SetActive(true);
            }
        }
    }
    public void ClickBack(){
        OnWhichSlide -= 1;
        if (IsWhichTutorialActive)
        {
            foreach (GameObject item in SlidesMainTutorial)
            {
                item.SetActive(false);
                if(SlidesMainTutorial[OnWhichSlide].activeSelf == false)
                {
                    SlidesMainTutorial[OnWhichSlide].SetActive(true);
                }
            }
            if (OnWhichSlide == 0)
            {
                Back.SetActive(false);
            }
            if (OnWhichSlide == 13)
            {
                Next.SetActive(true);
            }
        }
    }
}
