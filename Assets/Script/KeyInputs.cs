using UnityEngine;

public class KeyInputs : MonoBehaviour 
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        //Aqui podemos comprobar como funcionan los distintos tipos de pulsaciones en teclas.
        //Debemos colocar la pantalla Console en una ventana distinta a la de game, ya que los input solo se detectan en la pantalla Game.
        if (Input.GetKeyDown(KeyCode.Return))
            print("Se ha pulsado enter");

        if (Input.GetKey(KeyCode.Return))
            print("Se está pulsando enter");

        if (Input.GetKeyUp(KeyCode.Return))
            print("Se ha soltado enter");

        //Aqui podemos ver las teclas más usadas:
        if (Input.GetKeyUp(KeyCode.A))
            print("Se ha soltado A");

        if (Input.GetKeyUp(KeyCode.F1))
            print("Se ha soltado F1");
        
        if (Input.GetKeyUp(KeyCode.Space))
            print("Se ha soltado la tecla de espacio");

        if (Input.GetKeyUp(KeyCode.Escape))
            print("Se ha soltado la tecla de Scape");

        if (Input.GetKeyUp(KeyCode.LeftAlt) || Input.GetKeyUp(KeyCode.LeftAlt))
            print("Se ha soltado Alt");

    }
}
