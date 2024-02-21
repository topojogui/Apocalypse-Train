using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LocomotiveController : MonoBehaviour
{
    public Scriptable_TrainStats trainStats;
    public Transform backChainPoint;
    public OvenManager ovenManager;
    public EngineController engineController;

    [Space(15)]
    [Header("Status")]
    public int gear = 0;
    public int direction = 0;
    public bool emergencyStop = false;
    

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

    public void ChangeGear(int change)
    {
        gear = Mathf.Min(3, Mathf.Max(-1, this.gear + change));
    }

    public void ChangeDirection(int dirChange)
    {
        direction = Mathf.Min(1, Mathf.Max(-1, this.direction + dirChange));
    }

    public void EmergencyStop()
    {
        emergencyStop = true;
    }
}
 