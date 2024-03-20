using UnityEngine;

public class HelperController : MonoBehaviour
{
    [SerializeField] private GameObject HelperEmptyForActivation;
    [SerializeField] private GameObject SmallPanel;
    [SerializeField] private GameObject BearOSObject;
    [SerializeField] private GameObject CaseMenuObject;
    private Outline HelperOutline;

    private void Start()
    {
        HelperOutline = GetComponent<Outline>();
        HelperOutline.enabled = false;
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
        HelperEmptyForActivation.SetActive(true);
        SmallPanel.SetActive(false);
        BearOSObject.SetActive(false);
        CaseMenuObject.SetActive(false);
    }
    
    //Выходим из меню Стубуретки
    public void ReturnButton()
    {
        HelperEmptyForActivation.SetActive(false);
        SmallPanel.SetActive(true);
    }
}
