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
     // Debug.Log("NOMBRE: " + this.gameObject.name.Substring(0,8));
      switch(this.gameObject.name.Substring(0,8)){
        case "Espejo(C":
            CrearCasillas.maxEspejo++;
            PlayerPrefs.SetInt("EspejosComprados", CrearCasillas.maxEspejo);
            CrearCasillas.textoespejo.text =  CrearCasillas.maxEspejo.ToString();
            
          break;
        case "EspejoDo":
            CrearCasillas.maxEspejodoble++;
            PlayerPrefs.SetInt("EspejosDoblesComprados", CrearCasillas.maxEspejodoble);
            CrearCasillas.textoespejodoble.text =  CrearCasillas.maxEspejodoble.ToString();
                    
          break;
        case "Cunna(Cl":
            CrearCasillas.maxCunna++;
            PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.maxCunna);
            CrearCasillas.textocunna.text =  CrearCasillas.maxCunna.ToString();
          break;
        case "Prisma(C":
              CrearCasillas.maxprisma++;
              PlayerPrefs.SetInt("PrismasComprados", CrearCasillas.maxprisma );
              CrearCasillas.textoprisma.text = CrearCasillas.maxprisma.ToString();
          break;
                default:
                   
                break;
      }
      Destroy(this.gameObject);  
    }else{
      t.RotateAround(this.transform.position, Vector3.up, 90f);
    }  
  }

  void OnDestroy() {
    Casilla.modoBorrado = true;
  }
}
