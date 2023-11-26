using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UIController : MonoBehaviour
{
    public GameObject[] ArrayButtonsMain;
    public GameObject[] ArrayMenus;
    public Transform characterPosition;
    public Transform CameraPosition;
    public Transform[] CheckPointArrayPosition;
    private void Start()
    {
    }
    #region Buttons Methods
    public void MapButtonOpen(){
        //Activation Map
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(true);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[4].SetActive(false);
    }
    public void ChatButtonOpen(){
        //Activation chat 
        ArrayMenus[0].SetActive(true);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[3].SetActive(false);
        ArrayButtonsMain[4].SetActive(false);
    }
    public void ListButtonOpen(){
        //Activation list with Chemical elements
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(true);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[4].SetActive(false);
    }
    public void BriefcaseButtonOpen(){
        //Activation our portable briefcase
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
    }
    public void NotificationButtonOpen(){
        //Activation chat
        ArrayMenus[0].SetActive(true);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[3].SetActive(false);
        ArrayButtonsMain[5].SetActive(true);
        ArrayButtonsMain[4].SetActive(false);
    }
    public void CloseButton(){
        //Activation chat
        ArrayMenus[0].SetActive(false);
        ArrayMenus[1].SetActive(false);
        ArrayMenus[2].SetActive(false);
        ArrayMenus[3].SetActive(false);
        ArrayButtonsMain[0].SetActive(true);
        ArrayButtonsMain[1].SetActive(true);
        ArrayButtonsMain[2].SetActive(true);
        ArrayButtonsMain[4].SetActive(true);
    }
    public void MarkOne(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[0].position.x, CheckPointArrayPosition[0].position.y, CheckPointArrayPosition[0].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkTwo(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[1].position.x, CheckPointArrayPosition[1].position.y, CheckPointArrayPosition[1].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkThree(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[2].position.x, CheckPointArrayPosition[2].position.y, CheckPointArrayPosition[2].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkFour(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[3].position.x, CheckPointArrayPosition[3].position.y, CheckPointArrayPosition[3].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkFive(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[4].position.x, CheckPointArrayPosition[4].position.y, CheckPointArrayPosition[4].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkSix(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[5].position.x, CheckPointArrayPosition[5].position.y, CheckPointArrayPosition[5].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkSeven(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[6].position.x, CheckPointArrayPosition[6].position.y, CheckPointArrayPosition[6].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    public void MarkHome(){
        Vector3 newPositionCharacter = new Vector3(CheckPointArrayPosition[7].position.x, CheckPointArrayPosition[7].position.y, CheckPointArrayPosition[7].position.z + 5);
        characterPosition.position = newPositionCharacter;
        Vector3 newCamPosition = new Vector3(characterPosition.position.x, characterPosition.position.y, characterPosition.position.z);
        CameraPosition.position = newCamPosition;
        ArrayMenus[1].SetActive(false);
    }
    #endregion
}
