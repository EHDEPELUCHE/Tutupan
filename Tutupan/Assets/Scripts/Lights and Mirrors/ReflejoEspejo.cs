using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflejoEspejo : MonoBehaviour
{
    Vector3 position;
    Vector3 direction;
    public Transform Laser1;
    public Transform Laser2;

    void Update()
    {}

    void OnTriggerStay(Collider other)
    {
        // Realizar acciones específicas cuando colisiona con otros objetos
        if(other.CompareTag("Reflector"))
        {
            Debug.Log("El laser golpea donde tiene que golpear");
        }
        else
        {
            Debug.Log("El laser ya no está tocando el trigger");
        }
    }
}
