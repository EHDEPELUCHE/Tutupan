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
                    if(CrearCasillas.maxEspejo > 0){
                        sobremi = Instantiate(obj, new Vector3(i , 0.65f, j ), Quaternion.identity);
                        CrearCasillas.maxEspejo--;
                        PlayerPrefs.SetInt("EspejosComprados", CrearCasillas.maxEspejo);
                         CrearCasillas.textoespejo.text =  CrearCasillas.maxEspejo.ToString();
                        
                    }   
                break;
                case "EspejoDoble":
                    if(CrearCasillas.maxEspejodoble > 0){
                        sobremi = Instantiate(obj, new Vector3(i , 0.5f, j), Quaternion.identity);
                        CrearCasillas.maxEspejodoble--;
                        PlayerPrefs.SetInt("EspejosDoblesComprados", CrearCasillas.maxEspejodoble);
                         CrearCasillas.textoespejodoble.text =  CrearCasillas.maxEspejodoble.ToString();
                    }
                    
                break;
                case "Cunna":
                    if(CrearCasillas.maxCunna > 0){
                        sobremi = Instantiate(obj, new Vector3(i, 0.65f, j), Quaternion.identity);
                        CrearCasillas.maxCunna--;
                        PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.maxCunna);
                        CrearCasillas.textocunna.text =  CrearCasillas.maxCunna.ToString();
                    }
                break;
                case "Prisma":
                    if(CrearCasillas.maxprisma > 0){
                        sobremi = Instantiate(obj, new Vector3(i, 0.55f, j), Quaternion.identity);
                        CrearCasillas.maxprisma--;
                        PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.maxprisma );
                        CrearCasillas.textoprisma.text = CrearCasillas.maxprisma.ToString();
                    }
                    
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
