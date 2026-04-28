using UnityEngine;

public class Scale : MonoBehaviour
{
    //Public Atributtes
    public float scaleX;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Así editamos la escala local de un objeto
        transform.localScale = new Vector3(1, 0.1f, 0.1f); //siempre que pongamos decimales, ponemos f de "float"
        transform.localScale = new Vector3(scaleX, transform.localScale.y, transform.localScale.z); //transform.localScale se usa para que se mantenga en su escala actual.

        //Queremos mover la posición del objeto
        transform.position = new Vector3(5, transform.position.y, transform.position.z); // (x, y, z) transform.position le dice que siga con su posicion actual en esas coordenadas.
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
