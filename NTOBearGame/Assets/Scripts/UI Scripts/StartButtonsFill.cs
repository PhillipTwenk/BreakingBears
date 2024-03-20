using UnityEngine;
using UnityEngine.EventSystems;

public class StartButtonsFill : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    [SerializeField] private GameObject TargetFill;
    public void OnPointerEnter(PointerEventData eventData)
    {
        TargetFill.SetActive(true);
    }
    public void OnPointerExit(PointerEventData eventData)
    {
        TargetFill.SetActive(false);
    }
}
