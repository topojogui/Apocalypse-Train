using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class TrainManagement : MonoBehaviour
{
    public Scriptable_TrainStats locomoStats;
    public List<Scriptable_WagonStats> listaVagones;     // Lista de tipos de vagones
    public SplineContainer spline;

    private GameObject lastWagon; // Referencia al �ltimo vag�n instanciado
    private Transform lastWagonRearPoint; // Punto trasero del �ltimo vag�n
    private void Start()
    {
        BuildTrain();
    }

    private void BuildTrain()
    {
        // Instanciar locomotora
        GameObject newLocomotive = Instantiate(locomoStats.prefab, transform.position, transform.rotation);
       
        newLocomotive.GetComponent<movementTest>().rail = spline;
        
        newLocomotive.transform.parent = transform;
        lastWagon = newLocomotive; // La locomotora es el �ltimo vag�n por ahora        
        lastWagonRearPoint = lastWagon.GetComponent<LocomotiveController>().backChainPoint;
        // Instanciar los vagones
        foreach (Scriptable_WagonStats wagonStats in listaVagones)
        {
            // Instanciar el prefab del vag�n actual
            GameObject newWagon = Instantiate(wagonStats.prefab, lastWagonRearPoint.position, lastWagonRearPoint.rotation);


            newWagon.GetComponent<movementTest>().rail = spline;
            
            // Ajustar la posici�n del nuevo vag�n para que su frontChain coincida con el backChain de la locomotora
            Vector3 displacement = newWagon.GetComponent<WagonChain>().frontChainPoint.position - newWagon.transform.position;
            newWagon.GetComponent<WagonChain>().frontWagon = lastWagon;
            newWagon.transform.position -= displacement;

            // Enganchar el nuevo vag�n al �ltimo vag�n
            newWagon.transform.parent = transform;

            // Actualizar la referencia al �ltimo vag�n instanciado
            lastWagon = newWagon;
            lastWagonRearPoint = lastWagon.GetComponent<WagonChain>().backChainPoint; // Actualizar el punto trasero del �ltimo vag�n
        }
    }
}



