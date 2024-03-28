using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TiendaTutupan : MonoBehaviour
{
    public Animator animator;
    private AudioSource audioSource;
   // private float tiempoEspera = 5f;
    // Start is called before the first frame update
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.Play(0);
        animator.Play("0000000013", 1, 0); //Welcome to the shop audio
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
