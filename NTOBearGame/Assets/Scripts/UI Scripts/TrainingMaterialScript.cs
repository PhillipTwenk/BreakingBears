using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TrainingMaterialScript : MonoBehaviour
{
    public Image[] SlidesMainTutorial;
    public Image[] SlidesEquipmentTutorial;
    public Image Next;
    private int OnWhichSlide;
    private bool IsWhichTutorialActive;
    public GameObject TutorialActive;
    public GameObject CloseButton;
    public void ClickMainTutorial(){
        TutorialActive.SetActive(true);
        CloseButton.SetActive(true);
        Next.enabled = true;
        Building.is_agregat_canvas_activated = true;
        OnWhichSlide = 0;
        IsWhichTutorialActive = true;
        foreach (Image item in SlidesMainTutorial)
        {
            item.enabled = false;
            if(SlidesMainTutorial[OnWhichSlide].enabled == false)
            {
                item.enabled = true;
                Debug.Log(1);
            }
        }
    }
    public void ClickEquipmentTutorial(){
        TutorialActive.SetActive(true);
        CloseButton.SetActive(true);
        Next.enabled = true;
        Building.is_agregat_canvas_activated = true;
        OnWhichSlide = 0;
        IsWhichTutorialActive = false;
        foreach (Image item in SlidesEquipmentTutorial)
        {
            item.enabled = false;
            if(SlidesEquipmentTutorial[OnWhichSlide].enabled == true)
            {
                item.enabled = true;
                Debug.Log(1);
            }
        }
    }
    public void ClickNext(){
        OnWhichSlide += 1;
        if (IsWhichTutorialActive)
        {
            foreach (Image item in SlidesMainTutorial)
            {
                item.enabled = false;
                if(SlidesMainTutorial[OnWhichSlide].enabled == false)
                {   
                    item.enabled = true;
                }
            }
        }
        if (!IsWhichTutorialActive)
        {
            foreach (Image item in SlidesEquipmentTutorial)
            {
                item.enabled = false;
                if(SlidesEquipmentTutorial[OnWhichSlide].enabled == true)
                {
                    item.enabled = true;
                }
            }
        }
    }
    public void ClickBack(){
        OnWhichSlide -= 1;
        if (IsWhichTutorialActive)
        {
            foreach (Image item in SlidesMainTutorial)
            {
                item.enabled = false;
                if(SlidesMainTutorial[OnWhichSlide].enabled == false)
                {
                    item.enabled = true;
                }
            }
        }
        if (!IsWhichTutorialActive)
        {
            foreach (Image item in SlidesEquipmentTutorial)
            {
                item.enabled = false;
                if(SlidesEquipmentTutorial[OnWhichSlide].enabled == true)
                {
                    item.enabled = true;
                }
            }
        }
    }
}
