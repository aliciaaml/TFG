using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSiguiente : MonoBehaviour
{
    public GameObject LetreroNoMinijuego;
    public GameObject botonPlayerSig;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public void SiguientePlayer(){


        //ROTAR DE NUEVO JUGADOR

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



        LetreroNoMinijuego.SetActive(false);
        botonPlayerSig.SetActive(false);

        if(ComunPlayers.index<3 ){

            
            Debug.Log("ESTA ENTRANDO3");
            ComunPlayers.ActualizarPosicionPlayer();
            ComunPlayers.Inicio = false;
            ComunPlayers.comienza_turno = false;
            ComunPlayers.siguiente = true;
            ComunPlayers.index+=1;
            ComunPlayers.casilla_destino = 0;
            MovementPlayer1.una_vez = true;
            NumDado.resultado_dado_obtenido = false;
            MovementPlayer1.detectar_casilla = true;
            ElegirPosiciones.turno_terminado = false;

        }
        else if(ComunPlayers.index == 3){

            ComunPlayers.ActualizarPosicionPlayer();
            ComunPlayers.Inicio = false;
            ComunPlayers.comienza_turno = false;
            
            ComunPlayers.siguiente = true;
            
            ComunPlayers.index = 0;
            ComunPlayers.casilla_destino = 0;
            MovementPlayer1.una_vez = true;
            NumDado.resultado_dado_obtenido = false;
            MovementPlayer1.detectar_casilla = true;
            ElegirPosiciones.turno_terminado = false;

        }
    }
}
