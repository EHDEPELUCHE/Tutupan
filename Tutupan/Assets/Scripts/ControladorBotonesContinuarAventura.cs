using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.EventSystems;

public class ControladorBotonesContinuarAventura : MonoBehaviour
{
    public GameObject niveles1a12;
    public GameObject niveles12a25;
    
    public GameObject[] BotonesNivel;
    public GameObject[] Banderitas;
    int maxNivelsuperado;
    float x=467.5f;
    float y= 256f;
    Color colorsuperado = new Color(0.4247418f,0.7735849f,0.4560634f,0.4980392f);
    Color colorNosuperado = new Color(0.4247418f,0.7735849f,0.4560634f,0.0f);
    // Start is called before the first frame update
    void Start()
    {
        niveles1a12.SetActive(true);
        Banderitas = GameObject.FindGameObjectsWithTag("Banderita") ;
        BotonesNivel = GameObject.FindGameObjectsWithTag("BotonesNivel") ;
        niveles12a25.SetActive(false);
        maxNivelsuperado = PlayerPrefs.GetInt("maxNivelSuperado");
        foreach (GameObject BotonNivel in BotonesNivel)
        {
            if(int.Parse(BotonNivel.name.Substring(16)) <= maxNivelsuperado)
            {
               BotonNivel.GetComponent<Image>().color = colorsuperado;
               
               //Debug.Log(BotonNivel.name + "es menor");
            }else{
                BotonNivel.GetComponent<Image>().color = colorNosuperado;
                
            }
           
        }
        foreach (GameObject Bandera in Banderitas)
        {
            if(int.Parse(Bandera.name.Substring(9)) == 1+maxNivelsuperado)
            {
               Bandera.SetActive(true);
               
            }else{
               Bandera.SetActive(false);
            }
           
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
        GameObject aux = EventSystem.current.currentSelectedGameObject;
        Debug.Log(aux.name);
        if(int.Parse(aux.name.Substring(16)) <= 1+maxNivelsuperado){
            SceneManager.LoadScene("Nivel"+aux.name.Substring(16));
        }else{
            Debug.Log("Nivel no desbloqueado");
        }
    }
  
}
