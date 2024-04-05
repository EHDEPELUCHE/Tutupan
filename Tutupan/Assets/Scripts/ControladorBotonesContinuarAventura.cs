using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ControladorBotonesContinuarAventura : MonoBehaviour
{
    public GameObject niveles1a12;
    public GameObject niveles12a25;
    // Start is called before the first frame update
    void Start()
    {
        niveles1a12.SetActive(true);
        niveles12a25.SetActive(false);
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
  
}
