using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TrainController : MonoBehaviour, IInteractable
{
    private int currentSpeedLevel;
    private int currentDirectionLevel;

    public void InteractPossitive()
    {
        print("controls");
    }
    public void InteractNegative()
    {

    }

    public void SetSpeed(int speedLevel)
    {
        // Implementa l�gica para ajustar la velocidad seg�n el nivel recibido
        currentSpeedLevel = Mathf.Clamp(speedLevel, -1, 2);
        // Actualiza la velocidad del tren seg�n sea necesario
        UpdateTrainSpeed();
    }

    public void SetDirection(int directionLevel)
    {
        // Implementa l�gica para ajustar la direcci�n seg�n el nivel recibido
        currentDirectionLevel = Mathf.Clamp(directionLevel, -1, 1);
        // Actualiza la direcci�n del tren seg�n sea necesario
        UpdateTrainDirection();
    }

    private void UpdateTrainSpeed()
    {
        // Implementa l�gica para actualizar la velocidad del tren
        // Puedes usar currentSpeedLevel para determinar la velocidad actual
    }

    private void UpdateTrainDirection()
    {
        // Implementa l�gica para actualizar la direcci�n del tren
        // Puedes usar currentDirectionLevel para determinar la direcci�n actual
    }

    // Otros m�todos relacionados con el tren
}
