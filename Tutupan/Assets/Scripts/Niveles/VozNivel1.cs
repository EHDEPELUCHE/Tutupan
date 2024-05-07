using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VozNivel1 : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
    private float tiempoEspera = 60f;
    public AudioClip bien;
    // Start is called before the first frame update
    void Start()
    {
        tiempoEspera += Time.time;
        audioSource = GetComponent<AudioSource>();
        animator.Play("0000000016", 1, 0);
        audioSource.Play(0);
    }

    // Update is called once per frame
    void Update()
    {
        if(Time.time > tiempoEspera && !audioSource.isPlaying){
            tiempoEspera += Time.time;
            animator.Play("0000000016", 1, 0);
            audioSource.Play(0);
        }
    }
}
