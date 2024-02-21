using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DirectionController : MonoBehaviour, IInteractable
{
    private LocomotiveController locom;
    private void Awake()
    {
        locom = GetComponentInParent<LocomotiveController>();
    }

    public void InteractPossitive()
    {
        locom.ChangeDirection(1);
    }
    public void InteractNegative()
    {
        locom.ChangeDirection(-1);
    }
}
