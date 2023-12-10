using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeadSystem : MonoBehaviour
{
    public Transform CharacterPosition;
    public Transform CameraPosition;
    public Transform[] CPpositionsArray;
    private CheckPointClass CPclass;
    void Start()
    {
        CPclass = new CheckPointClass();
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player"){
            CPclass.DeadTeleportation(CPpositionsArray, CharacterPosition, CameraPosition);
        }
    }
}
