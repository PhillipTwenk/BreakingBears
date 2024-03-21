using System.Collections;
using TMPro;
using UnityEngine;

public class HelperController : MonoBehaviour
{
    [SerializeField] private GameObject HelperEmptyForActivation;
    [SerializeField] private GameObject SmallPanel;
    [SerializeField] private GameObject BearOSObject;
    [SerializeField] private GameObject CaseMenuObject;
    [SerializeField] private GameObject EmptyTextsMeshPro;
    [SerializeField] private Transform MainCharacterTransform;
    [SerializeField] private Transform HeadHelperTransform;
    private Outline HelperOutline;

    private void Start()
    {
        HelperOutline = gameObject.transform.GetChild(1).GetComponent<Outline>();
        HelperOutline.enabled = false;
    }

    private void Update()
    {
        //Стубуретка смотрит на игрока
        
        HeadHelperTransform.LookAt(MainCharacterTransform);
    }
    //Включение / отключение обводки при навведении / убирании курсора мыши
    private void OnMouseEnter()
    {
        HelperOutline.enabled = true;
    }
    private void OnMouseExit()
    {
        HelperOutline.enabled = false;
    }
    
    //Нажимаем на Стубуретку
    private void OnMouseDown()
    {
        StartWorkWithST();
    }
    
    //Выходим из меню Стубуретки
    public void ReturnButton()
    {
        HelperEmptyForActivation.SetActive(false);
        SmallPanel.SetActive(true);
    }

    //Включение панели Стубуретки
    public void StartWorkWithST()
    {
        HelperEmptyForActivation.SetActive(true);
        SmallPanel.SetActive(false);
        BearOSObject.SetActive(false);
        CaseMenuObject.SetActive(false);
        EmptyTextsMeshPro.SetActive(false);
    }

    //Корутина мигания сообщений 
    private IEnumerator CoroutineFadeMessageNewQuest()
    {
        for (int i = 0; i < 6; i++)
        {
            if (i % 2 == 0)
            {
                EmptyTextsMeshPro.SetActive(false);
            }

            if (i % 2 != 0)
            {
                EmptyTextsMeshPro.SetActive(true);
            }
            yield return new WaitForSeconds(0.5f);
        }
    }

    //Метод для запуска корутины мигающий сообщений
    public void StartCoroutineFadeMessageNewQuest()
    {
        EmptyTextsMeshPro.SetActive(true);
        StartCoroutine(CoroutineFadeMessageNewQuest());
    }
    
}
