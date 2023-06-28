using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CasillaMinTiburones : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "player1"){

            CasillaMinCoco.player = "player1";

            CasillaMinCoco.casilla_minijuego = "juego_tiburones";
        }
        else if(other.gameObject.tag == "player2"){
            
            CasillaMinCoco.player = "player2";

            CasillaMinCoco.casilla_minijuego = "juego_tiburones";

        }
        else if(other.gameObject.tag== "player3"){

            CasillaMinCoco.player = "player3";

            CasillaMinCoco.casilla_minijuego = "juego_tiburones";

        }
        else{

            CasillaMinCoco.player = "player4";

            CasillaMinCoco.casilla_minijuego = "juego_tiburones";
        }
        

    }
}
