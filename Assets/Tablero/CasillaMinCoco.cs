using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasillaMinCoco : MonoBehaviour
{
    public static string player= "";

    public static string casilla_minijuego = "";

    private void OnTriggerEnter(Collider other)
    {

        if(other.gameObject.tag == "player1"){

            player = "player1";

            casilla_minijuego = "juego_cocos";
        }
        else if(other.gameObject.tag == "player2"){
            player = "player2";

            casilla_minijuego = "juego_cocos";

        }
        else if(other.gameObject.tag== "player3"){

            player = "player3";

            casilla_minijuego = "juego_cocos";

        }
        else{

            player = "player4";

            casilla_minijuego = "juego_cocos";
        }
        

    }


    
}



/*
        Debug.Log("que esta pasando ??? : " + other.gameObject.tag);

        if(other.gameObject.tag == "juego_pesca"){

            casilla_minijuego = "pesca";
        }
        else if(other.gameObject.tag == "juego_cocos"){
            
            casilla_minijuego = "cocos";
        }
        else if(other.gameObject.tag == "juego_tiburones"){

            casilla_minijuego = "tiburones";

        }
        else {

            casilla_minijuego = "";
        }
         
        */
