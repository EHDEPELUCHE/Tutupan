using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int NumCasilla;
    static public GameObject obj;
    public bool bMovible = true;
    public bool bColocar = false;
    private GameObject sobremi;
    public static bool modoBorrado = false;
    
    //Se entra cuando se ha pulsado una casilla y 
    //tocado algun espejo.
    void Update() {
        if(bColocar && obj != null && bMovible) {
            int j = NumCasilla % 12 ;
            int i = NumCasilla / 12 ;
            switch(obj.name){
                case "Espejo":
                    sobremi = Instantiate(obj, new Vector3(i , 0.65f, j ), Quaternion.identity);
                break;
                case "EspejoDoble":
                    sobremi = Instantiate(obj, new Vector3(i , 0.5f, j), Quaternion.identity);
                break;
                case "Cunna":
                    sobremi = Instantiate(obj, new Vector3(i, 0.65f, j), Quaternion.identity);
                break;
                case "Prisma":
                    sobremi = Instantiate(obj, new Vector3(i, 0.55f, j), Quaternion.identity);
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
        if (obj != null && !modoBorrado) {
            bColocar = true;
            print(NumCasilla.ToString() + 
            " Valor de bColocar: " + bColocar +
            " Valor de bMovible: " + bMovible +
            " Valor de modoBorrado: " + modoBorrado + 
            " Valor de obj: " + obj.name);
        }
        if (modoBorrado && sobremi == null) {
            modoBorrado = false;
            bMovible = true;
            bColocar = true;
            //obj = null;
            Debug.Log("Borrado");
        }
    }

    //Se activa al pulsar un espejo de la interfaz
    public void eventitou() {
        //obj = GetComponent<BotonesNiveles>().Auxiliar;
        obj = BotonesNiveles.Auxiliar;
        Debug.Log("Se asigna el auxiliar a obj: " + obj.name);
      
    }
}
