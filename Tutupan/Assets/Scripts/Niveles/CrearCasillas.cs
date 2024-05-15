using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Rotaciones {
    public static Quaternion ABAJO = Quaternion.Euler(0, 90, 0);
    public static Quaternion IZQUIERDA = Quaternion.Euler(0, 180, 0);
    public static Quaternion ARRIBA = Quaternion.Euler(0, 270, 0);
    public static Quaternion DERECHA = Quaternion.Euler(0, 0, 0);
}

public class CrearCasillas : MonoBehaviour
{
    public GameObject CasillaPrefab, creadorLuzBlanco, creadorLuzRoja, creadorLuzAzul, creadorLuzAmarilla,
                      receptorLuzBlanco, receptorLuzRoja, receptorLuzAzul, receptorLuzAmarilla, Muro;
    public int Ancho, Alto;
    public static Text textocunna, textoespejo, textoespejodoble, textoprisma;
    public static int maxCunna, maxEspejo, maxEspejodoble , maxprisma ;
    void Start() {
        textocunna = GameObject.FindGameObjectWithTag("textocunna").GetComponent<Text>();
        textoespejo = GameObject.FindGameObjectWithTag("textoesp").GetComponent<Text>();
        textoespejodoble = GameObject.FindGameObjectWithTag("textoespdoble").GetComponent<Text>();
        textoprisma = GameObject.FindGameObjectWithTag("textoprisma").GetComponent<Text>();
        maxCunna = PlayerPrefs.GetInt("CunnasCompradas");
        maxEspejo = PlayerPrefs.GetInt("EspejosComprados");
        maxEspejodoble = PlayerPrefs.GetInt("EspejosDoblesComprados");
        maxprisma = PlayerPrefs.GetInt("PrismasComprados");
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
                            case 51: 
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                                maxEspejo += 1;
                                VozNivelGenerico.unavez = false;
                            break;
                             case 114: 
                                Instantiate(receptorLuzRoja, new Vector3(i , 0.1f, j), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                            
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "2":
                        switch(cont) {
                            case 14: 
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.DERECHA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                                maxEspejo += 2;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 16: case 28: 
                                Instantiate(Muro, new Vector3(i - 2.37f, 0, j + 1.05f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                            case 18: 
                                Instantiate(receptorLuzBlanco, new Vector3(i, 0.1f, j), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "3":
                        switch(cont) {
                            case 15:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 2;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 51:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 114: 
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 117: 
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "4":
                        switch(cont) {
                            case 8:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble+=1;
                                maxEspejo+=1;
                                VozNivelGenerico.unavez = false;
                            break; 
                            case 64:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 71:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ABAJO); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 104:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "5":
                        switch(cont) {
                            case 7: case 139:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 17:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 1;
                                VozNivelGenerico.unavez = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "6":
                        switch(cont) {
                            case 5:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble+=1;
                                maxEspejo+=1;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 39:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 46:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ABAJO); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 65:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.IZQUIERDA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 77:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 143:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "7":
                     switch(cont) {
                            case 22: case 108: case 119:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 2;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 72:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "8":
                        switch(cont){
                            case 18:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 2;
                                maxEspejodoble += 1;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 66:
                                Instantiate(Muro, new Vector3(i - 2.37f, 0, j + 1.05f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                            case 114:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "9":
                        switch(cont){
                            case 29:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 1;
                                maxEspejo += 1;
                                maxEspejodoble += 1;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 45:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 108:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 110: case 118:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "10":
                        switch(cont){
                            case 18:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble += 1;
                                maxEspejo += 3;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 20:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 50:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 119:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 66:
                                Instantiate(Muro, new Vector3(i - 2.37f, 0, j + 1.05f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "11":
                        switch (cont){
                            case 15: case 43: case 52: case 109: case 130:
                                Instantiate(Muro, new Vector3(i - 2.37f, 0, j + 1.05f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                            case 27:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 1;
                                maxEspejodoble += 1;
                                VozNivelGenerico.unavez = false;
                            break;
                            case 30:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 36:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 99:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
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
