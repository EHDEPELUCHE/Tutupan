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

    public void OnClick() 
    {
        Debug.Log("somebody clicked me");
    }
    void OnMouseDown() 
    {
        Debug.Log("Pulsado");
        Vector3 aux = t.eulerAngles;
        t.Rotate(aux.x, aux.y + 90,aux.z);
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
