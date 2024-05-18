using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    [SerializeField] Transform laserStartPoint;
    Vector3 direction;
    private LineRenderer lr;
    GameObject tempReflector, tempPrisma;
    
    // Start is called before the first frame update
    void Start()
    {
        lr = gameObject.GetComponent<LineRenderer>();
        direction = laserStartPoint.forward;
        lr.positionCount = 2;
        lr.SetPosition(0, laserStartPoint.position);
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        RaycastHit hit;
        if(Physics.Raycast(laserStartPoint.position, direction, out hit, Mathf.Infinity)){
            if(hit.collider.CompareTag("Reflector")){
                if(tempReflector && tempReflector != hit.collider.gameObject){
                    tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                }
                if(tempPrisma){
                    tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                    tempPrisma.GetComponent<Prisma>().apagarLRojo();
                    tempPrisma.GetComponent<Prisma>().apagarLAzul();
                    tempPrisma.GetComponent<Prisma>().apagarLAmarillo();
                    Prisma.Siguerecibiendo = false;
                }
                    
                tempReflector = hit.collider.gameObject;
                //Debug.Log("Material mandado: " + lr.material);
                hit.collider.gameObject.GetComponent<ReflejoEspejo>().Choca(lr.material);
                Prisma.Siguerecibiendo = false;
                //hit.collider.gameObject.GetComponent<ReflejoEspejo>().NoChoca();
            }else if( hit.collider.CompareTag("LadoRojo") || hit.collider.CompareTag("LadoAmarillo") || hit.collider.CompareTag("LadoAzul")){
                    if(tempReflector){
                        tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                    }
                    
                    if(tempPrisma){
                        tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                        Prisma.Siguerecibiendo = false;
                    }
                    
                    tempPrisma = hit.collider.gameObject;
                    tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                    Prisma.Siguerecibiendo = false;
                    if(hit.collider.CompareTag("LadoRojo"))
                        tempPrisma.GetComponent<Prisma>().encenderLRojo(lr.material);
                    if(hit.collider.CompareTag("LadoAzul"))
                        tempPrisma.GetComponent<Prisma>().encenderLAzul(lr.material);
                    if(hit.collider.CompareTag("LadoAmarillo"))
                        tempPrisma.GetComponent<Prisma>().encenderLAmarillo(lr.material);

                }else if(hit.collider.CompareTag("LadoBlanco")){
                    if(tempReflector){
                        tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                    }
                    if(tempPrisma){
                        tempPrisma.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma.GetComponent<Prisma>().apagarLAmarillo();}
                        tempPrisma = hit.collider.gameObject;
                        tempPrisma.GetComponent<Prisma>().encenderLBlanco(lr.material);
                        if(lr.material.name.Substring(0, 11) == "LaserBlanca")
                            Prisma.Siguerecibiendo = true;
                }else if(hit.collider.CompareTag("Bloqueo")){
                    if(tempReflector){
                        tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflector = null;
                    }
                    if(tempPrisma){
                        tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                        tempPrisma.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma.GetComponent<Prisma>().apagarLAmarillo();
                        Prisma.Siguerecibiendo = false;
                        tempPrisma = null;
                    }
                }
                else if(tempReflector != null || tempPrisma != null){
                    if(tempReflector){
                        tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflector = null;
                    }
                    if(tempPrisma){
                        tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                        tempPrisma.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma.GetComponent<Prisma>().apagarLAmarillo();
                        Prisma.Siguerecibiendo = false;
                        tempPrisma = null;
                    }
                
            }
            lr.SetPosition(1, hit.point);
        }else{
            if(tempReflector != null){
                tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflector = null;
            }
            if(tempPrisma){
                tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                tempPrisma.GetComponent<Prisma>().apagarLRojo();
                tempPrisma.GetComponent<Prisma>().apagarLAzul();
                tempPrisma.GetComponent<Prisma>().apagarLAmarillo();
                Prisma.Siguerecibiendo = false;
                tempPrisma = null;
            }
            lr.SetPosition(1, direction * 200);
        }
    }

    public void OnDestroy(){
         if(tempReflector != null){
                tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflector = null;
            }
            if(tempPrisma){
                tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                tempPrisma.GetComponent<Prisma>().apagarLRojo();
                tempPrisma.GetComponent<Prisma>().apagarLAzul();
                tempPrisma.GetComponent<Prisma>().apagarLAmarillo();
                Prisma.Siguerecibiendo = false;
                tempPrisma = null;
            }
            //lr.SetPosition(1, direction * 200);
    }
}
