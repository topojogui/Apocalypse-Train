using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 objetivo;  // Objeto que seguir� la c�mara
    public Vector3 offset = new Vector3(0f, 16.6f, -12f);  // Offset de la c�mara con respecto al objetivo
    public float camMovSpeed = 7.5f;  // Velocidad de rotaci�n de la c�mara

   
    void Update()
    {
        // Calcular la posici�n deseada de la c�mara con respecto al objetivo
        Vector3 posicionDeseada = objetivo + offset;

        // Interpolar suavemente la posici�n actual de la c�mara hacia la posici�n deseada
        transform.position = Vector3.Lerp(transform.position, posicionDeseada, camMovSpeed * Time.deltaTime);
    }

    public void SetCameraToPlayer(Vector3 point)
    {
        objetivo = point;
    }

    public void SetCameraToWagon(Vector3 point)
    {
        objetivo = point;
    }


}
