using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMinijuego : MonoBehaviour
{
    public BotonSiguiente ScriptBotonSiguiente;
    public GameObject LetreroMinijuego;
    public GameObject botonMinijuego;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    

    public void f_IrMinijuego(){
        
        LoadTablero.salirMinijuego = false;  
        ComunPlayers.no_detect_casilla_minijuego = true;    
        if(CambiarPlayer.TurnoPlayer1){
            
            //Quaternion newRotation = Quaternion.Euler(player1.transform.eulerAngles.x, player1.transform.eulerAngles.y -180f, player1.transform.eulerAngles.z);
            //player1.transform.rotation = newRotation;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player1.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            DontDestroy.guardarRotacionPlayer1 = player1.transform.rotation;
            CambiarPlayer.TurnoPlayer1 = false;
        }
        if(CambiarPlayer.TurnoPlayer2){

            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player2.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer2 = player2.transform.position;
            DontDestroy.guardarRotacionPlayer2 = player2.transform.rotation;
            CambiarPlayer.TurnoPlayer2 = false;
        }

        if(CambiarPlayer.TurnoPlayer3){

            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player3.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer3 = player3.transform.position;
            DontDestroy.guardarRotacionPlayer3 = player3.transform.rotation;
            CambiarPlayer.TurnoPlayer3 = false;
        }

        if(CambiarPlayer.TurnoPlayer4){

            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player4.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
            DontDestroy.guardarRotacionPlayer4 = player4.transform.rotation;
            CambiarPlayer.TurnoPlayer4 = false;
        }

        LetreroMinijuego.SetActive(false);
        botonMinijuego.SetActive(false);

        //ScriptBotonSiguiente.SiguientePlayer();

        if(CasillaMinCoco.casilla_minijuego == "juego_pesca"){

            SceneManager.LoadScene("Pesca");
        }
        if(CasillaMinCoco.casilla_minijuego == "juego_cocos"){
            SceneManager.LoadScene("Cocos");
        }
        if(CasillaMinCoco.casilla_minijuego == "juego_tiburones"){
            SceneManager.LoadScene("Tiburones");
        }

    }

}
