using UnityEngine;

public class MovimientoPlayerFinal : MonoBehaviour
{
    //Atributo publicos
    public Transform PlayerDrone;
    public Transform Camara;
    public float sensibilidadRaton;
    public float playerSpeed;
    public bool rotacionCamara;

    //Atributos Privados
    InputSystem_Actions playerActions;
    Vector2 moveInputPlayer;
    Vector2 LookInputCamara;
    float flyInputPlayer;
    float zoomCamara;

    private void Awake()
    {
        playerActions = new InputSystem_Actions();
    }

    private void OnEnable()
    {
        playerActions.Enable();
    }
    private void OnDisable()
    {
        playerActions.Disable();
    }

    private void Update()
    {
        //Creamos el zoom de la camara:
        Vector3 posicionCamara = Camara.localPosition;
        zoomCamara = playerActions.Player.Zoom.ReadValue<float>();

        posicionCamara.z += zoomCamara;
        Camara.localPosition = posicionCamara;

        //Coordenadas de la camara:
        Vector3 right = Camara.right;
        Vector3 forward = Camara.forward;
        right.y = 0f;
        forward.y = 0f;
        right.Normalize();
        forward.Normalize();

        //Creamos el movimiento del Player y de la camara:
        moveInputPlayer = playerActions.Player.Move.ReadValue<Vector2>();
        flyInputPlayer = playerActions.Player.Fly.ReadValue<float>();
        LookInputCamara = playerActions.Player.Look.ReadValue<Vector2>();

        Vector3 movimientoDron = 
            right * moveInputPlayer.x +
            Vector3.up * flyInputPlayer +
            forward * moveInputPlayer.y;
        
        movimientoDron.Normalize();
        PlayerDrone.transform.position += movimientoDron * playerSpeed * Time.deltaTime;
    
        if (rotacionCamara == true)
        {
            float mouseX = LookInputCamara.x;
            float mouseY = LookInputCamara.y;

            PlayerDrone.Rotate(Vector3.up * mouseX);
            Camara.Rotate(Vector3.right * mouseY);
        }
        

    }
}
