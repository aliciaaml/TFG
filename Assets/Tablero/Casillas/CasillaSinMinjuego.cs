using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaSinMinjuego : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player1" || other.gameObject.tag == "player2" || other.gameObject.tag == "player3" || other.gameObject.tag == "player4"){
            CasillaMinCoco.casilla_minijuego = "";
        }
    }
}
