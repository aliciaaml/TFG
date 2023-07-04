using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class colisionPlayer : MonoBehaviour
{
    public TextMeshProUGUI dadoTexto;
    public static GameObject casilla_actual;

    public static int actual = 0;

    GameObject casilla_aux;
    public static int contadorDado = 0;

    void OnTriggerEnter(Collider other) {

        if(other.gameObject.tag == "casillas"){
            
            casilla_actual = other.gameObject;

            if(casilla_actual!=casilla_aux){

                casilla_aux = casilla_actual;
                Debug.Log(casilla_actual);
                actual +=1;
                NumDado.auxNumDado-=1;
                Debug.Log("contaDado: " + NumDado.auxNumDado);
                dadoTexto.text = (NumDado.auxNumDado).ToString();
            }
        }
        
    }

}
