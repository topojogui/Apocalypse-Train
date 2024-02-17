using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class EventManager : MonoBehaviour
{
    public static Action<float> OnTrainSpeedChanged;
    public static Action<int> OnTrainDirectionChanged;

    // Eventos adicionales seg�n sea necesario

    public static void TriggerTrainSpeedChanged(float velocidad)
    {
        OnTrainSpeedChanged?.Invoke(velocidad);
    }

    public static void TriggerTrainDirectionChanged(int direccion)
    {
        OnTrainDirectionChanged?.Invoke(direccion);
    }

    // M�todos de activaci�n adicionales
}
