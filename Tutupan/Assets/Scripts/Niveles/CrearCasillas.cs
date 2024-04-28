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
                            case 18: 
                                Instantiate(receptorLuzBlanco, new Vector3(i+0.17f, 0, j+0.9f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                        }
                    break;
                    case "2":
                    break;
                    case "3":
                        switch(cont) {
                            case 15:
                                Instantiate(creadorLuzAzul, new Vector3(i-0.9f, 0, j+0.85f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 51:
                                Instantiate(creadorLuzRoja, new Vector3(i-0.9f, 0, j+0.85f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 114: 
                                Instantiate(receptorLuzRoja, new Vector3(i+0.17f, 0, j+0.9f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 117: 
                                Instantiate(receptorLuzAzul, new Vector3(i+0.17f, 0, j+0.9f), aux); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                    break;
                    case "4":
                    break;
                    case "5":
                    break;
                    case "6":
                    break;
                    case "7":
                    break;
                    case "8":
                    break;
                    case "9":
                    break;
                    case "10":
                    break;
                    case "11":
                    break;
                    case "12":
                    break;
                    case "13":
                    break;
                    case "14":
                    break;
                    case "15":
                    break;
                    case "16":
                    break;
                    case "17":
                    break;
                    case "18":
                    break;
                    case "19":
                    break;
                    case "20":
                    break;
                    case "21":
                    break;
                    case "22":
                    break;
                    case "23":
                    break;
                    case "24":
                    break;
                    case "25":
                    break;
                    default: break;
                }
                cont++; 
            }
    }
}
