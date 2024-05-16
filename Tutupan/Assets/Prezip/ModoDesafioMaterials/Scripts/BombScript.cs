using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Random = UnityEngine.Random;

public class BombScript : MonoBehaviour
{
    private float rotationForce = 200;
    private AudioSource exp;
    public ParticleSystem explosionParticle;
    // Start is called before the first frame update
    void Start()
    {
        transform.rotation = Random.rotation;
        exp = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Ray")
        {
             exp.Play(0);
            Destroy(gameObject);
            Instantiate(explosionParticle, transform.position, explosionParticle.transform.rotation);
            FindObjectOfType<DesafioModeManager>().GameOver();
        }
    }
}
