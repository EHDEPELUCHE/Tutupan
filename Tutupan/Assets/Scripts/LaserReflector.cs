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


/*

using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
[RequireComponent(typeof(PolygonCollider2D))] // O el tipo de collider que desees
public class LineWithCollider : MonoBehaviour
{
    LineRenderer lineRenderer;
    PolygonCollider2D polyCollider;

    void Start()
    {
        // Obtener el Line Renderer y el Collider
        lineRenderer = GetComponent<LineRenderer>();
        polyCollider = GetComponent<PolygonCollider2D>();

        // Crear el Collider basado en la forma del Line Renderer
        UpdateCollider();
    }

    void Update()
    {
        // Si la trayectoria del Line Renderer cambia, actualiza el Collider
        UpdateCollider();
    }

    void UpdateCollider()
    {
        // Obtener los puntos del Line Renderer
        Vector3[] points = new Vector3[lineRenderer.positionCount];
        lineRenderer.GetPositions(points);

        // Convertir los puntos locales a puntos del mundo
        for (int i = 0; i < points.Length; i++)
        {
            points[i] = transform.TransformPoint(points[i]);
        }

        // Asignar los puntos al Collider
        polyCollider.SetPath(0, points);
    }
}

*/

/*

using System.Collections.Generic;
using UnityEngine;

public class Rope : MonoBehaviour
{
    public Transform player;

    public LineRenderer rope;
    public LayerMask collMask;

    public List<Vector3> ropePositions { get; set; } = new List<Vector3>();

    private void Awake() => AddPosToRope(Vector3.zero);

    private void Update()
    {
        UpdateRopePositions();
        LastSegmentGoToPlayerPos();

        DetectCollisionEnter();
        if (ropePositions.Count > 2) DetectCollisionExits();        
    }

    private void DetectCollisionEnter()
    {
        RaycastHit hit;
        if (Physics.Linecast(player.position, rope.GetPosition(ropePositions.Count - 2), out hit, collMask))
        {
            ropePositions.RemoveAt(ropePositions.Count - 1);
            AddPosToRope(hit.point);
        }
    }

    private void DetectCollisionExits()
    {
        RaycastHit hit;
        if (!Physics.Linecast(player.position, rope.GetPosition(ropePositions.Count - 3), out hit, collMask))
        {
            ropePositions.RemoveAt(ropePositions.Count - 2);
        }
    }

    private void AddPosToRope(Vector3 _pos)
    {
        ropePositions.Add(_pos);
        ropePositions.Add(player.position); //Always the last pos must be the player
    }

    private void UpdateRopePositions()
    {
        rope.positionCount = ropePositions.Count;
        rope.SetPositions(ropePositions.ToArray());
    }

    private void LastSegmentGoToPlayerPos() => rope.SetPosition(rope.positionCount - 1, player.position);
}

*/