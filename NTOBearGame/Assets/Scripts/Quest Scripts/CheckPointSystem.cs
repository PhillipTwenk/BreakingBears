using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPointSystem : MonoBehaviour
{
    private CheckPointClass CPclass;
    private int NumberCheckPoint;
    private SphereCollider TriggerCP;
    void Start()
    {
        CPclass = new CheckPointClass();
        TriggerCP = GetComponent<SphereCollider>();
        NumberCheckPoint = CPclass.DefiningCheckPoint(gameObject);
    }
    void OnTriggerEnter(Collider other)
    {
        // Игрок открывает новый чекпоинт

        if (other.gameObject.tag == "Player")
        {
            CPclass.ActivationCheckPoint();
            CPclass.DeleteCPTrigger(TriggerCP);
            CPclass.NewSave(NumberCheckPoint);
        }
    }
}
