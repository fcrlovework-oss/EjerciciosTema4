using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoPlayerPrueba : MonoBehaviour
{
    //aquí colocamos al player:
    public Transform originalPlayer;

    //Con esto tienes acceso a todos los movimientos de la Clase del InputSystem.
    InputSystem_Actions playerDrone;
    
    //Guarda el input de movimiento
    Vector2 moveInput;
    
    //Guarda el movimiento y la sensibilidad del Ratón
    Vector2 lookInput;
    public float mouseSensibility = 100f;

    //Guardamos la velocidad del Dron:
    public float moveSpeed = 5f;

    //Aquí guardaremos la camara, su rotación para usarla en el codigo:
    //Lo necesitamos para usar forward y right
    public Transform cameraTransform;
    float cameraXRotation = 0f; //Rotacion Vertical: sirve para mirar hacia arriba y hacia abajo.

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    //Awake ocurre al iniciar el objeto, se crea la clase Inputs aquí.
    private void Awake()
    {
        playerDrone = new InputSystem_Actions();
    }

    //Activamos los inputs, el Input System necesita habilitarse manualmente.
    private void OnEnable()
    {
        playerDrone.Enable();
    }

    //Esto desactiva los inputs cuando el objeto desaparece
    //evita errores y consumo innecesario:
    private void OnDisable()
    {
        playerDrone.Disable();
    }

    void Update()
    {
        moveInput = playerDrone.Player.Move.ReadValue<Vector2>(); //Lee el valor actual del input Move.
        lookInput = playerDrone.Player.Look.ReadValue<Vector2>(); //Lee el movimiento del ratón.
        float verticalInput = 0f;

        //si la tecla de Space se está pulsando, subes.
        if (moveInput.y > 0)
        {
            verticalInput = 1f;
        }

        //Si Ctrl se está pulsando, bajas.
        if (moveInput.y < 0)
            verticalInput = -1f;

        //Ahora configuramos las dirección de hacia delante y a la derecha.
        Vector3 forward = cameraTransform.forward;
        Vector3 right = cameraTransform.right;

        //Quitamos movimiento vertical camara.
        //No mirará hacia arriba ni hará volar al personaje de forma accidental.
        forward.y = 0f;
        right.y = 0f;

        //Normalizamos, convirtiendo el tamaño de los Vectores en 1. 
        //evita velocidades raras.
        forward.Normalize();
        right.Normalize();

        //Direccion Final del drone, adelante/lados/arriba,abajo:
        Vector3 moveDirection =
            forward * moveInput.y +
            right * moveInput.x +
            Vector3.up * verticalInput;

        //Movimiento del drone/cubo:
        originalPlayer.transform.position += moveDirection * moveSpeed * Time.deltaTime;

        //Movimiento horizonral y vertical del ratón (Rotacion Ratón):
        float mouseX = lookInput.x * mouseSensibility * Time.deltaTime;
        float mouseY = lookInput.y * mouseSensibility * Time.deltaTime;

        //Rotación Horizontal y Vertical del personaje:
        originalPlayer.transform.Rotate(Vector3.up * mouseX);
        cameraXRotation -= mouseY;

        //Impedimos girar la camara completamente:
        cameraXRotation = Mathf.Clamp(cameraXRotation, -90f, 90f);

        //Aplicamos la rotación vertical a cámara:
        cameraTransform.localRotation =
            Quaternion.Euler(cameraXRotation, 0f, 0f);
    }
}
