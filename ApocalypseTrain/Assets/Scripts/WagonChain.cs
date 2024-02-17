using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonChain : MonoBehaviour
{
    public Transform frontChainPoint;
    public Transform backChainPoint; 
    public GameObject frontWagon;

    private void Start()
    {        
      
    }
    private void Update()
    {
        UpdatePosition();
    }

    private void UpdatePosition()
    {
        if (frontWagon == null)
            return; // Salir si no hay vag�n delantero

        if (frontWagon != null)
        {
            WagonChain scriptWagon = frontWagon.GetComponent<WagonChain>();
            if (scriptWagon != null)
            {
                ////// Ajustar la posici�n del nuevo vag�n para que su frontChain coincida con el backChain del vag�n de adelante
                //float wagonDistance = Vector3.Distance(frontChainPoint.position,backChainPoint.position);
                //Vector3 wagonDirection = frontChainPoint.position - backChainPoint.position;
                //frontChainPoint.position = frontWagon.GetComponent<WagonChain>().backChainPoint.position;
                ////transform.position = Vector3.Lerp(frontWagon.GetComponent<WagonChain>().backChainPoint.position, frontChainPoint.position, (wagonDistance/2)/100);
                //transform.position = wagonPosition;                
                transform.position = frontWagon.GetComponent<WagonChain>().backChainPoint.position;
            }
            else
            {
                LocomotiveController scriptLocomotive = frontWagon.GetComponent<LocomotiveController>();
                float locomotiveDistance = Vector3.Distance(frontChainPoint.position, backChainPoint.position);

                Vector3 locomotiveDirection = frontChainPoint.position - backChainPoint.position;


                //transform.position = wagonPosition;
            }
        }
    }

    private void OnDrawGizmos()
    {
        Gizmos.color = Color.green; // Color de la l�nea del gizmo    
        //// Dibujar la l�nea en el editor
        Gizmos.DrawLine(frontChainPoint.position, backChainPoint.position);
    }
}
