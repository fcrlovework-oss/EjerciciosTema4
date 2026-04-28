using UnityEngine;

public class MyName : MonoBehaviour
{
    //EJERCICIO: Usa Gizmos para crear tu nombre.

    //Atributos publicos
    public Transform F;
    public Transform A;
    public Transform T;
    public Transform I;
    public Transform M;
    public Transform SegundaA;


    
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        Posiciones();
    }

    // Update is called once per frame
    void Update()
    {
        LetraF(F.position);
        LetraA(A.position);
        LetraT(T.position);
        LetraI(I.position);
        LetraM(M.position);
        LetraA(SegundaA.position);
    }

    //Métodos privados

    void Posiciones()
    {
        F.position = new Vector2(-5, 0);
        A.position = new Vector2(-3, 0);
        T.position = new Vector2(0, 0);
        I.position = new Vector2(1.5f, 0);
        M.position = new Vector2(2, 0);
        SegundaA.position = new Vector2(4.5f, 0);
    }

    void LetraF(Vector2 origen)
    {
        Debug.DrawLine(origen + new Vector2(0, 0), origen + new Vector2(0, 2));
        Debug.DrawLine(origen + new Vector2(0, 2), origen + new Vector2(2, 2));
        Debug.DrawLine(origen + new Vector2(0, 1), origen + new Vector2(1.5f, 1));
    }

    void LetraA(Vector2 origen)
    {
        Debug.DrawLine(origen + new Vector2(0, 0), origen + new Vector2(1, 2));
        Debug.DrawLine(origen + new Vector2(1, 2), origen + new Vector2(2, 0));
        Debug.DrawLine(origen + new Vector2(0.5f, 1), origen + new Vector2(1.5f, 1));
    }
    void LetraT(Vector2 origen)
    {
        Debug.DrawLine(origen + new Vector2(0, 0), origen + new Vector2(0, 2));
        Debug.DrawLine(origen + new Vector2(-1, 2), origen + new Vector2(1, 2));
    }
    void LetraI(Vector2 origen)
    {
        Debug.DrawLine(origen + new Vector2(0, 0), origen + new Vector2(0, 2));
    }
    void LetraM(Vector2 origen)
    {
        Debug.DrawLine(origen + new Vector2(0, 0), origen + new Vector2(0, 2));
        Debug.DrawLine(origen + new Vector2(0, 2), origen + new Vector2(1, 1));
        Debug.DrawLine(origen + new Vector2(1, 1), origen + new Vector2(2, 2));
        Debug.DrawLine(origen + new Vector2(2, 2), origen + new Vector2(2, 0));
    }
}
