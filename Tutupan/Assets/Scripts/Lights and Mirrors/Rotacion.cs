using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
    private Transform t;
   // public GameObject a;
    // Start is called before the first frame update
    void Start()
    {
        t = this.GetComponent<Transform>();
    }

      void OnMouseDown() 
    {
        Debug.Log("Pulsado");
        t.RotateAround(this.transform.position, Vector3.up, 90f);
        //Quaternion aux = t.localRotation;
        //t.localRotation = Quaternion.Euler(aux.x, aux.y + 90,aux.z  + 90);
        //t.Rotate(Vector3.forward, 90f, Space.Self);
    }
    // Update is called once per frame
  /*  void Update()
    {
         if (Input.GetMouseButtonDown(0)){
            Debug.Log("Pulsado en update");
             Vector3 aux = t.eulerAngles;
            t.Rotate(aux.x + 90, aux.y,aux.z);
         }
    }*/
}
