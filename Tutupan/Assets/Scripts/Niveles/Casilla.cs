using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int NumCasilla;
    static public GameObject obj;
    public bool bMovible = true;
    public bool bColocar = false;
    
    //Se entra cuando se ha pulsado una casilla y 
    //tocado algun espejo.
    void Update() {
        if(bColocar && obj != null && bMovible) {
            Quaternion aux = Quaternion.Euler(-90, 90, 0);  
            int j = NumCasilla % 12 + 1;
            int i = NumCasilla / 12 + 1;
            switch(obj.name){
                case "Espejo":
                    Instantiate(obj, new Vector3(i - 1.9f , 0, j - 1.5f), aux);
                break;
                case "EspejoDoble":
                    Instantiate(obj, new Vector3(i - 3.45f, 0, j - 1.5f ), aux);
                break;
                case "Cunna":
                    Instantiate(obj, new Vector3(i + 0.37f, 0, j - 1.85f), aux);
                break;
                case "Prisma":
                    Instantiate(obj, new Vector3(i - 4.85f, 0, j - 1.5f), aux);
                break;
                default:
                    Debug.Log("No he puesto nada " + obj.name);
                break;
            }
            bMovible = false;
            bColocar = false;
            obj = null;
        }
    }

    //Se activa al pulsar una casilla del tablero
    void OnMouseDown() {
        if (obj != null) {
            bColocar = true;
            print(NumCasilla.ToString() + " " + bColocar);
        }
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
