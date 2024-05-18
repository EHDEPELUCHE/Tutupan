using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisma : MonoBehaviour
{
    public bool LadoBlanco = false;
    public bool LadoAzul  = false;
    public static bool Siguerecibiendo = false;
    public static bool SiguerecibiendoRef = false;
    public bool LadoRojo  = false;
    public bool LadoAmarillo  = false;
    Vector3 directionBlanco, directionAzul, directionRojo, directionAmarillo;
    public Transform LaserBlanco, LaserAzul, LaserRojo, LaserAmarillo;
    private LineRenderer lrBlanco, lrAzul, lrRojo, lrAmarillo;
    GameObject tempReflectorBlanco, tempReflectorAzul, tempReflectorRojo, tempReflectorAmarillo
    , tempReceptorBlanco, tempReceptorAzul, tempReceptorRojo, tempReceptorAmarillo,
    tempPrismaBlanco, tempPrismaAzul, tempPrismaRojo, tempPrismaAmarillo;

    void Start()
    {
        Siguerecibiendo = false;
        SiguerecibiendoRef = false;
        lrBlanco = LaserBlanco.GetComponent<LineRenderer>();
        lrAzul = LaserAzul.GetComponent<LineRenderer>();
        lrRojo = LaserRojo.GetComponent<LineRenderer>();
        lrAmarillo = LaserAmarillo.GetComponent<LineRenderer>();
        lrBlanco.positionCount = 2;
        lrAzul.positionCount = 2;
        lrRojo.positionCount = 2;
        lrAmarillo.positionCount = 2;

    }

    void FixedUpdate()
    {
        if (LadoBlanco || Siguerecibiendo || SiguerecibiendoRef){
           /* if(LadoBlanco) Debug.Log("Está encendido el lado blanco");
            if(Siguerecibiendo) Debug.Log("Es por la variable sigue recibiendo");
            if(SiguerecibiendoRef) Debug.Log("Es por la variable sigue recibiendoref");*/
            lrAzul.enabled = true;
            lrRojo.enabled = true;
            lrAmarillo.enabled = true;
            lrAzul.SetPosition(0, LaserAzul.position);
            lrRojo.SetPosition(0, LaserRojo.position);
            lrAmarillo.SetPosition(0, LaserAmarillo.position);
            directionAzul = LaserAzul.forward;
            directionRojo = LaserRojo.forward;
            directionAmarillo = LaserAmarillo.forward;
            RaycastHit hit;
             if (Physics.Raycast(LaserAzul.position, directionAzul, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorAzul && tempReflectorAzul != hit.collider.gameObject) tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAzul) tempReceptorAzul.GetComponent<Receptores>().Apagar();
                    tempReflectorAzul = hit.collider.gameObject;
                    tempReflectorAzul.GetComponent<ReflejoEspejo>().Choca(lrAzul.material);
                    lrAzul.SetPosition(1, hit.point);
                }else if (hit.collider.CompareTag("Receptor")) {
                    if (tempReflectorAzul) tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAzul && tempReceptorAzul != hit.collider.gameObject) tempReceptorAzul.GetComponent<Receptores>().Apagar();
                    tempReceptorAzul = hit.collider.gameObject;
                    tempReceptorAzul.GetComponent<Receptores>().Encender(lrAzul.material);
                     lrAzul.SetPosition(1, hit.point);
                }else if(hit.collider.CompareTag("Bloqueo")){
                    if (tempReflectorAzul != null) {
                        tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorAzul = null;
                    }
                    if (tempReceptorAzul != null) {
                        tempReceptorAzul.GetComponent<Receptores>().Apagar();
                        tempReceptorAzul = null;
                    }
                    lrAzul.SetPosition(1, hit.point);
                }
                else if (tempReflectorAzul != null || tempReceptorAzul != null) {
                    if (tempReflectorAzul != null) {
                        tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorAzul = null;
                    }
                    if (tempReceptorAzul != null) {
                        tempReceptorAzul.GetComponent<Receptores>().Apagar();
                        tempReceptorAzul = null;
                    }
                }
                lrAzul.SetPosition(1, hit.point);
            } else {
                lrAzul.SetPosition(1, directionAzul * 200);
            }
             if (Physics.Raycast(LaserRojo.position, directionRojo, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorRojo && tempReflectorRojo != hit.collider.gameObject) tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorRojo) tempReceptorRojo.GetComponent<Receptores>().Apagar();
                    tempReflectorRojo = hit.collider.gameObject;
                    tempReflectorRojo.GetComponent<ReflejoEspejo>().Choca(lrRojo.material);
                     lrRojo.SetPosition(1, hit.point);
                } else if (hit.collider.CompareTag("Receptor")) {
                    if (tempReflectorRojo) tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorRojo && tempReceptorRojo != hit.collider.gameObject) tempReceptorRojo.GetComponent<Receptores>().Apagar();
                    tempReceptorRojo = hit.collider.gameObject;
                    tempReceptorRojo.GetComponent<Receptores>().Encender(lrRojo.material);
                     lrRojo.SetPosition(1, hit.point);
                }else if(hit.collider.CompareTag("Bloqueo")){
                    if (tempReflectorRojo != null) {
                        tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorRojo = null;
                    }
                    if (tempReceptorRojo != null) {
                        tempReceptorRojo.GetComponent<Receptores>().Apagar();
                        tempReceptorRojo = null;
                    }
                    lrRojo.SetPosition(1, hit.point);
                }
                else if (tempReflectorRojo != null || tempReceptorRojo != null) {
                    if (tempReflectorRojo != null) {
                        tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorRojo = null;
                    }
                    if (tempReceptorRojo != null) {
                        tempReceptorRojo.GetComponent<Receptores>().Apagar();
                        tempReceptorRojo = null;
                    }
                }
                lrRojo.SetPosition(1, hit.point);
            } else {
                lrRojo.SetPosition(1, directionRojo * 200);
            }
            if (Physics.Raycast(LaserAmarillo.position, directionAmarillo, out hit, Mathf.Infinity)) {
              if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorAmarillo && tempReflectorAmarillo != hit.collider.gameObject) tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAmarillo) tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                    tempReflectorAmarillo = hit.collider.gameObject;
                    tempReflectorAmarillo.GetComponent<ReflejoEspejo>().Choca(lrAmarillo.material);
                }else if (hit.collider.CompareTag("Receptor")) {
                    if (tempReflectorAmarillo) tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAmarillo && tempReceptorAmarillo != hit.collider.gameObject) tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                    tempReceptorAmarillo = hit.collider.gameObject;

                    tempReceptorAmarillo.GetComponent<Receptores>().Encender(lrAmarillo.material);
                    //lrAmarillo.SetPosition(1, hit.point);
                }else if(hit.collider.CompareTag("Bloqueo")){
                     if (tempReflectorAmarillo != null) {
                        tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorAmarillo = null;
                    }
                    if (tempReceptorAmarillo != null) {
                        tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                        tempReceptorAmarillo = null;
                    }
                } 
                else if (tempReflectorAmarillo != null || tempReceptorAmarillo != null) {
                    if (tempReflectorAmarillo != null) {
                        tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorAmarillo = null;
                    }
                    if (tempReceptorAmarillo != null) {
                        tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                        tempReceptorAmarillo = null;
                    }
                }
                lrAmarillo.SetPosition(1, hit.point);
            } else {
                lrAmarillo.SetPosition(1, directionRojo * 200);
            }
        } else if(!LadoBlanco){
            //Debug.Log("apagando laseres");
            lrAzul.enabled = false;
            lrRojo.enabled = false;
            lrAmarillo.enabled = false;
            if (tempReflectorAzul != null) {
                tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflectorAzul = null;
            }
            if (tempReflectorRojo != null) {
                tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflectorRojo = null;
            }
            if (tempReflectorAmarillo != null) {
                tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflectorAmarillo = null;
            }
            if (tempReceptorAzul != null) {
                tempReceptorAzul.GetComponent<Receptores>().Apagar();
                tempReceptorAzul = null;
            }
            if (tempReceptorRojo != null) {
                tempReceptorRojo.GetComponent<Receptores>().Apagar();
                tempReceptorRojo = null;
            }
            if (tempReceptorAmarillo != null) {
                tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                tempReceptorAmarillo = null;
            }
        }
    }
    public void encenderLBlanco(Material m){
        //Debug.Log("Recibo "+ m.name.Substring(0, 11));
        if (m.name.Substring(0, 11) == "LaserBlanca"){
            LadoBlanco = true;
        }else{
            LadoBlanco = false;
        }
    }
    public void apagarLBlanco(){
        //Debug.Log("Apagan el blanco");
        LadoBlanco = false;
    }
    public void encenderLAzul(Material m){
        if(m.name.Substring(0, 9) == "LaserAzul"){
            PrismaSuperior.LadoAzul = true;
           
        }else{
             PrismaSuperior.LadoAzul = false;
        }
            
    }
    public void apagarLAzul(){
         PrismaSuperior.LadoAzul = false;
    }
    public void encenderLRojo(Material m){
        if(m.name.Substring(0, 9) == "LaserRoja"){
            PrismaSuperior.LadoRojo = true;
            LadoBlanco = false;
            
        }else{
            PrismaSuperior.LadoRojo = false;
        }
             
    }
    public void apagarLRojo(){
         PrismaSuperior.LadoRojo = false;
    }
    public void encenderLAmarillo(Material m){
        if(m.name.Substring(0, 13) == "LaserAmarilla"){
            PrismaSuperior.LadoAmarillo = true;
            LadoBlanco = false;
        }else{
             PrismaSuperior.LadoAmarillo = false;
        }
        
    }
    public void apagarLAmarillo(){
         PrismaSuperior.LadoAmarillo = false;
    }

    /// </summary>
    void OnDestroy()
    {
        //Debug.Log("Destruidos");
        lrAzul.enabled = false;
        lrRojo.enabled = false;
        lrAmarillo.enabled = false;
        if (tempReflectorAzul != null) {
            tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
            tempReflectorAzul = null;
        }
        if (tempReflectorRojo != null) {
            tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
            tempReflectorRojo = null;
        }
        if (tempReflectorAmarillo != null) {
            tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
            tempReflectorAmarillo = null;
        }
        if (tempReceptorAzul != null) {
            tempReceptorAzul.GetComponent<Receptores>().Apagar();
            tempReceptorAzul = null;
        }
        if (tempReceptorRojo != null) {
            tempReceptorRojo.GetComponent<Receptores>().Apagar();
            tempReceptorRojo = null;
        }
        if (tempReceptorAmarillo != null) {
            tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
            tempReceptorAmarillo = null;
        }
    }
}
