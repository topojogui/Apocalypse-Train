using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "WagonStats", menuName = "ScriptableObjects/WagonStats", order = 2)]
public class Scriptable_WagonStats : ScriptableObject
{
    public string locomotiveName = "Wagon";
    public GameObject prefab;
    public float wagonLength;


}
