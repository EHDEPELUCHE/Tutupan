using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rotacion : MonoBehaviour
{
  private Transform t;
  public static bool modoBorrado = false;

  // public GameObject a;
  // Start is called before the first frame update
  void Start() {
    t = this.GetComponent<Transform>();
  }

  void OnMouseDown() {
    if(modoBorrado){
      modoBorrado = false;
      Destroy(this.gameObject);  
    }else{
      t.RotateAround(this.transform.position, Vector3.up, 90f);
    }  
  }

  void OnDestroy() {
    Casilla.modoBorrado = true;
  }
}
