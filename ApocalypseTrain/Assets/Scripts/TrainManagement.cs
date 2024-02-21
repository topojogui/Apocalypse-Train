using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;

public class TrainManagement : MonoBehaviour
{
    public Scriptable_TrainStats locomoStats;
    public List<Scriptable_WagonStats> listaVagones;     // Lista de tipos de vagones
    public SplineContainer spline;

    private GameObject lastWagon; // Referencia al último vagón instanciado
    private Transform lastWagonRearPoint; // Punto trasero del último vagón
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
        lastWagon = newLocomotive; // La locomotora es el último vagón por ahora        
        lastWagonRearPoint = lastWagon.GetComponent<LocomotiveController>().backChainPoint;
        // Instanciar los vagones
        foreach (Scriptable_WagonStats wagonStats in listaVagones)
        {
            // Instanciar el prefab del vagón actual
            GameObject newWagon = Instantiate(wagonStats.prefab, lastWagonRearPoint.position, lastWagonRearPoint.rotation);


            newWagon.GetComponent<movementTest>().rail = spline;
            
            // Ajustar la posición del nuevo vagón para que su frontChain coincida con el backChain de la locomotora
            Vector3 displacement = newWagon.GetComponent<WagonChain>().frontChainPoint.position - newWagon.transform.position;
            newWagon.GetComponent<WagonChain>().frontWagon = lastWagon;
            newWagon.transform.position -= displacement;

            // Enganchar el nuevo vagón al último vagón
            newWagon.transform.parent = transform;

            // Actualizar la referencia al último vagón instanciado
            lastWagon = newWagon;
            lastWagonRearPoint = lastWagon.GetComponent<WagonChain>().backChainPoint; // Actualizar el punto trasero del último vagón
        }
    }
}



