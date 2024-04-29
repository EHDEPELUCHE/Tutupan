using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int NumCasilla;
    public GameObject obj;
    public bool bMovible = true;
    public bool bColocar = false;
    
    //Se entra cuando se ha pulsado una casilla y 
    //tocado algun espejo.
    void Update() {
        if(bColocar && obj != null){
            Quaternion aux = Quaternion.Euler(-90, 90, 0);  
            int i = NumCasilla % 12 + 1;
            int j = NumCasilla / 12 + 1;
            Instantiate(obj, new Vector3(i-0.9f, 0, j+0.85f), aux);
            Debug.Log("Se ha creado algo en alguna parte.");
            bColocar = false;
            obj = null;
        }
    }

    //Se activa al pulsar una casilla del tablero
    void OnMouseDown() {
        bColocar = true;
        print(NumCasilla.ToString() + " " + bColocar);
    }

    //Se activa al pulsar un espejo de la interfaz
    public void eventitou() {
        //obj = GetComponent<BotonesNiveles>().Auxiliar;
        obj = BotonesNiveles.Auxiliar;
        Debug.Log("Se asigna el auxiliar a obj: " + obj.name);
        /*
        if(bColocar){
            Quaternion aux = Quaternion.Euler(-90, 90, 0);
            GameObject obj = GetComponent<BotonesNiveles>().Auxiliar;
            //REVISAR EL CALCULO DE I E J
            int i = NumCasilla % 12 + 1;
            int j = NumCasilla / 12 + 1;
            Instantiate(obj, new Vector3(i-0.9f, 0, j+0.85f), aux);
            Debug.Log("Se ha creado algo en alguna parte.");
        }
        Debug.Log("No está entrando en el if.");
        bColocar = false;
        */
    }
}
