using UnityEngine;

public class Gizmos : MonoBehaviour
{
    //Public Atributes
    public Vector2 point1;
    public Vector2 point2;

    public Transform cubo; //aquí arrastramos el transform del cubo que estamos usando. SÓLO PARA MÉTODO 1 DE MOVER EL CUBO.

    public bool MovemosCubo;
    public bool PintamosLínea;
    public bool pintamosUnaCruz;
    public bool ColoreaamosunaLinea;
    public bool DireccionamosPuntoOrigen;
    public bool DibujamosEjesLocalesCubo;

    // Update is called once per frame
    void Update()
    {
        if(MovemosCubo == true)
        {
            MoverCubo();
            MovemosCubo = false;
        }

        if(PintamosLínea == true)
        {
            PintarLínea();
        }

        if (pintamosUnaCruz == true)
        {
            PintarunaCruz();
        }

        if(ColoreaamosunaLinea == true)
        {
            ColorearLinea();
        }

        if(DireccionamosPuntoOrigen == true)
        {
            DireccionPuntoOrigen();
        }

        if(DibujamosEjesLocalesCubo == true)
        {
            DibujarEjesLocalesCubo();
        }    
    }


    void MoverCubo() 
    {
        int variableAleatoria = UnityEngine.Random.Range(1, 3); //Da un valor aleatorio a la variable. 

        if(variableAleatoria == 1)
        {
            //Movemos el cubo de posición. Método 1:
            cubo.position = new Vector2(5, 5); //El cubo se posicionará en el punto 5,5.
            print("Has usado el método 1 y la variable aleatoria vale: " + variableAleatoria);
        }

        if (variableAleatoria == 2)
        {
            //Movemos el cubo de posición. Método 2:
            transform.position = new Vector2(5, 5); //El cubo se posicionará en el punto 5,5 sin necesidad de crear el public transform.
            print("Has usado el método 2 y la variable aleatoria vale: " + variableAleatoria);
        }


        
    }

    void PintarLínea()
    {
        //Pintamos una lía del punto 1 al punto 2
        Debug.DrawLine(point1, point2); //Debug.DrawLine puede recibir tres parametros, pero vamos a empezar con dos.


    }

    void PintarunaCruz()
    {
        // Con esto pintamos una cruz
        Debug.DrawLine(new Vector2(0, 0), new Vector2(2, 2)); //esta será la primera linea de la cruz
        Debug.DrawLine(new Vector2(2, 0), new Vector2(0, 2)); //y esta la segunda linea.
    }

    void ColorearLinea()
    {
        //Tercer parámetro del DrawLine
        Debug.DrawLine(point1, point2, Color.red); //esto coloreará la linea de color rojo.

    }

    void DireccionPuntoOrigen()
    {
        //Le damos a una direccion a un punto de Origen con DrawRay
        Debug.DrawRay(point1, Vector2.up, Color.green); //con esto lanzamos un rayo verde hacia arriba. Debug.DrawRay(punto de origen, direccion, color)
    }

    void DibujarEjesLocalesCubo()
    {
        //Dibujamos los ejes LOCALES del cubo
        Debug.DrawRay(transform.position, transform.up, Color.green); //Eje Y en color verde.
        Debug.DrawRay(transform.position, transform.right, Color.red); //Eje X en color rojo.
        Debug.DrawRay(transform.position, transform.forward, Color.blue); //Eje Z en color azul.
    }

}
