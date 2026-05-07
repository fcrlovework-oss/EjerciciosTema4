using UnityEngine;

public class Espacio2D : MonoBehaviour
{
    //Public Atributes

    //Ahora referenciamos un componente entero:
    public Transform playerTransform;  //con esto podremos editar el conmponente Transform del objeto que arrastremos a este espacio en el editor.
    public Vector3 punto2 = new Vector2(5,0);

    //Creamos esta variable para acceder al transform de la esfera.
    public Transform sphereTransform;
    
    //Construimos un nuevo objeto de tipo Vector2 y lo inicializamos a x (10), y (0).
    public Vector2 punto1 = new Vector2 (10, 0);

    //Creamos variables para jugar manualmente con el movimiento.
    public float speed;
    public float speedX;
    public float speedY;
    public float speedZ;

    //Creamos la variable para velocidad de rotacion.
    public float speedRotationSphere;

    //Creamos variables para manejar la rotacion manual del objeto.
    public float speedRotation;

    //Privates Atributes

    //Creamos esta variable para pasar el parametro de angulo de rotacion.
    private float rotationAngle = 0;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Accedemos a las posiciones de 0.punto1.
        print("Pos x: " + punto1.x + ", pos y: " + punto1.y);

    }

    // Update is called once per frame
    void Update()
    {
        //Movemos el objeto a la ubicacion guardada en una variable. Como ambas son Vector3 (tambien funciona si es Vector2), funciona.
        //Al asociarle una variable pública, podemos mover el objeto manualmente desde el editor.
        playerTransform.position = punto2;

        //Ahora queremos que se mueva de forma automática.
        //Right represente el eje de coordenadas X.
        punto2 += Vector3.right * Time.deltaTime;

        //Up represente el eje de coordenadas Y.
        punto2 += Vector3.up * Time.deltaTime;
        
        //Right represente el eje de coordenadas Z.
        punto2 += Vector3.forward * Time.deltaTime; 

        //Aquí mostramos la forma correcta de moverse, usando Translate.
        playerTransform.Translate(speed * Time.deltaTime, 0, 0); //Con esto convertimos el valor de speed en la velocidad metro segundo en el eje X (x, y, z).

        //Para moverlo en diagonal:
        playerTransform.Translate(0, speed * Time.deltaTime, speed * Time.deltaTime);

        //Tambien podemos darle direcciones
        //al modificar el valor del speed podemos cambiar su velocidad e incluso la dirección hacia la izquierda:
        playerTransform.Translate(Vector3.right * Time.deltaTime * speed); 

        //Al crear variables X, Y, Z podemos mover mucho más el objeto.
        playerTransform.Translate(Vector3.right * Time.deltaTime * speedX); 
        playerTransform.Translate(Vector3.forward * Time.deltaTime * speedZ);
        playerTransform.Translate(Vector3.up * Time.deltaTime * speedY);

        //Con Rotate y la variable, podemos controlar la rotacion del objeto.
        //Al multiplicar por Time.deltaTime, manejamos la velocidad de rotacion e incluso el sentido.
        playerTransform.Rotate(speedRotation * Time.deltaTime, 0, 0); //Rotación en un eje.

        //Con estas variables combinadas, podemos hacer que se mueva en circulos.
        playerTransform.Rotate(speedRotation * Time.deltaTime, 0, 0);
        playerTransform.Translate(Vector3.right * Time.deltaTime * speedX);

        //Así rota sobre si mismo sobre un mismo eje.
        playerTransform.Rotate(Vector3.right * speedRotation * Time.deltaTime); //así es mas claro  leer.

        //Rotacion de la esfera alrededor del playerTransform.
        //(Vector3 alrededor de que rota, eje de rotacion Vector3, cantidad de rotacion float)
        sphereTransform.RotateAround(playerTransform.position, Vector3.forward, rotationAngle * Time.deltaTime * speedRotationSphere); 
        rotationAngle++; //Esto aumentará la velocidad poco a poco.
    
    }
}
