using UnityEngine;

public class InputManager : MonoBehaviour
{
    //El objeto InputController controlará todos los inputs que ocurren.
    //Para acceder a Input Manager: Edit > Project Settings > Input Manager.

    //Publis Atributtes:
    public Transform cubeTransform;
    public float speed = 3;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Dibujamos líneas que nacen en nuestro cubo y se extienden en la direccion del eje en horizontal.
        //Axis funciona con strings y es importante copiarlos directamente desde la ventana de InputManager.
        //(Punto inicial, punto final * AxisHorizontal (es un numero)) 
        Debug.DrawRay(cubeTransform.position, Vector3.right * Input.GetAxis("Horizontal"), Color.red);  //****No acabo de entender porque al multiplicar controla los botones.****
        Debug.DrawRay(cubeTransform.position, Vector3.forward * Input.GetAxis("Vertical"), Color.blue);
        //Imprimimos el Axis Horizontal para que podamos ver que es un número.
        print("Horizontal: " + Input.GetAxis("Horizontal"));
        print("Vertical: " + Input.GetAxis("Vertical"));

        //Para acceder a los botones de Fire /devuelve un bool) usamos el siguiente codigo:
        print("Fire: " + Input.GetButtonUp("Fire1")); //clic izquierdo del ratón / Ctrl izquierdo
        print("Fire: " + Input.GetButtonUp("Fire2")); //Alt izquierdo / clic derecho del ratón
        print("Fire: " + Input.GetButtonUp("Fire3")); //Ctrl izquierdo o Command en Mac (depende de plataforma)

        //Este código nos imprime la cantidad de giro de rueda (la del ratón) que tenemos.
        print("Mouse wheel: " + Input.GetAxis("Mouse ScrollWheel"));
        
        //Con este codigo escribimos la velocidad y el movimineto del raton.
        print("Mouse X: " + Input.GetAxis("Mouse X")); //izquierda negativo, derecha positivo
        print("Mouse Y: " + Input.GetAxis("Mouse Y")); //abajo negativo, arriba positivo.

        //Este código dibuja una raya en funcion de la velocidad y movimiento del ratón.
        Debug.DrawRay(cubeTransform.position, Vector3.right * Input.GetAxis("Mouse X"), Color.red);  
        Debug.DrawRay(cubeTransform.position, Vector3.forward * Input.GetAxis("Mouse Y"), Color.red);

        //Ahora aplicamos el movimiento del ratón directamente a la traslación del cubo.
        cubeTransform.Translate(Vector3.right * Input.GetAxis("Mouse X") * Time.deltaTime * speed);
        cubeTransform.Translate(Vector3.forward * Input.GetAxis("Mouse Y") * Time.deltaTime * speed);

        //con este código aplicamos a la traslación del cubo, el movimiento de las teclas (flechas).
        cubeTransform.Translate(Vector3.right * Input.GetAxis("Horizontal") * Time.deltaTime * speed);
        cubeTransform.Translate(Vector3.forward * Input.GetAxis("Vertical") * Time.deltaTime * speed);

        //Con este método corregimos la velocidad del movimiento en diagonal.
        //La forma correcta es juntar ambos movimientos en un único vector y normalizarlo.        
        float horizontal = Input.GetAxis("Horizontal"); //Guardamos estos inputs en float porque devuelven numeros.
        float vertical = Input.GetAxis("Vertical");

        Vector3 movement = new Vector3(horizontal, 0, vertical); //Los juntamos en un Vector, horizontal es el movimiento X y Vertical Z)

        movement = movement.normalized; //Lo normalizamos, mantiene la dirección,pero cambia la longitud del vector a 1.

        cubeTransform.Translate(movement * speed * Time.deltaTime);
    }
}
