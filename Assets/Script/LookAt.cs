using UnityEngine;

public class LookAt : MonoBehaviour
{
    //Public Atributtes
    public Transform target;
    
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        //Mostramos la posicion del objecto objetivo.
        print("target x: " + target.position.x + " / Target y: " + target.position.y + " / Target z: " + target.position.z);
        
        //Hacemos que el transform del objecto actual mire hacia un objectivo.
        transform.LookAt(target);  //será su eje Z el que mire hacia el objetivo.
    }

    // Update is called once per frame
    void Update()
    {
        transform.LookAt(target.position);
    }
}
