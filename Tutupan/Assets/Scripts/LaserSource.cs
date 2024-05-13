using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    [SerializeField] Transform laserStartPoint;
    Vector3 direction;
    LineRenderer lr;
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
    void Update()
    {
        RaycastHit hit;
        if(Physics.Raycast(laserStartPoint.position, direction, out hit, Mathf.Infinity)){
            if(hit.collider.CompareTag("Reflector")){
                if(tempReflector){
                    tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                }
                tempReflector = hit.collider.gameObject;
                Vector3 temp = Vector3.Reflect(direction, hit.normal);
                hit.collider.gameObject.GetComponent<ReflejoEspejo>().Choca(lr.material, this.gameObject);
                //hit.collider.gameObject.GetComponent<ReflejoEspejo>().NoChoca();
            }else if(hit.collider.CompareTag("LadoBlanco")){
                if(tempReflector){
                    tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                }
                if(tempPrisma){
                    tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                                        tempPrisma.GetComponent<Prisma>().apagarLRojo();
                                        tempPrisma.GetComponent<Prisma>().apagarLAzul();
                                        tempPrisma.GetComponent<Prisma>().apagarLAmarillo();}
                tempPrisma = hit.collider.gameObject;
                tempPrisma.GetComponent<Prisma>().encenderLBlanco(lr.material);
                 
                }else if( hit.collider.CompareTag("LadoRojo") || hit.collider.CompareTag("LadoAmarillo") || hit.collider.CompareTag("LadoAzul")){
                    if(tempReflector){
                        tempReflector.GetComponent<ReflejoEspejo>().NoChoca();
                    }
                    if(tempPrisma){
                        tempPrisma.GetComponent<Prisma>().apagarLBlanco();
                                            tempPrisma.GetComponent<Prisma>().apagarLRojo();
                                            tempPrisma.GetComponent<Prisma>().apagarLAzul();
                                            tempPrisma.GetComponent<Prisma>().apagarLAmarillo();}
                    tempPrisma = hit.collider.gameObject;
                   
                        tempPrisma.GetComponent<Prisma>().encenderLRojo(lr.material);
                        tempPrisma.GetComponent<Prisma>().encenderLAzul(lr.material);
                        tempPrisma.GetComponent<Prisma>().encenderLAmarillo(lr.material);
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
                tempPrisma = null;
            }
            lr.SetPosition(1, direction * 200);
        }
    }
}
