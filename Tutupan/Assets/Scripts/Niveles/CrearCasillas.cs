using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CrearCasillas : MonoBehaviour
{
    public GameObject CasillaPrefab;
    public GameObject creadorLuzBlanco;
    public GameObject receptorLuzBlanco;
    public GameObject Muro;
    public int Ancho;
    public int Alto;

    void Start() {
        Quaternion aux = Quaternion.Euler(-90, 90, 0);;
        int cont = 0;
        for (int i = 0; i < Ancho; i++)
            for (int j = 0; j < Alto; j++) {
                GameObject casillaAux = Instantiate(CasillaPrefab, new Vector3(i, 0, j), Quaternion.identity);
                casillaAux.GetComponent<Casilla>().NumCasilla = cont;
                if (cont == 14){
                    Instantiate(creadorLuzBlanco, new Vector3(i-0.9f, 0, j+0.85f), aux);
                }
                if (cont == 18){
                    Instantiate(receptorLuzBlanco, new Vector3(i+0.17f, 0, j+0.9f), aux);
                }
                if (cont == 16){
                    Instantiate(Muro, new Vector3(i-2.4f, 0, j+1f), aux);
                }
                cont++; 
            }
    }
}
