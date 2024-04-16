using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCasillas : MonoBehaviour
{
    public GameObject CasillaPrefab;
    public int Ancho;
    public int Alto;

    void Start() {
        int cont = 0;
        for (int i = 0; i < Ancho; i++)
            for (int j = 0; j < Alto; j++) {
                GameObject casillaAux = Instantiate(CasillaPrefab, new Vector3(i, 0, j), Quaternion.identity);
                casillaAux.GetComponent<Casilla>().NumCasilla = cont;
                cont++; 
            }
    }
}
