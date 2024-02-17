using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TrainStats", menuName = "ScriptableObjects/TrainStats", order = 1)]
public class Scriptable_TrainStats : ScriptableObject
{
    public string locomotiveName = "Thomas";
    public GameObject prefab;
    public float wagonLength;
    [Space(10)]

    public float maxFuelConsumption;
    public float maxSpeed;
    public float maxCarryingWeight;
}
