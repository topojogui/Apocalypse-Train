using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EngineController : MonoBehaviour, IInteractable
{
    public float currentSpeed;


    public void InteractPossitive()
    {
        print("engine");
    }

    public void InteractNegative()
    {
       
    }
    public void Initialize(float maxSpeed)
    {
        // Inicializar el motor con la velocidad máxima
        currentSpeed = maxSpeed;
    }

    public void UpdateSpeed(int speedLevel)
    {
        // Lógica para actualizar la velocidad del motor
        // Puedes usar speedLevel y ajustar según sea necesario
        switch (speedLevel)
        {
            case 0:
                currentSpeed = 0f; // Detener el tren
                break;
            case 1:
                // Lógica para velocidad suave
                break;
            case 2:
                // Lógica para velocidad media
                break;
            case 3:
                // Lógica para velocidad alta
                break;
            default:
                break;
        }
    }
}
