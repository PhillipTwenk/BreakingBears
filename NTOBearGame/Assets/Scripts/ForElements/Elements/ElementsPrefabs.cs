using System;
using System.Collections.Generic;
using UnityEngine;
using System.Data;

[CreateAssetMenu(fileName = "new ElementPrefabs", menuName = "ElementPrefabs", order = 51)]
public class ElementsPrefabs : ScriptableObject
{
    [SerializeField] public List<GameObject> elements_prefabs;
}
