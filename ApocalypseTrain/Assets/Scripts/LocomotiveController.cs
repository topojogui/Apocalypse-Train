using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveController : MonoBehaviour
{
    public Scriptable_TrainStats trainStats;
    public Transform backChainPoint;
    public OvenManager ovenManager;
    public EngineController engineController;

    private int currentSpeedLevel;

    private void Start()
    {
        // Inicializar componentes y valores iniciales
        ovenManager.Initialize(trainStats.maxFuelConsumption);
        engineController.Initialize(trainStats.maxSpeed);
    }

    public void SetSpeed(int speedLevel)
    {
        // Implementa lógica para ajustar la velocidad según el nivel recibido
        currentSpeedLevel = Mathf.Clamp(speedLevel, 0, 3);

        // Actualiza componentes según sea necesario
        ovenManager.UpdateFuelConsumption(currentSpeedLevel, trainStats.maxSpeed);
        engineController.UpdateSpeed(currentSpeedLevel);
    }
}
 