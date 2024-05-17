using UnityEditor;
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
                               
                            break;
                            case 16: case 28: 
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
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
                              
                               
                            break;
                            case 72:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 2;
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
                               
                            break;
                            case 66:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
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
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
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
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false; 
                            break;
                            case 27:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 1;
                                maxEspejodoble += 1;
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
                        switch (cont){
                            case 20:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxprisma += 1;
                            break;
                            case 62:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 71:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 116:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "13":
                        switch (cont){
                            case 20:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxprisma += 1;
                            break;
                            case 62:
                                Instantiate(receptorLuzBlanco, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 71:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j),Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 116:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.IZQUIERDA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "14":
                        switch (cont)
                        {
                            case 8:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxprisma += 1;
                                maxEspejo += 1;
                            break;
                            case 54:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 58:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 141:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 115: case 117: case 126: case 127: case 129: case 139:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "15":
                        switch (cont)
                        {
                            case 6: case 104: case 118:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 59:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 1;
                                maxEspejo += 1;
                            break;
                            case 116:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "16":
                        switch (cont)
                        {
                            case 14:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 1;
                                maxprisma += 1;
                            break;
                            case 20:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 71:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 116:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "17":
                        switch (cont)
                        {
                            case 6:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble += 2;
                            break;
                            case 26:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 34:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 82:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "18":
                        switch (cont)
                        {
                            case 6: case 7: case 17: case 20: case 26: case 29: case 32: case 67:
                            case 77: case 80: case 85: case 100: case 104: case 113: case 115: 
                            case 121: case 137: case 139:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 18:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 38:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 129:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 138:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.IZQUIERDA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "19":
                        switch (cont)
                        {
                            case 7:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble += 2;
                                maxEspejo += 1;
                            break;
                            case 22:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 35:
                                Instantiate(receptorLuzBlanco, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 74:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 82:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 113:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 115:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "20":
                        switch (cont)
                        {
                            case 12: case 20: case 36: case 60: case 84: case 103:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 24: case 48: case 91: case 130:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 72:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 1;
                                maxCunna += 3;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "21":
                        switch (cont)
                        {
                            case 9: case 57: case 98: case 118: case 134:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 58: case 86: case 99: case 106: case 109: case 119: case 130:
                            case 133: case 135:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 70:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 5;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "22":
                        switch (cont)
                        {
                            case 7:
                                Instantiate(creadorLuzAzul, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 2;
                                maxEspejo += 5;
                            break;
                            case 8: case 23: case 31: case 38: case 69: case 78: case 99: case 100:
                            case 119: case 126: case 128: case 129: case 130:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 90: case 116: case 117:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "23":
                        switch (cont)
                        {
                            case 12:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxCunna += 3;
                                maxCunna += 1;
                                maxprisma += 1;
                            break;
                            case 20:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 62:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 65:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 71:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 116:
                                Instantiate(receptorLuzAzul, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "24":
                        switch (cont)
                        {
                            case 6: case 8: case 98: case 117:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 7: case 13: case 15: case 17: case 18: case 20: case 32: case 68: case 101:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 19:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.DERECHA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejo += 2;
                                maxCunna += 3;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    case "25":
                        switch (cont)
                        {
                            case 5: case 16: case 54: case 67: case 124: case 135:
                                Instantiate(Muro, new Vector3(i -1, 3, j - 0.48f), Quaternion.identity); 
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 15:
                                Instantiate(receptorLuzBlanco, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                                maxEspejodoble += 2;
                                maxEspejo += 1;
                            break;
                            case 17:
                                Instantiate(receptorLuzAmarilla, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 62:
                                Instantiate(creadorLuzAmarilla, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 66:
                                Instantiate(creadorLuzBlanco, new Vector3(i, 0.4f, j), Rotaciones.ABAJO);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 86:
                                Instantiate(creadorLuzRoja, new Vector3(i, 0.4f, j), Rotaciones.ARRIBA);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                            case 123:
                                Instantiate(receptorLuzRoja, new Vector3(i, 0.1f, j), Quaternion.identity);
                                casillaAux.GetComponent<Casilla>().bMovible = false;
                            break;
                        }
                        textoespejo.text = maxEspejo.ToString();
                        textocunna.text = maxCunna.ToString();
                        textoespejodoble.text = maxEspejodoble.ToString();
                        textoprisma.text = maxprisma.ToString();
                    break;
                    default: break;
                }
                cont++; 
            }
    }
}
