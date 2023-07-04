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

        if(CambiarPlayer.TurnoPlayer1){
            
            Quaternion newRotation = Quaternion.Euler(player1.transform.eulerAngles.x, player1.transform.eulerAngles.y -180f, player1.transform.eulerAngles.z);
            player1.transform.rotation = newRotation;
        }
        if(CambiarPlayer.TurnoPlayer2){

            Quaternion newRotation = Quaternion.Euler(player2.transform.eulerAngles.x, player2.transform.eulerAngles.y -180f, player2.transform.eulerAngles.z);
            player2.transform.rotation = newRotation;
        }

        if(CambiarPlayer.TurnoPlayer3){

            Quaternion newRotation = Quaternion.Euler(player3.transform.eulerAngles.x, player3.transform.eulerAngles.y -180f, player3.transform.eulerAngles.z);
            player3.transform.rotation = newRotation;
        }

        if(CambiarPlayer.TurnoPlayer4){

            Quaternion newRotation = Quaternion.Euler(player3.transform.eulerAngles.x, player3.transform.eulerAngles.y -180f, player3.transform.eulerAngles.z);
            player4.transform.rotation = newRotation;
        }

        LetreroMinijuego.SetActive(false);
        botonMinijuego.SetActive(false);

        ScriptBotonSiguiente.SiguientePlayer();

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
