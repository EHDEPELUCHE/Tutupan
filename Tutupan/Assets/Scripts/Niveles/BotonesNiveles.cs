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
    public GameObject Auxiliar;
    
    public void ColocarEspejo(){
        Auxiliar = espejo;
        eventitou.Invoke();
    }
    public void ColocarEspejoDoble(){
        Auxiliar = espejoDoble;
        eventitou.Invoke();
    }
    public void ColocarPrisma(){
        Auxiliar = prisma;
        eventitou.Invoke();
    }
    public void ColocarCunna(){
        Auxiliar = cunna;
        eventitou.Invoke();
    }

}
