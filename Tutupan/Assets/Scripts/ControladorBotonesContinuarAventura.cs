using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorBotonesContinuarAventura : MonoBehaviour
{
    public GameObject niveles1a12;
    public GameObject niveles12a25;
    public Button[] BotonesNivel;
    int maxNivelsuperado;
    // Start is called before the first frame update
    void Start()
    {
        niveles1a12.SetActive(true);
        //BotonesNivel = GameObject.FindGameObjectsWithTag("BotonesNivel") as Button;
        niveles12a25.SetActive(false);
        maxNivelsuperado = PlayerPrefs.GetInt("maxNivelSuperado");
        foreach (Button BotonNivel in BotonesNivel)
        {
            if(int.Parse(BotonNivel.name.Substring(16, BotonNivel.name.Length)) < maxNivelsuperado)
            {
                BotonNivel.colors = ColorBlock.defaultColorBlock; // a is the alpha value.
            }else{
                //sBotonNivel.GetComponent<Renderer>().color.a = 0.0f;
                Debug.Log(BotonNivel.name);
            }
           Debug.Log(BotonNivel.name);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    
    public void CambiarVistaAvance(){
        niveles1a12.SetActive(false);
        niveles12a25.SetActive(true);
 
    }

    public void CambiarVistaAtras(){
        Debug.Log("pulsado");
        niveles1a12.SetActive(true);
        niveles12a25.SetActive(false);
    }
  
    public void Atras(){
        SceneManager.LoadScene("MenuInicial");
    }

    public void PulsarNivel(){
        Debug.Log(this.name);
    }
  
}
