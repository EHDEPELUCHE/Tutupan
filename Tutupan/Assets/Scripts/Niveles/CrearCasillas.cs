using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrearCasillas : MonoBehaviour
{
    public GameObject CasillaPrefab;
    public GameObject creadorLuzBlanco;
    public GameObject creadorLuzRoja;
    public GameObject creadorLuzAzul;
    public GameObject creadorLuzAmarilla;
    public GameObject receptorLuzBlanco;
    public GameObject receptorLuzRoja;
    public GameObject receptorLuzAzul;
    public GameObject receptorLuzAmarilla;
    public GameObject Muro;
    public int Ancho;
    public int Alto;

    void Start() {
        Quaternion aux = Quaternion.Euler(-90, 90, 0);;
        int cont = 0;
        string sNivelActual = SceneManager.GetActiveScene().name.Substring(5);
        Debug.Log(sNivelActual);
        for (int i = 0; i < Ancho; i++)
            for (int j = 0; j < Alto; j++) {
                GameObject casillaAux = Instantiate(CasillaPrefab, new Vector3(i, 0, j), Quaternion.identity);
                casillaAux.GetComponent<Casilla>().NumCasilla = cont;
                switch(sNivelActual) {
                    case "1": 
                        switch(cont) {
                            case 14: 
                                Instantiate(creadorLuzBlanco, new Vector3(i-0.9f, 0, j+0.85f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                                break;
                            case 16: case 28: 
                                Instantiate(Muro, new Vector3(i-2.4f, 0, j+1f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                                break;
                            case 18: Instantiate(receptorLuzBlanco, new Vector3(i+0.17f, 0, j+0.9f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                                break;
                        }
                    break;
                    case "2":
                    case "3":
                    case "4":
                    case "5":
                    case "6":
                    case "7":
                    case "8":
                    case "9":
                    case "10":
                    case "11":
                    case "12":
                    case "13":
                    case "14":
                    case "15":
                    case "16":
                    case "17":
                    case "18":
                    case "19":
                    case "20":
                    case "21":
                    case "22":
                    case "23":
                    case "24":
                    case "25":
                    default: break;
                }

                cont++; 
            }
    }
}
