using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CubeMovement : MonoBehaviour
{
    public float movSpeed = 5f; // Velocidad de movimiento del cubo
    public float jumpForce = 10f; // Fuerza del salto
    public float fallSpeed = 2f; // Velocidad de caída

    [SerializeField] private bool onFloor = false; // Variable para controlar si el cubo está en el suelo
    [SerializeField] private bool nearInteractable = false; // Variable para controlar si el cubo está en control de velocidad
    [SerializeField] private bool onWagon = false; // Variable para controlar si el cubo está en el vagón
    [SerializeField] private bool gotTrainScript = false; // Variable para controlar si el cubo está en el vagón

    private Rigidbody rb;       

    private CameraController cameraScript;

    [Space(15)]
    [Header("Detection")]
    public float radioEsfera = 2.0f;
    [SerializeField]
    private GameObject objetoMasCercano;
   


    private void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Obtener la cámara principal y los componentes necesarios      
        Camera mainCamera = Camera.main;
        cameraScript = mainCamera.GetComponent<CameraController>();
    }

    void Update()
    {
        CheckTriggers();
        HandleMovementInput();

        //Detecta los Cambios de camara dependiendo de la posicion del player
        CheckCamera();

        if (Input.GetButtonDown("Jump") && onFloor)
        {
            Jump();
        }

        HandleInteractions();
    }

    private void CheckTriggers()
    {
        // Obtén la posición actual del personaje
        Vector3 posicionPersonaje = transform.position;

        // Reinicia el objeto más cercano
        objetoMasCercano = null;

        //Layer que queremos detectar
        int layerMask = 1 << LayerMask.NameToLayer("Interactable");


        // Usa CheckSphere para detectar objetos en la esfera alrededor del personaje
        Collider[] colliders = Physics.OverlapSphere(posicionPersonaje, radioEsfera, layerMask);
        float distanciaMinima = Mathf.Infinity;

        foreach (Collider collider in colliders)
        {
            // Ignora el collider del objeto que lleva el script
            if (collider == GetComponent<Collider>())
                continue;

            // Calcula la distancia entre el personaje y el objeto actual
            float distancia = Vector3.Distance(posicionPersonaje, collider.transform.position);

            // Verifica si la distancia es menor a la distancia mínima actual
            if (distancia < distanciaMinima)
            {
                distanciaMinima = distancia;
                objetoMasCercano = collider.gameObject;
                IInteractable interactable = objetoMasCercano.GetComponent<IInteractable>();

                if (interactable != null && objetoMasCercano != null)
                {
                    // Acciones para objetos en el layer específico
                    nearInteractable = true;

                }
            }
        }
    }

    private void HandleMovementInput()
    {
        float movimientoHorizontal = Input.GetAxis("Horizontal");
        float movimientoVertical = Input.GetAxis("Vertical");

        Vector3 direccion = new Vector3(movimientoHorizontal, 0f, movimientoVertical);
        transform.Translate(direccion * movSpeed * Time.deltaTime);
    }

    private void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        onFloor = false;
    }

    private void CheckCamera()
    {
        if (!onWagon)
        {
            cameraScript.SetCameraToPlayer(transform.position);
        }
    }

    private void HandleInteractions()
    {
      
        //Interaccion con palanca de Velocidad (boton de interaccion = "E")
        if (nearInteractable && Input.GetButtonDown("Interact"))
        {
            float tipoDeInput = Input.GetAxis("Interact");
            IInteractable interactable = objetoMasCercano.GetComponent<IInteractable>();
            if (interactable != null)
            {
                if (tipoDeInput > 0)
                {
                    //interaccion positiva/subir velocidad
                    interactable.InteractPossitive();

                }
                else if (tipoDeInput < 0)
                {
                    //interaccion negativa/bajar velocidad
                    interactable.InteractNegative();
                }
            }
                
        }
    }

    private void FixedUpdate()
    {
        // Aplicar una fuerza constante para simular la velocidad de caída
        rb.AddForce(Vector3.down * fallSpeed);
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wagon"))
        {
            if (!gotTrainScript)
            {
                gotTrainScript = true;                
            }
            other.gameObject.GetComponentInParent<WagonCameraManager>().DefinirCamara();
            onWagon = true;
        }
        if (other.gameObject.CompareTag("floor"))
        {
            onFloor = true;
        }      
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wagon"))
        {
            onWagon = false;
        }

        if (other.gameObject.CompareTag("floor"))
        {
            onFloor = false;
        }       
    }


    void OnDrawGizmosSelected()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radioEsfera);
    }

}

