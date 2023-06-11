using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class colisionPlayer : MonoBehaviour
{
    

    public static GameObject casilla_actual;

    public static int actual = 0;

    GameObject casilla_aux;

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "casillas"){
            
            casilla_actual = other.gameObject;

            if(casilla_actual!=casilla_aux){

                casilla_aux = casilla_actual;
                Debug.Log(casilla_actual);
                actual +=1;
            }
        }
        
    }

}
