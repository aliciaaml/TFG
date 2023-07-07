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
            
            Quaternion newRotation = Quaternion.Euler(player1.transform.eulerAngles.x, player1.transform.eulerAngles.y -180f, player1.transform.eulerAngles.z);
            player1.transform.rotation = newRotation;
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            CambiarPlayer.TurnoPlayer1 = false;
        }
        if(CambiarPlayer.TurnoPlayer2){

            Quaternion newRotation = Quaternion.Euler(player2.transform.eulerAngles.x, player2.transform.eulerAngles.y -180f, player2.transform.eulerAngles.z);
            player2.transform.rotation = newRotation;
            DontDestroy.guardarPosPlayer2 = player2.transform.position;
            CambiarPlayer.TurnoPlayer2 = false;
        }

        if(CambiarPlayer.TurnoPlayer3){

            Quaternion newRotation = Quaternion.Euler(player3.transform.eulerAngles.x, player3.transform.eulerAngles.y -180f, player3.transform.eulerAngles.z);
            player3.transform.rotation = newRotation;
            DontDestroy.guardarPosPlayer3 = player3.transform.position;
            CambiarPlayer.TurnoPlayer3 = false;
        }

        if(CambiarPlayer.TurnoPlayer4){

            Quaternion newRotation = Quaternion.Euler(player4.transform.eulerAngles.x, player4.transform.eulerAngles.y -180f, player4.transform.eulerAngles.z);
            player4.transform.rotation = newRotation;
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
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
