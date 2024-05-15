using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PrismaSuperior : MonoBehaviour
{
    public static bool LadoAzul = false;
    public static bool LadoRojo = false;
    public static bool LadoAmarillo = false;
    Vector3  directionBlanco;
    public Transform LaserBlanco;
    private LineRenderer lrBlanco;
    GameObject  tempReflectorBlanco,  tempReceptorBlanco, tempPrismaBlanco;

    void Start()
    {
        lrBlanco = LaserBlanco.GetComponent<LineRenderer>();
        lrBlanco.positionCount = 2;
    }

    void Update()
    {
        if(LadoAzul && LadoRojo && LadoAmarillo){
           
            lrBlanco.enabled = true;
            lrBlanco.SetPosition(0, LaserBlanco.position);
            directionBlanco = LaserBlanco.forward;
            RaycastHit hit;
            if (Physics.Raycast(LaserBlanco.position, directionBlanco, out hit, Mathf.Infinity)){
                if(hit.collider.CompareTag("Emisor")){
                    lrBlanco.enabled = false;
                    if (tempReflectorBlanco != null) {
                        tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorBlanco = null;
                    }
                    if (tempReceptorBlanco != null) {
                        tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                        tempReceptorBlanco = null;
                    }
                }else if (hit.collider.CompareTag("Reflector")) {
                    Debug.Log("choca con un reflector");
                    if (tempReflectorBlanco) tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorBlanco) tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                    tempReflectorBlanco = hit.collider.gameObject;
                    tempReflectorBlanco.GetComponent<ReflejoEspejo>().Choca(lrBlanco.material, this.gameObject);
                    lrBlanco.SetPosition(1, hit.point);
                } else if (hit.collider.CompareTag("Receptor")) {
                     Debug.Log("choca con un receptor");
                    if (tempReflectorBlanco) tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorBlanco) tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                    tempReceptorBlanco = hit.collider.gameObject;
                    tempReceptorBlanco.GetComponent<Receptores>().Encender(lrBlanco.material);
                    lrBlanco.SetPosition(1, hit.point);
                } else if (tempReflectorBlanco != null || tempReceptorBlanco != null) {
                   // Debug.Log("No choca con un Reflector ni un Receptor Blanco, pero con algo choca.");
                    if (tempReflectorBlanco != null) {
                        tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorBlanco = null;
                    }
                    if (tempReceptorBlanco != null) {
                        tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                        tempReceptorBlanco = null;
                    }
                    lrBlanco.SetPosition(1, hit.point);
                } else {
                    //Debug.Log("Va al infinito");
                    lrBlanco.SetPosition(1, directionBlanco * 200);
                }
            }else {
                lrBlanco.SetPosition(1, directionBlanco * 200);
                Debug.Log("Fin posicion");
            }   
        }else {
            /*if (LadoAmarillo) Debug.Log("Solo lado amarillo");
            if (LadoAzul) Debug.Log("Solo lado Azul");
            if (LadoRojo) Debug.Log("Solo lado Rojo");*/
            lrBlanco.enabled = false;
            if (tempReflectorBlanco != null) {
                tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflectorBlanco = null;
            }
            if (tempReceptorBlanco != null) {
                tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                tempReceptorBlanco = null;
            }
        }
    }

    void OnDestroy(){
        lrBlanco.enabled = false;
            if (tempReflectorBlanco != null) {
                tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflectorBlanco = null;
            }
            if (tempReceptorBlanco != null) {
                tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                tempReceptorBlanco = null;
            }
    }
}
