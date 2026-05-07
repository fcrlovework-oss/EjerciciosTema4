using UnityEngine;

public class Cube : MonoBehaviour
{
    //EJERCICIO: Dibuja un cubo en tres dimensiones.

    //Private Atributtes
    private Vector3 _side1;
    private Vector3 _side2;
    private Vector3 _side3;
    private Vector3 _side4;
    private Vector3 _side11;
    private Vector3 _side22;
    private Vector3 _side33;
    private Vector3 _side44;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        PosicionandoEsquinasCubo(transform.position);
        LineasCubo();
    }

    void PosicionandoEsquinasCubo(Vector3 origen)
    {
        _side1 = origen + new Vector3 (0, 2, 0);
        _side2 = origen + new Vector3 (2, 2, 0);
        _side3 = origen + new Vector3 (2, 0, 0);
        _side4 = origen + new Vector3 (0, 0, 0);

        _side11 = origen + new Vector3(0, 2, 2);
        _side22 = origen + new Vector3(2, 2, 2);
        _side33 = origen + new Vector3(2, 0, 2);
        _side44 = origen + new Vector3(0, 0, 2);
    }
    
    
    void LineasCubo()
    {
        Debug.DrawLine(_side1, _side2);
        Debug.DrawLine(_side2, _side3);
        Debug.DrawLine(_side3, _side4);
        Debug.DrawLine(_side4, _side1);

        Debug.DrawLine(_side11, _side22);
        Debug.DrawLine(_side22, _side33);
        Debug.DrawLine( _side33, _side44); 
        Debug.DrawLine(_side44, _side11);


        Debug.DrawLine(_side1, _side11);
        Debug.DrawLine(_side2, _side22);
        Debug.DrawLine(_side3, _side33);
        Debug.DrawLine(_side4, _side44);

    }
}
