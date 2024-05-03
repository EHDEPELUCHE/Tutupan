using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserReflector : MonoBehaviour
{
    private Vector3 screenPoint;
    private Vector3 offset;
    float rotationSpeed = 0.2f;
    Vector3 position;
    Vector3 direction;
    LineRenderer lr;
    public bool isOpen;
    GameObject tempReflector;
    [SerializeField] Transform laserStartPoint;
    // Start is called before the first frame update
    void Start()
    {
        isOpen = false;
        lr = gameObject.GetComponent<LineRenderer>();
        direction = laserStartPoint.forward;
        //lr.SetPosition(0, laserStartPoint.position);
    }

    // Update is called once per frame
    void Update()
    {
        if(isOpen){
            lr.positionCount = 2;
            lr.SetPosition(0, laserStartPoint.position);
            RaycastHit hit;
            if(Physics.Raycast(position, direction, out hit, Mathf.Infinity)){
                if(hit.collider.CompareTag("Reflector")){
                   /* tempReflector = hit.collider.gameObject;
                    Vector3 temp = Vector3.Reflect(direction, hit.normal);
                    hit.collider.gameObject.GetComponent<LaserReflector>().OpenRay(hit.point, temp);*/
                    Debug.Log("colision");
                    direction = laserStartPoint.forward;
                    lr.positionCount = 2;
                    lr.SetPosition(0, laserStartPoint.position);

                }
                lr.SetPosition(1, laserStartPoint.position);
            }else {
                if(tempReflector){
                    tempReflector.GetComponent<LaserReflector>().CloseRay();
                    tempReflector = null;
                }
                lr.SetPosition(0, laserStartPoint.position);
            }
        }else{
            if(tempReflector){
                    tempReflector.GetComponent<LaserReflector>().CloseRay();
                    tempReflector = null;
                }
        }
    }

    void OnCollisionEnter(Collision other)
    {
        Debug.Log("colision");
        direction = laserStartPoint.forward;
        lr.positionCount = 2;
        lr.SetPosition(0, laserStartPoint.position);
    }

    void OnTriggerEnter(Collider collide)
    {
        Debug.Log("TriggerEnter");
        Vector3 dir = collide.transform.position - transform.position;
        //if (dir.magnitude > 0){
            direction = laserStartPoint.forward;
            lr.positionCount = 2;
            lr.SetPosition(0, laserStartPoint.position);
        //}
    }

    public void OpenRay(Vector3 pos, Vector3 dir){
        isOpen = true;
        position = pos;
        direction = dir;
    }

    public void CloseRay(){
        isOpen = false;
        lr.positionCount = 0;
    }
}
