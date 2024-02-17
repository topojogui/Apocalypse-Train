using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Vector3 objetivo;  // Objeto que seguirá la cámara
    public Vector3 offset = new Vector3(0f, 16.6f, -12f);  // Offset de la cámara con respecto al objetivo
    public float camMovSpeed = 7.5f;  // Velocidad de rotación de la cámara

   
    void Update()
    {
        // Calcular la posición deseada de la cámara con respecto al objetivo
        Vector3 posicionDeseada = objetivo + offset;

        // Interpolar suavemente la posición actual de la cámara hacia la posición deseada
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
