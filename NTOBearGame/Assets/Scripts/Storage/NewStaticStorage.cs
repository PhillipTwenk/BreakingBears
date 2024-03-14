using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

[CreateAssetMenu(fileName = "NewStaticStorage", menuName = "AllVariables", order = 1)]
public class NewStaticStorage : ScriptableObject
{
    [SerializeField] public List<GameObject> AllGameObjects;
}
