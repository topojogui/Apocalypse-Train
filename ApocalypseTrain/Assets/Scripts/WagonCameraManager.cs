using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WagonCameraManager : MonoBehaviour
{
    [Header("Wagon Info")]   
    public Scriptable_WagonStats wagonInfo;
    [Space(10)]
    [Header("Limites Camara")]
    public float wagonWidth = 40;
    public float wagonLength = 40;
    public Vector3 centerOffset;
    [Space(10)]

    private Transform playerTransform;
    private CameraController cameraScript;
    private Vector3 centro;
    private Vector3 stretchBand;

    private float lerpSpeed = 5f; // Ajusta la velocidad de movimiento

    private void Start()
    {
        // Obtener la cámara principal y los componentes necesarios      
        Camera mainCamera = Camera.main;
        cameraScript = mainCamera.GetComponent<CameraController>();

       
        playerTransform = GameObject.FindGameObjectWithTag("Player").transform; // Ajusta la etiqueta según la del personaje
    }

    private void Update()
    {
        centro = transform.localPosition + centerOffset;
        // Lerp para mover clamp de la cámara hacia el jugador
        stretchBand = Vector3.Lerp(stretchBand, playerTransform.position, lerpSpeed * Time.deltaTime);

        float minX = centro.x - wagonLength / 2f;
        float maxX = centro.x + wagonLength / 2f;
        float minZ = centro.z - wagonWidth / 2f;
        float maxZ = centro.z + wagonWidth / 2f;

        // Limita la posición del Gizmo dentro del cuadrado
        float clampedX = Mathf.Clamp(stretchBand.x, minX, maxX);
        float clampedZ = Mathf.Clamp(stretchBand.z, minZ, maxZ);

        // Aplica la nueva posición al Gizmo
        stretchBand = new Vector3(clampedX, centro.y, clampedZ);
    }

    public void DefinirCamara()
    {
        // Llamada desde: CubeMovement
        // Asigna la cámara al centro desplazable de cada vagon al estar sobre él
        cameraScript.SetCameraToWagon(stretchBand);
    }

    private void OnDrawGizmos()
    {
        // Bola que muestra la posición de la cámara dentro del cuadrado que define el clamp de esta en el vagon
        Gizmos.color = Color.magenta;
        Gizmos.DrawSphere(stretchBand, 0.2f); // Ajusta el tamaño según sea necesario

        // Dibuja el cuadrado por el que se mueve la cámara en el vagon
        Gizmos.color = Color.red;
        Gizmos.DrawWireCube(centro, new Vector3(wagonLength, 4f, wagonWidth));
    }
}
