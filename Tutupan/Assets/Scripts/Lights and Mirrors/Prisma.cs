using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Prisma : MonoBehaviour
{
    public bool LadoBlanco = false;
    public bool LadoAzul = false;
    public bool LadoRojo = false;
    public bool LadoAmarillo = false;
    Vector3 directionBlanco, directionAzul, directionRojo, directionAmarillo;
    public Transform LaserBlanco, LaserAzul, LaserRojo, LaserAmarillo;
    private LineRenderer lrBlanco, lrAzul, lrRojo, lrAmarillo;
    GameObject tempReflectorBlanco, tempReflectorAzul, tempReflectorRojo, tempReflectorAmarillo
    , tempReceptorBlanco, tempReceptorAzul, tempReceptorRojo, tempReceptorAmarillo,
    tempPrismaBlanco, tempPrismaAzul, tempPrismaRojo, tempPrismaAmarillo;
    // Start is called before the first frame update
    void Start()
    {
        lrBlanco = LaserBlanco.GetComponent<LineRenderer>();
        lrAzul = LaserAzul.GetComponent<LineRenderer>();
        lrRojo = LaserRojo.GetComponent<LineRenderer>();
        lrAmarillo = LaserAmarillo.GetComponent<LineRenderer>();
        lrBlanco.positionCount = 2;
        lrAzul.positionCount = 2;
        lrRojo.positionCount = 2;
        lrAmarillo.positionCount = 2;

    }

    // Update is called once per frame
    void Update()
    {
        if (LadoBlanco){
            Debug.Log("LadoBlanco tocado");
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
                    if (tempReflectorAzul) tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAzul) tempReceptorAzul.GetComponent<Receptores>().Apagar();
                    tempReflectorAzul = hit.collider.gameObject;
                    tempReflectorAzul.GetComponent<ReflejoEspejo>().Choca(lrAzul.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                   // Debug.Log("Toco receptor");
                    if (tempReflectorAzul) tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAzul) tempReceptorAzul.GetComponent<Receptores>().Apagar();
                    tempReceptorAzul = hit.collider.gameObject;
                    tempReceptorAzul.GetComponent<Receptores>().Encender(lrAzul.material);
                }/*else if(hit.collider.CompareTag("LadoBlanco") || hit.collider.CompareTag("LadoAzul")
                     || hit.collider.CompareTag("LadoRojo") || hit.collider.CompareTag("LadoAmarillo")){
                    if (tempReflectorAzul) tempReflectorAzul.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAzul) tempReceptorAzul.GetComponent<Receptores>().Apagar();
                    if (tempPrismaAzul){ tempPrismaAzul.GetComponent<Prisma>().apagarLBlanco();
                                        tempPrismaAzul.GetComponent<Prisma>().apagarLRojo();
                                        tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                                        tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();}
                    tempPrismaAzul = hit.collider.gameObject;
                    tempPrisma2.GetComponent<Prisma>().encenderLBlanco(lr2.material);
                    tempPrisma2.GetComponent<Prisma>().encenderLRojo(lr2.material);
                    tempPrisma2.GetComponent<Prisma>().encenderLAzul(lr2.material);
                    tempPrisma2.GetComponent<Prisma>().encenderLAmarillo(lr2.material);*/
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
             }else{
                lrAzul.SetPosition(1, directionAzul * 200);
            }
             if (Physics.Raycast(LaserRojo.position, directionRojo, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorRojo) tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorRojo) tempReceptorRojo.GetComponent<Receptores>().Apagar();
                    tempReflectorRojo = hit.collider.gameObject;
                    tempReflectorRojo.GetComponent<ReflejoEspejo>().Choca(lrRojo.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                   // Debug.Log("Toco receptor");
                    if (tempReflectorRojo) tempReflectorRojo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorRojo) tempReceptorRojo.GetComponent<Receptores>().Apagar();
                    tempReceptorRojo = hit.collider.gameObject;
                    tempReceptorRojo.GetComponent<Receptores>().Encender(lrRojo.material);
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
            }else{
                lrRojo.SetPosition(1, directionRojo * 200);
            }
             if (Physics.Raycast(LaserAmarillo.position, directionAmarillo, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorAmarillo) tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAmarillo) tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                    tempReflectorAmarillo = hit.collider.gameObject;
                    tempReflectorAmarillo.GetComponent<ReflejoEspejo>().Choca(lrAmarillo.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                   // Debug.Log("Toco receptor");
                    if (tempReflectorAmarillo) tempReflectorAmarillo.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorAmarillo) tempReceptorAmarillo.GetComponent<Receptores>().Apagar();
                    tempReceptorAmarillo = hit.collider.gameObject;
                    tempReceptorAmarillo.GetComponent<Receptores>().Encender(lrAmarillo.material);
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
            }else{
                lrAmarillo.SetPosition(1, directionRojo * 200);
            }
        }else {
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
        if(LadoAzul && LadoRojo && LadoAmarillo){
            lrBlanco.enabled = true;
            lrBlanco.SetPosition(0, LaserBlanco.position);
            directionBlanco = LaserBlanco.forward;
            RaycastHit hit;
            if (Physics.Raycast(LaserBlanco.position, directionBlanco, out hit, Mathf.Infinity)){
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflectorBlanco) tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorBlanco) tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                    tempReflectorBlanco = hit.collider.gameObject;
                    tempReflectorBlanco.GetComponent<ReflejoEspejo>().Choca(lrBlanco.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                   // Debug.Log("Toco receptor");
                    if (tempReflectorBlanco) tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptorBlanco) tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                    
                    tempReceptorBlanco = hit.collider.gameObject;
                    tempReceptorBlanco.GetComponent<Receptores>().Encender(lrBlanco.material);
                }
                else if (tempReflectorBlanco != null || tempReceptorBlanco != null) {
                    if (tempReflectorBlanco != null) {
                        tempReflectorBlanco.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflectorBlanco = null;
                    }
                    if (tempReceptorBlanco != null) {
                        tempReceptorBlanco.GetComponent<Receptores>().Apagar();
                        tempReceptorBlanco = null;
                    }
                    
                }
                lrBlanco.SetPosition(1, hit.point);
            }else lrBlanco.SetPosition(1, directionBlanco * 200);
        }else{
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
    public void encenderLBlanco(Material m){
    //Debug.Log("material " + m.name);
        if (m.name == "LaserBlanca (Instance)"){
            //Debug.Log("material correcto");
            LadoBlanco = true;
        }
            
    }
    public void apagarLBlanco(){
        LadoBlanco = false;
    }
    public void encenderLAzul(Material m){
        if(m.name == "LaserAzul (Instance)")
            LadoAzul = true;
    }
    public void apagarLAzul(){
        LadoAzul = false;
    }
    public void encenderLRojo(Material m){
        if(m.name == "LaserRoja (Instance)")
            LadoRojo = true;
    }
    public void apagarLRojo(){
        LadoRojo = false;
    }
    public void encenderLAmarillo(Material m){
        if(m.name == "LaserAmarilla (Instance)")
            LadoAmarillo = true;
    }
    public void apagarLAmarillo(){
        LadoAmarillo = false;
    }
}
