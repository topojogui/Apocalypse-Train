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
        // Inicializar el motor con la velocidad m�xima
        currentSpeed = maxSpeed;
    }

    public void UpdateSpeed(int speedLevel)
    {
        // L�gica para actualizar la velocidad del motor
        // Puedes usar speedLevel y ajustar seg�n sea necesario
        switch (speedLevel)
        {
            case 0:
                currentSpeed = 0f; // Detener el tren
                break;
            case 1:
                // L�gica para velocidad suave
                break;
            case 2:
                // L�gica para velocidad media
                break;
            case 3:
                // L�gica para velocidad alta
                break;
            default:
                break;
        }
    }
}
