using UnityEngine;

public class MouseInputs : MonoBehaviour
{
    //Public Atributtes:
    public Transform target;
    
    // Update is called once per frame
    void Update()
    {
        //Para detectar la pulsación del ratón, usamos el siguiente código.
        // 0 = Botón izquierdo / 1 = Botón derecho / 2 = Botón Central.
        //Tanto GetMouseButton como mousePosition, sirven para móvil.
        if (Input.GetMouseButtonUp(0))
            print("Botón Izquierdo");
        if (Input.GetMouseButtonUp(1))
            print("Botón Derecho");
        if (Input.GetMouseButtonUp(0))
            print("Botón Central");

        //Ahora hacemos los mismo pero con GetMousePosition, pero lo ponemos en una impresion directamente.
        //Con este método podemos saber la posición exacta del ratón o del click.
        print("Mouse x: " + Input.mousePosition.x + "/ Mouse y:" + Input.mousePosition.y + "/ Mouse z:" + Input.mousePosition.z);

        //Como darle a un objeto, nuestra posición del ratón:
        //No tendra un movimiento perfecto porque la pantalla Game está en pixeles y el escenario de desarrollo en metros.
        target.position = Input.mousePosition;
    }
}
