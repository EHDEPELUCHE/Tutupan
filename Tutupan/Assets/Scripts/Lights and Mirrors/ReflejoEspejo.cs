using UnityEngine;

public class ReflejoEspejo : MonoBehaviour
{
    Vector3 direction1, direction2;
    public Transform Laser1, Laser2;
    private LineRenderer lr1, lr2;
    public bool aux = false;
    private GameObject origen;
    GameObject tempReflector1, tempReflector2, tempReceptor1, tempReceptor2;
    
    private void Start() {
        // Obtén la referencia al Line Renderer
        lr1 = Laser1.GetComponent<LineRenderer>();
        lr2 = Laser2.GetComponent<LineRenderer>();
        lr1.positionCount = 2;
        lr2.positionCount = 2;
    }
    
    void FixedUpdate() {
        if (aux) {
            lr1.enabled = true;
            lr2.enabled = true;
            lr1.SetPosition(0, Laser1.position);
            lr2.SetPosition(0, Laser2.position);
            direction1 = Laser1.forward;
            direction2 = Laser2.forward;
            RaycastHit hit;
            if (Physics.Raycast(Laser1.position, direction1, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflector1) tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor1) tempReceptor1.GetComponent<Receptores>().Apagar();
                    tempReflector1 = hit.collider.gameObject;
                    tempReflector1.GetComponent<ReflejoEspejo>().Choca(lr1.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                   // Debug.Log("Toco receptor");
                    if (tempReflector1) tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor1) tempReceptor1.GetComponent<Receptores>().Apagar();
                    tempReceptor1 = hit.collider.gameObject;
                    tempReceptor1.GetComponent<Receptores>().Encender();
                }
                else if (tempReflector1 != null || tempReceptor1 != null) {
                    if (tempReflector1 != null) {
                        tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflector1 = null;
                    }
                    if (tempReceptor1 != null) {
                        tempReceptor1.GetComponent<Receptores>().Apagar();
                        tempReceptor1 = null;
                    }
                }
                lr1.SetPosition(1, hit.point);
            }
            else lr1.SetPosition(1, direction1 * 200);
            if (Physics.Raycast(Laser2.position, direction2, out hit, Mathf.Infinity)) {
                if (hit.collider.CompareTag("Reflector")) {
                    if (tempReflector2) tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor2) tempReceptor2.GetComponent<Receptores>().Apagar();
                    tempReflector2 = hit.collider.gameObject;
                    /*if (tempReflector2 != origen){
                        tempReflector2.GetComponent<ReflejoEspejo>().Choca(lr2.material, this.gameObject);
                    }
                    else{
                        lr2.enabled = false;
                    }*/
                    tempReflector2.GetComponent<ReflejoEspejo>().Choca(lr2.material, this.gameObject);
                }else if (hit.collider.CompareTag("Receptor")) {
                    //Debug.Log("Toco receptor");
                    if (tempReflector2) tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                    if (tempReceptor2) tempReceptor2.GetComponent<Receptores>().Apagar();
                    tempReceptor2 = hit.collider.gameObject;
                    tempReceptor2.GetComponent<Receptores>().Encender();
                }
                else if (tempReflector2 != null || tempReceptor2 != null) {
                    if (tempReflector2 != null) {
                        tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                        tempReflector2 = null;
                    }
                    if (tempReceptor2 != null) tempReceptor2.GetComponent<Receptores>().Apagar();
                }
                lr2.SetPosition(1, hit.point);
            }
            else lr2.SetPosition(1, direction2 * 200);
        }
        else {
            lr1.enabled = false;
            lr2.enabled = false;
            if (tempReflector1 != null) {
                tempReflector1.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflector1 = null;
            }
            if (tempReflector2 != null) {
                tempReflector2.GetComponent<ReflejoEspejo>().NoChoca();
                tempReflector2 = null;
            }
            if (tempReceptor1 != null) {
                tempReceptor1.GetComponent<Receptores>().Apagar();
                tempReceptor1 = null;
            }
            if (tempReceptor2 != null) {
                tempReceptor2.GetComponent<Receptores>().Apagar();
                tempReceptor2 = null;
            }
        }
    }

    public void Choca(Material m, GameObject or) {
        aux = true;
        lr1.material = m;
        lr2.material = m;
        origen = or;
    }

    public void NoChoca() {
        aux = false;
    }
}
