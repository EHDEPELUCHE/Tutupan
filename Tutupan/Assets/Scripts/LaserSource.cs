using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserSource : MonoBehaviour
{
    [SerializeField] Transform laserStartPoint;
    Vector3 direction;
    LineRenderer lr;
    GameObject tempReflector;
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
                    tempReflector.GetComponent<ReflejoEspejo>().noChoca();
                }
                tempReflector = hit.collider.gameObject;
                Vector3 temp = Vector3.Reflect(direction, hit.normal);
                hit.collider.gameObject.GetComponent<ReflejoEspejo>().Choca(lr.material, this.gameObject);
                //hit.collider.gameObject.GetComponent<ReflejoEspejo>().noChoca();
            }else if(tempReflector != null){
                tempReflector.GetComponent<ReflejoEspejo>().noChoca();
                tempReflector = null;
            }
            lr.SetPosition(1, hit.point);
        }else{
            if(tempReflector != null){
                tempReflector.GetComponent<ReflejoEspejo>().noChoca();
                tempReflector = null;
            }
            lr.SetPosition(1, direction * 200);
        }
    }
}
