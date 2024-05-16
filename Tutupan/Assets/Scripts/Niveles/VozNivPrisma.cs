using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VozNivPrisma : MonoBehaviour
{
    
    public Animator animator;
    private AudioSource audioSource;
    private float tiempoEspera = 60f;
     public static bool coloca = false;
    public static bool termina = false;
    public static bool unavez = false;
    public AudioClip keepgoing, subarashi, goodmove, awesome, welldone;
    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera += Time.time;
        audioSource = GetComponent<AudioSource>();
        animator.Play("0000000022", 1, 0);
        audioSource.Play(0);
    }


    // Update is called once per frame
    void Update()
    {
                if(Time.time > tiempoEspera && !audioSource.isPlaying){
            tiempoEspera += Time.time;
            animator.Play("0000000022", 1, 0);
            audioSource.Play(0);
        }
        if(coloca && !audioSource.isPlaying){
            coloca = false;
            float aleatorio = Random.Range(0.0f, 1.0f);
                Debug.Log("Sale el num " + aleatorio);
                if(aleatorio <= 0.3f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(keepgoing);
                    animator.Play("0000000017", 1, 0);
                }else if(aleatorio > 0.3f && aleatorio < 0.6f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(subarashi);
                    animator.Play("0000000018", 1, 0);
                }else if (aleatorio > 0.6f && aleatorio < 0.9f){
                    tiempoEspera += Time.time;
                    audioSource.PlayOneShot(goodmove);
                    animator.Play("0000000019", 1, 0);
                }
                
        }else{
            coloca = false;
        }
        if(termina && !audioSource.isPlaying && !unavez){
            //termina = false;
            unavez = true;
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
}
