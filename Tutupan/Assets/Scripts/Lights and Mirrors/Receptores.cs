using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Receptores : MonoBehaviour
{
    public bool active = false;

    void Start(){
        active = false;
    }
    
    public void Encender(Material m) {
        Transform padre = this.transform.parent;
        //Debug.Log("Material " +  m.name.Substring(5,5) + "obj " + padre.gameObject.name.Substring(11));
        if(m.name.Substring(5,4) == padre.gameObject.name.Substring(11,4)){
            if(!active) SuperarNivel.receptoresActivos++;
            active = true;
        }
          
    }
    
    public void Apagar() {
        //Debug.Log("Ya no choca");
        if(active) SuperarNivel.receptoresActivos--;
        active = false;
    }
}
