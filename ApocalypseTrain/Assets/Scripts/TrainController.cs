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
        // Implementa lógica para ajustar la velocidad según el nivel recibido
        currentSpeedLevel = Mathf.Clamp(speedLevel, -1, 2);
        // Actualiza la velocidad del tren según sea necesario
        UpdateTrainSpeed();
    }

    public void SetDirection(int directionLevel)
    {
        // Implementa lógica para ajustar la dirección según el nivel recibido
        currentDirectionLevel = Mathf.Clamp(directionLevel, -1, 1);
        // Actualiza la dirección del tren según sea necesario
        UpdateTrainDirection();
    }

    private void UpdateTrainSpeed()
    {
        // Implementa lógica para actualizar la velocidad del tren
        // Puedes usar currentSpeedLevel para determinar la velocidad actual
    }

    private void UpdateTrainDirection()
    {
        // Implementa lógica para actualizar la dirección del tren
        // Puedes usar currentDirectionLevel para determinar la dirección actual
    }

    // Otros métodos relacionados con el tren
}
