using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptores : MonoBehaviour
{
    public bool active = false;

    void Start(){
        active = false;
    }
    
    public void Encender() {
       // Debug.Log("ENCENDIDOOO");
        if(!active) SuperarNivel.receptoresActivos++;
        active = true;
        
    }
    
    public void Apagar() {
        //Debug.Log("Ya no choca");
        if(active) SuperarNivel.receptoresActivos--;
        active = false;
    }
}
