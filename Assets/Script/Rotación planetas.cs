using UnityEngine;

public class Rotaciónplanetas : MonoBehaviour
{
    //Public Atributtes
    public Transform puntoDeGiro;
    public float speedRotation;
    public Vector3 ejeRotacion;
    public float rotationAngle;
    public float speedRotationAround;

    public bool activarEjeRotación;
    public float longitudOriginalEje;

    // Update is called once per frame
    void Update()
    {
        RotacionPropia();
        RotaAlrededor();
        if (activarEjeRotación == true)
            EjePlaneta();
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

    void EjePlaneta()
    {
        float longitudEje = transform.localScale.y * longitudOriginalEje;

        Vector3 direccion = transform.up;

        Vector3 inicio = transform.position - direccion * longitudEje;
        Vector3 final = transform.position + direccion * longitudEje;

        Debug.DrawLine(inicio, final, Color.green);
    }
}
