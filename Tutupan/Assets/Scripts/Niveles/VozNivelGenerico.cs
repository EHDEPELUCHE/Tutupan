using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class VozNivelGenerico : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    public static bool coloca = false;
    public static bool termina = false;
   
    private float tiempoEspera = 60f;
    public AudioClip keepgoing, subarashi, goodmove, awesome, welldone;
    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera += Time.time;
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
         if(Time.time > tiempoEspera && !audioSource.isPlaying){
            tiempoEspera += Time.time;
            animator.Play("0000000100", 1, 0);
            audioSource.Play(0);
        }
        if(coloca && !audioSource.isPlaying){
            coloca = false;
            float aleatorio = Random.Range(0.0f, 1.0f);
                Debug.Log("Sale el num " + aleatorio);
                if(aleatorio <= 0.33f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(keepgoing);
                    animator.Play("0000000017", 1, 0);
                }else if(aleatorio > 0.33f && aleatorio < 0.66f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(subarashi);
                    animator.Play("0000000018", 1, 0);
                }else{
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(goodmove);
                    animator.Play("0000000019", 1, 0);
                }
                
        }
        if(termina && !audioSource.isPlaying){
            //termina = false;
            float aleatorio = Random.Range(0.0f, 1.0f);
            if(aleatorio <= 0.5f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(awesome);
                    animator.Play("0000000020", 1, 0);
                }else {
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(welldone);
                    animator.Play("0000000021", 1, 0);
                }
        }
    }
/*
    public void eventocolocacion() {
        Debug.Log("Evento recibido");
        float aleatorio = Random.Range(0.0f, 1.0f);
        Debug.Log("Sale el num " + aleatorio);
         if(aleatorio <= 0.33f){
            tiempoEspera += Time.time;
            Debug.Log("Antes auido");
            audioSource.PlayOneShot(keepgoing);
            Debug.Log("Antes anim");
            animator.Play("0000000017", 1, 0);
            Debug.Log("Despues");
         }else if(aleatorio > 0.33f && aleatorio < 0.66f){
            tiempoEspera += Time.time;
            Debug.Log("Antes auido");
            audioSource.PlayOneShot(subarashi);
            Debug.Log("Antes anim");
            animator.Play("0000000018", 1, 0);
            Debug.Log("Despues");
         }else{
            tiempoEspera += Time.time;
            Debug.Log("Antes auido");
            audioSource.PlayOneShot(goodmove);
            Debug.Log("Antes anim");
            animator.Play("0000000019", 1, 0);
            Debug.Log("Despues");
         }
      
    }*/
}
