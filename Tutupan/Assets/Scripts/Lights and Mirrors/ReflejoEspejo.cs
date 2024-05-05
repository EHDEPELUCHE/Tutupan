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
    public  bool aux = false;
 
    private GameObject origen;
    GameObject tempReflector1;
    GameObject tempReflector2;
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
                    if(tempReflector1){
                    tempReflector1.GetComponent<ReflejoEspejo>().noChoca();
                }
                    tempReflector1 = hit.collider.gameObject;
                    if(tempReflector1 != origen){
                        hit.collider.gameObject.GetComponent<ReflejoEspejo>().Choca(lr1.material, this.gameObject);
                    }   
                }else if(tempReflector1 != null){
                    tempReflector1.GetComponent<ReflejoEspejo>().noChoca();
                    tempReflector1 = null;
                }
                lr1.SetPosition(1, hit.point);
            }else{
                lr1.SetPosition(1, direction1 * 200);
            }
            
            if(Physics.Raycast(Laser2.position, direction2, out hit, Mathf.Infinity)){
                if(hit.collider.CompareTag("Reflector")){
                    if(tempReflector2){
                    tempReflector2.GetComponent<ReflejoEspejo>().noChoca();
                    }
                    tempReflector2 = hit.collider.gameObject;
                    if(tempReflector2 != origen)
                        hit.collider.gameObject.GetComponent<ReflejoEspejo>().Choca(lr2.material, this.gameObject);
                }else if(tempReflector2 != null){
                    tempReflector2.GetComponent<ReflejoEspejo>().noChoca();
                    tempReflector2 = null;
                }
                lr2.SetPosition(1, hit.point);
            }else{
                lr2.SetPosition(1, direction2 * 200);
            }
        }else{
            lr1.enabled = false;
            lr2.enabled = false;
            if(tempReflector1 != null){
                tempReflector1.GetComponent<ReflejoEspejo>().noChoca();
                tempReflector1 = null;
            }
            if(tempReflector2 != null){
                tempReflector2.GetComponent<ReflejoEspejo>().noChoca();
                tempReflector2 = null;
            }
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

    public void Choca(Material m, GameObject or){
        aux = true;
        lr1.material = m;
        lr2.material = m;
        origen = or;
    }

    public void noChoca(){
        aux = false;
    }
}
