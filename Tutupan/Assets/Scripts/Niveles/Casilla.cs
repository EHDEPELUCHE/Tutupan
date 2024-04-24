using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int NumCasilla;
    public bool bMovible = true;
    
    void OnMouseDown() {
        print(NumCasilla.ToString());
    }

    public void eventitou() {
        Quaternion aux = Quaternion.Euler(-90, 90, 0);
        GameObject obj = GetComponent<BotonesNiveles>().Auxiliar;
        //REVISAR EL CALCULO DE I E J
        int i = NumCasilla % 12 + 1;
        int j = NumCasilla / 12 + 1;
        Instantiate(obj, new Vector3(i-0.9f, 0, j+0.85f), aux); 
    }
}
