using UnityEngine;

public class Rotaciónplanetas : MonoBehaviour
{
    //Public Atributtes
    public Transform puntoDeGiro;
    public float speedRotation;
    public Vector3 ejeRotacion;
    public float rotationAngle;
    public float speedRotationAround;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        RotacionPropia();
        RotaAlrededor();
    }

    //Métodos Privados
    void  RotacionPropia()
    {
        transform.Rotate(ejeRotacion * speedRotation * Time.deltaTime);
    }

    void RotaAlrededor()
    {
        transform.RotateAround(puntoDeGiro.position, Vector3.forward, rotationAngle * Time.deltaTime * speedRotationAround);
        
    }
}
