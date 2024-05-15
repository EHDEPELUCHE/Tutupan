using UnityEngine;

public class ReflejoEspejo : MonoBehaviour
{
    Vector3 direction1, direction2;
    public Transform Laser1, Laser2;
    private LineRenderer lr1, lr2;
    public bool aux = false;
    private GameObject origen;
    GameObject tempReflector1, tempReflector2, tempReceptor1, tempReceptor2, tempPrisma1, tempPrisma2;
    public Material rojo, azul, blanco ,amarillo;

    private void Start()
    {
        // Obtén la referencia al Line Renderer
        lr1 = Laser1.GetComponent<LineRenderer>();
        lr2 = Laser2.GetComponent<LineRenderer>();
        lr1.positionCount = 2;
        lr2.positionCount = 2;
    }

    void FixedUpdate()
    {
        if (aux)
        {
            lr1.enabled = true;
            lr2.enabled = true;
            lr1.SetPosition(0, Laser1.position);
            lr2.SetPosition(0, Laser2.position);
            direction1 = Laser1.forward;
            direction2 = Laser2.forward;
            RaycastHit hit;
            if (Physics.Raycast(Laser1.position, direction1, out hit, Mathf.Infinity))
            {
                if (hit.collider.CompareTag("Reflector"))
                {
                    if (tempReflector1) tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor1) tempReceptor1.GetComponent<Receptores>().Apagar();
                    if (tempPrisma1)
                    {
                        tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                        tempPrisma1.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma1.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma1.GetComponent<Prisma>().apagarLAmarillo();
                    }
                    tempReflector1 = hit.collider.gameObject;
                    tempReflector1.GetComponent<ReflejoEspejo>().Choca(lr1.material, this.gameObject);
                }
                else if (hit.collider.CompareTag("Receptor"))
                {
                    // Debug.Log("Toco receptor");
                    if (tempReflector1) tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor1) tempReceptor1.GetComponent<Receptores>().Apagar();
                    if (tempPrisma1)
                    {
                        tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                        tempPrisma1.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma1.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma1.GetComponent<Prisma>().apagarLAmarillo();
                    }
                    tempReceptor1 = hit.collider.gameObject;
                    tempReceptor1.GetComponent<Receptores>().Encender(lr1.material);
                }
                else if (hit.collider.CompareTag("LadoBlanco") || hit.collider.CompareTag("LadoAzul")
                     || hit.collider.CompareTag("LadoRojo") || hit.collider.CompareTag("LadoAmarillo"))
                {
                    if (tempReflector1) tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor1) tempReceptor1.GetComponent<Receptores>().Apagar();
                    if (tempPrisma1)
                    {
                        if (hit.collider.CompareTag("LadoBlanco"))
                        {
                            //tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                            tempPrisma1.GetComponent<Prisma>().apagarLRojo();
                            tempPrisma1.GetComponent<Prisma>().apagarLAzul();
                            tempPrisma1.GetComponent<Prisma>().apagarLAmarillo();
                        }
                        else tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                    }
                    tempPrisma1 = hit.collider.gameObject;
                    if (hit.collider.CompareTag("LadoBlanco")){//Debug.Log("Detecta blanco");
                        tempPrisma1.GetComponent<Prisma>().encenderLBlanco(lr1.material);}
                    if (hit.collider.CompareTag("LadoRojo"))
                        tempPrisma1.GetComponent<Prisma>().encenderLRojo(lr1.material);
                    if (hit.collider.CompareTag("LadoAzul"))
                        tempPrisma1.GetComponent<Prisma>().encenderLAzul(lr1.material);
                    if (hit.collider.CompareTag("LadoAmarillo"))
                        tempPrisma1.GetComponent<Prisma>().encenderLAmarillo(lr1.material);

                    lr1.SetPosition(1, hit.point);
                }
                else if (tempReflector1 != null || tempReceptor1 != null || tempPrisma1 != null)
                {
                    if (tempReflector1 != null)
                    {
                        tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflector1 = null;
                    }
                    if (tempReceptor1 != null)
                    {
                        tempReceptor1.GetComponent<Receptores>().Apagar();
                        tempReceptor1 = null;
                    }
                    if (tempPrisma1 != null)
                    {
                        tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                        tempPrisma1.GetComponent<Prisma>().apagarLRojo();
                        tempPrisma1.GetComponent<Prisma>().apagarLAzul();
                        tempPrisma1.GetComponent<Prisma>().apagarLAmarillo();
                        tempPrisma1 = null;
                    }
                    lr1.SetPosition(1, hit.point);
                }
                else lr1.SetPosition(1, direction1 * 200);
                if (Physics.Raycast(Laser2.position, direction2, out hit, Mathf.Infinity))
                {
                    if (hit.collider.CompareTag("Reflector"))
                    {
                        if (tempReflector2) tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                        if (tempReceptor2) tempReceptor2.GetComponent<Receptores>().Apagar();
                          if (tempPrisma2)
                        {
                                tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                                tempPrisma2.GetComponent<Prisma>().apagarLRojo();
                                tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                                tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();
                            }
                        tempReflector2 = hit.collider.gameObject;
                        /*if (tempReflector2 != origen){
                            tempReflector2.GetComponent<ReflejoEspejo>().Choca(lr2.material, this.gameObject);
                        }
                        else{
                            lr2.enabled = false;
                        }*/
                        tempReflector2.GetComponent<ReflejoEspejo>().Choca(lr2.material, this.gameObject);
                    }
                    else if (hit.collider.CompareTag("Receptor"))
                    {
                        //Debug.Log("Toco receptor");
                        if (tempReflector2) tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                        if (tempReceptor2) tempReceptor2.GetComponent<Receptores>().Apagar();
                        if (tempPrisma2)
                        {
                                tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                                tempPrisma2.GetComponent<Prisma>().apagarLRojo();
                                tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                                tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();
                            }
                        tempReceptor2 = hit.collider.gameObject;
                        tempReceptor2.GetComponent<Receptores>().Encender(lr2.material);
                    }
                    else if (hit.collider.CompareTag("LadoBlanco") || hit.collider.CompareTag("LadoAzul")
                         || hit.collider.CompareTag("LadoRojo") || hit.collider.CompareTag("LadoAmarillo"))
                    {
                        if (tempReflector2) tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                        if (tempReceptor2) tempReceptor2.GetComponent<Receptores>().Apagar();
                        if (tempPrisma2)
                        {
                            if (hit.collider.CompareTag("LadoBlanco"))
                            {
                                //tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                                tempPrisma2.GetComponent<Prisma>().apagarLRojo();
                                tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                                tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();
                            }
                            else tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                        }
                        tempPrisma2 = hit.collider.gameObject;
                        if (hit.collider.CompareTag("LadoBlanco")){//Debug.Log("detecta blanco l2");
                            tempPrisma2.GetComponent<Prisma>().encenderLBlanco(lr2.material);}
                        if (hit.collider.CompareTag("LadoRojo"))
                            tempPrisma2.GetComponent<Prisma>().encenderLRojo(lr2.material);
                        if (hit.collider.CompareTag("LadoAzul"))
                            tempPrisma2.GetComponent<Prisma>().encenderLAzul(lr2.material);
                        if (hit.collider.CompareTag("LadoAmarillo"))
                            tempPrisma2.GetComponent<Prisma>().encenderLAmarillo(lr2.material);
                        lr2.SetPosition(1, hit.point);
                    }
                    else if (tempReflector2 != null || tempReceptor2 != null || tempPrisma2 != null)
                    {
                        if (tempReflector2 != null)
                        {
                            tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                            tempReflector2 = null;
                        }
                        if (tempReceptor2 != null) tempReceptor2.GetComponent<Receptores>().Apagar();
                        if (tempPrisma2)
                        {
                            tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                            tempPrisma2.GetComponent<Prisma>().apagarLRojo();
                            tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                            tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();
                            tempPrisma2 = null;
                        }
                    }
                    lr2.SetPosition(1, hit.point);
                }
                else lr2.SetPosition(1, direction2 * 200);
            }
            else
            {
                lr1.enabled = false;
                lr2.enabled = false;
                if (tempReflector1 != null)
                {
                    tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    tempReflector1 = null;
                }
                if (tempReflector2 != null)
                {
                    tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                    tempReflector2 = null;
                }
                if (tempReceptor1 != null)
                {
                    tempReceptor1.GetComponent<Receptores>().Apagar();
                    tempReceptor1 = null;
                }
                if (tempReceptor2 != null)
                {
                    tempReceptor2.GetComponent<Receptores>().Apagar();
                    tempReceptor2 = null;
                }
                if (tempPrisma1 != null)
                {
                    tempPrisma1.GetComponent<Prisma>().apagarLBlanco();
                    tempPrisma1.GetComponent<Prisma>().apagarLRojo();
                    tempPrisma1.GetComponent<Prisma>().apagarLAzul();
                    tempPrisma1.GetComponent<Prisma>().apagarLAmarillo();
                    tempPrisma1 = null;
                }
                if (tempPrisma2)
                {
                    tempPrisma2.GetComponent<Prisma>().apagarLBlanco();
                    tempPrisma2.GetComponent<Prisma>().apagarLRojo();
                    tempPrisma2.GetComponent<Prisma>().apagarLAzul();
                    tempPrisma2.GetComponent<Prisma>().apagarLAmarillo();
                    tempPrisma2 = null;
                }
            }
        }
    }

    public void Choca(Material m, GameObject or)
    {
        aux = true;
        if (m != null){
            Debug.Log ("Llega m valiendo " + m);
            lr2.material = m;
            lr1.material = m;
        } 
        
    }

    public void NoChoca() { aux = false; }
}