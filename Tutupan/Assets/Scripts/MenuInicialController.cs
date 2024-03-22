using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuInicialController : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    private float tiempoEspera = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > tiempoEspera && !audioSource.isPlaying){
            tiempoEspera += Time.time;
            animator.Play("0000000012", 1, 0);
            //if (audioSource.isPlaying) audioSource.Stop();
            audioSource.Play(0);
        }
    }
     public void Aventura()
    {
        SceneManager.LoadScene("ContinuarAventura");
    }
     public void Configuraciones()
    {
        SceneManager.LoadScene("Configuraciones");
    }
    
    public void Desafio()
    {
        SceneManager.LoadScene("Desafio");
        
    }

     public void Tienda()
    {
        SceneManager.LoadScene("Tienda");
        
    }
     public void Salir()
    {
        
        Application.Quit();
    }
}
