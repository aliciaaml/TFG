using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSiguiente : MonoBehaviour
{
    public GameObject LetreroNoMinijuego;
    //public GameObject botonPlayerSig;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public static bool siguientePlayer = false;

    public void SiguientePlayer(){

        siguientePlayer = true;

        //ROTAR DE NUEVO JUGADOR

        if(CambiarPlayer.TurnoPlayer1){

            if (ComunPlayers.angle > 90f) //Si est� hacia detras se gira
            {
                player1.transform.Rotate(Vector3.up, -180f);
            }
            //player1.transform.Rotate(Vector3.up, -180f);
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            CambiarPlayer.TurnoPlayer1 = false;
        }
        if(CambiarPlayer.TurnoPlayer2){

            if (ComunPlayers.angle > 90f) //Si est� hacia detras se gira
            {
                player2.transform.Rotate(Vector3.up, -180f);
            }
            DontDestroy.guardarPosPlayer2 = player2.transform.position;
            CambiarPlayer.TurnoPlayer2 = false;
        }

        if(CambiarPlayer.TurnoPlayer3){


            if (ComunPlayers.angle > 90f) //Si est� hacia detras se gira
            {
                player3.transform.Rotate(Vector3.up, -180f);
            }
            DontDestroy.guardarPosPlayer3 = player3.transform.position;
            CambiarPlayer.TurnoPlayer3 = false;
        }

        if(CambiarPlayer.TurnoPlayer4){

            if (ComunPlayers.angle > 90f) //Si est� hacia detras se gira
            {
                player4.transform.Rotate(Vector3.up, -180f);
            }
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
            CambiarPlayer.TurnoPlayer4 = false;
        }

        LetreroNoMinijuego.SetActive(false);

        if(ComunPlayers.index<3 ){

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
