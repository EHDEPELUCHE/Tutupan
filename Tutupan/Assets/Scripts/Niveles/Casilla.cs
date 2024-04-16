using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Casilla : MonoBehaviour
{
    public int NumCasilla;
    
    void OnMouseDown() {
        print(NumCasilla.ToString());
    }
}
