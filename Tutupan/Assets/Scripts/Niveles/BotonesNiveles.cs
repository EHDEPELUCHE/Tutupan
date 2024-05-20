using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class BotonesNiveles : MonoBehaviour
{
    public GameObject espejo;
    public GameObject espejoDoble;
    public GameObject prisma;
    public GameObject cunna;
    public UnityEvent eventitou;
    static public GameObject Auxiliar;
    
    public void ColocarEspejo(){
        Rotacion.modoBorrado = false;
        Auxiliar = espejo;
        //Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarEspejoDoble(){
        Rotacion.modoBorrado = false;
        Auxiliar = espejoDoble;
       // Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarPrisma(){
        Rotacion.modoBorrado = false;
        Auxiliar = prisma;
        //Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarCunna(){
        Rotacion.modoBorrado = false;
        Auxiliar = cunna;
        //Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }

    public void Eliminar(){
        Rotacion.modoBorrado = true;
    }
    public void Atras(){
        if(!VozNivelGenerico.termina){
            PlayerPrefs.SetInt("EspejosComprados", CrearCasillas.antesmaxEspejo);
            PlayerPrefs.SetInt("EspejosDoblesComprados", CrearCasillas.antesmaxEspejodoble);
            PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.antesmaxCunna);
            PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.antesmaxprisma );
        }
        
        SceneManager.LoadScene("ContinuarAventura");
    }
}
