using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EmergencyStopController : MonoBehaviour, IInteractable
{
    private LocomotiveController locom;

    private void Awake()
    {
        locom = GetComponentInParent<LocomotiveController>();
    }
    public void InteractPossitive()
    {
        locom.EmergencyStop();
    }
    public void InteractNegative()
    {
        return;
    }
}
