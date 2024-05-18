using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SuperarNivel : MonoBehaviour
{
    public GameObject BotonesJuego;
    public GameObject Fin;
    public bool terminado = false;
    private GameObject[] receptores;
    private int receptoresTotales, maxNivelSuperado, nivelAct;
    public static int receptoresActivos = 0;

    // Start is called before the first frame update
    void Start() {
        BotonesJuego.SetActive(true);
        Fin.SetActive(false);
        terminado = false;
        receptoresActivos = 0;
        receptores = GameObject.FindGameObjectsWithTag("Receptor");  
        receptoresTotales = receptores.Length;
        maxNivelSuperado = PlayerPrefs.GetInt("maxNivelSuperado");
        string sNivelActual = SceneManager.GetActiveScene().name.Substring(5); 
        nivelAct = int.Parse(sNivelActual);
    }

    // Update is called once per frame
    void Update() {
        //Debug.Log ("Receptores activos: " + receptoresActivos);
        if (receptores != null && receptoresTotales == receptoresActivos && !terminado) {
            //Debug.Log("Receptores totales: " + receptoresTotales);
            BotonesJuego.SetActive(false);
            Fin.SetActive(true);
            terminado = true;
            VozNivelGenerico.termina = true;
            if (maxNivelSuperado < nivelAct)
                PlayerPrefs.SetInt("maxNivelSuperado", nivelAct);
        }else{
           // Debug.Log("Esto los desactiva");
            VozNivelGenerico.termina = false;
            VozNivelGenerico.unavez = false;
        }
        if(CrearCasillas.maxprisma > 1){
            CrearCasillas.maxprisma = 1;
        }
    }

    public void Continuar(){
        SceneManager.LoadScene("Nivel"+ (nivelAct+1));
    } 
/*
    public static void HacerRecuento(){
        int aux = 0;
        if (receptores != null)
            foreach (GameObject receptor in receptores)
                if(receptor.active) aux++;
        if (aux != receptoresActivos) receptoresActivos = aux;
    }*/
}
