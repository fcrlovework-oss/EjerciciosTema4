using UnityEngine;

public class DireccionVector : MonoBehaviour
{
    //Public Atributtes
    public Vector3 finalPos;
    public Vector3 initialPos;
    //Ahora creamos dos variables para almacenar el transform de dos objetos.
    public Transform finalTranform;
    public Transform initialTranform;

    //Siempre que generamos un movimiento, se debe configurar la velocidad.
    public float speed = 1;



    //Private Atributtes
    //Este será el vector direccion y por eso lo hacemos privado, es un cálculo.
    private Vector3 _directionVector;
    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Con esta fórmula se calcula la dirección desde un punto de origen a un destino
        _directionVector = finalPos - initialPos;

        //Con la misma formula anterior, calculamos la dirección entre el transform.position de dos objetos.
        _directionVector = finalTranform.position - initialTranform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //Visualizamos el Vector dirección, dibujando una raya entre (x, y).
        //Vector.zero es lo mismo que escribir "new Vector3(0, 0, 0)".
        Debug.DrawRay(Vector3.zero, _directionVector);

        //dibujamos una raya entre ambos objetos con ayuda del Vector dirección.
        Debug.DrawRay(initialTranform.position, _directionVector);

        //Movemos el objeto inicial, se translada en esa dirección para siempre:
        initialTranform.Translate(_directionVector * Time.deltaTime * speed);

        //Si recolocamos aqui esta formula, un objeto perseguirá al otro alla adonde se mueva.
        _directionVector = finalTranform.position - initialTranform.position;

        //Una de las caracteristicas que tiene Vector3 es su magnitud. Vamos a imprimirla.
        //La magnitud es su intensidad, cuanto más pequeño es el Vector, más lento se mueve.. 
        print("Magnitud: " + _directionVector.magnitude);

        //Para que la traslación fuera siempre igual, normalizamos el Vector, lo hacemos unitario y se mueve todo el rato a la misma velocidad:
        _directionVector.Normalize(); 
        Debug.DrawRay(initialTranform.position, _directionVector * speed); //Se moverá a la velocidad indicada.

        //Calculamos la distancia entre dos objetos y la imprimimos:
        print("Magnitud: " + _directionVector.magnitude * speed); //La multiplicamos por la speed para poder verla.
        float distance = Vector3.Distance(initialTranform.position, finalTranform.position); 
        print("Distance: " + distance);

        //Creamos un pequeño sistema de patrulla, haciendo que cambie de dirección a cierta distancia.
        if (distance < 10 || distance > 20)
        {
            speed *= -1;//al multiplicar por -1 la velocidad, el objeto se moverá en direccion contraria.
        }

        





    }
}
