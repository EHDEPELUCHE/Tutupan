using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fruits : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject juice;
    public Animator rigAnimator; // Reference to the Animator component
    private float rotationForce = 180;
    public int points;
    private DesafioModeManager desafioModeManager;

    private Rigidbody rb;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        desafioModeManager = FindObjectOfType<DesafioModeManager>();
    }

    // Update is called once per frame
    void Update()
    {
        transform.Rotate(Vector2.right * Time.deltaTime * rotationForce);
    }

    private void InstantiateJuice()
    {
        GameObject instantiatedJuice = Instantiate(juice, new Vector3(transform.position.x, transform.position.y, 0),
            juice.transform.rotation);
        Destroy(instantiatedJuice, 5);
    }

    private void OnTriggerEnter(Collider collider)
    {
        if (collider.tag == "Ray")
        {
            DesafioModeManager.golpeaSlime = true;
            desafioModeManager.UpdateTheScore(points);
            Destroy(gameObject);
            InstantiateJuice();
            // PlayRigDamageAnimation(); // Call function to play animation
        }

        if (collider.tag == "BottomTag")
        {
            desafioModeManager.UpdateLives();
            Destroy(gameObject);
        }
    }

    private void PlayRigDamageAnimation()
    {
        // Check if the Animator component is attached
        if (rigAnimator != null)
        {
            // Trigger the "Rig_Damage" animation
            rigAnimator.SetTrigger("Rig_Damage");
        }
        else
        {
            Debug.LogWarning("Animator component not attached to the object.");
        }
    }
}
