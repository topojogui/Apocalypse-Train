using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpeedController : MonoBehaviour, IInteractable
{
    private LocomotiveController locom;

    private void Awake()
    {
        locom = GetComponentInParent<LocomotiveController>();
    }
    public void InteractPossitive()
    {
        locom.ChangeGear(1);
    }
    public void InteractNegative()
    {
        locom.ChangeGear(-1);
    }

    

   
}
