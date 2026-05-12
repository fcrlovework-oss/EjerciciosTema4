using UnityEngine;

public class Movement : MonoBehaviour
{
    //Public Atributtes:
    public Transform CameraTransform;
    public Transform cube;
    public float speed = 5;
    public float rotationSpeed = 100;
    public float zoomSpeed = 500;
    

    // Update is called once per frame
    void Update()
    {   
        //Le damos movimiento al objeto.b
        //Copiamos y pegamos el codigo de movimiento que creamos en el script "InputManager".
        float horizontal = Input.GetAxis("Horizontal"); 
        float vertical = Input.GetAxis("Vertical");
        Vector3 movement = new Vector3(horizontal, 0, vertical); 
        movement = movement.normalized; 
        cube.Translate(movement * speed * Time.deltaTime);

        //Ahora vamos a hacer que la camara rote alrededor de una posición.
        //Con este codigo logramos que la camara se mueva en el eje horizontal que muevas el ratón y siga al objeto.
        CameraTransform.RotateAround(cube.transform.position, Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);
    
        //Ahora hacemos lo mismo, pero el que rota alrededor de la camara será el player (personaje al que seguía anteriormente).
        cube.transform.Rotate(Vector3.up, Input.GetAxis("Mouse X") * Time.deltaTime * rotationSpeed);

        //Zoom de la camara **¿Como ponerle limites al zoom?**
        CameraTransform.LookAt(cube.position);
        CameraTransform.Translate(CameraTransform.forward * Input.GetAxis("Mouse ScrollWheel") * Time.deltaTime * zoomSpeed);
    }
}
