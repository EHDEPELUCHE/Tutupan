using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class BotonesNiveles : MonoBehaviour
{
    public GameObject espejo;
    public GameObject espejoDoble;
    public GameObject prisma;
    public GameObject cunna;
    public UnityEvent eventitou;
    static public GameObject Auxiliar;
    
    public void ColocarEspejo(){
        Auxiliar = espejo;
        Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarEspejoDoble(){
        Auxiliar = espejoDoble;
        Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarPrisma(){
        Auxiliar = prisma;
        Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }
    public void ColocarCunna(){
        Auxiliar = cunna;
        Debug.Log("Se asigna el espejo a auxiliar: " + Auxiliar.name);
        eventitou.Invoke();
    }

}
