using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReflejoEspejo : MonoBehaviour
{
    Vector3 position;
    Vector3 direction1;
    Vector3 direction2;
    public Transform Laser1;
    public Transform Laser2;
    private LineRenderer lr1;
    private LineRenderer lr2;
    public static bool aux = false;
    private void Start()
    {
        // Obtén la referencia al Line Renderer
        lr1 = Laser1.GetComponent<LineRenderer>();
        lr2 = Laser2.GetComponent<LineRenderer>();
        lr1.positionCount = 2;
        lr2.positionCount = 2;
        
    }
    void Update()
    {
        if (aux){
            lr1.enabled = true;
            lr2.enabled = true;
            lr1.SetPosition(0, Laser1.position);
            lr2.SetPosition(0,Laser2.position);
            direction1 = Laser1.forward;
            direction2 = Laser2.forward;
            RaycastHit hit;
            if(Physics.Raycast(Laser1.position, direction1, out hit, Mathf.Infinity)){
                if(hit.collider.CompareTag("Reflector")){
                    //tempReflector = hit.collider.gameObject;
                   // Vector3 temp = Vector3.Reflect(direction, hit.normal);
                   Debug.Log("Update detecta la etiqueta");
                }
                lr1.SetPosition(1, hit.point);
                //lr2.SetPosition(1, direction2 * 200);
            }else{
                lr1.SetPosition(1, direction1 * 200);
                //lr2.SetPosition(1, direction2 * 200);
            }
            if(Physics.Raycast(Laser2.position, direction2, out hit, Mathf.Infinity)){
                if(hit.collider.CompareTag("Reflector")){
                    //tempReflector = hit.collider.gameObject;
                   // Vector3 temp = Vector3.Reflect(direction, hit.normal);
                   Debug.Log("Update detecta la etiqueta");
                }
                //lr1.SetPosition(1, direction1 * 200);
                lr2.SetPosition(1, hit.point);
            }else{
               // lr1.SetPosition(1, direction1 * 200);
                lr2.SetPosition(1, direction2 * 200);
            }
        }else{
            lr1.enabled = false;
            lr2.enabled = false;
            //lr1.SetPosition(1, Laser1.position);
            //lr2.SetPosition(1, Laser2.position);
        }
        
    }

    void OnTriggerStay(Collider other)
    {
        // Realizar acciones específicas cuando colisiona con otros objetos
        if(other.CompareTag("Reflector"))
        {
            Debug.Log("El laser golpea donde tiene que golpear");
        }
        else
        {
            Debug.Log("El laser ya no está tocando el trigger");
        }
    }

    public void Choca(Material m){
        aux = true;
        lr1.material = m;
        lr2.material = m;
    }
    public void noChoca(){
        aux = false;
    }
}
