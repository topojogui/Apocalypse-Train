using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OvenManager : MonoBehaviour, IInteractable
{
    private float currentFuel;


    public void InteractPossitive()
    {
        print("oven");
    }
    public void Initialize(float maxFuel)
    {
        currentFuel = maxFuel;
    }

    public void InteractNegative()
    {

    }

    public void BurnResources(float resourceAmount)
    {
        // L�gica para quemar recursos y obtener combustible
        currentFuel += resourceAmount;
    }

    public void UpdateFuelConsumption(int speedLevel, float maxSpeed)
    {
        // L�gica para ajustar el consumo de combustible seg�n la velocidad
        float consumptionRatio = speedLevel / (float)maxSpeed;
        currentFuel -= consumptionRatio;
    }
}
