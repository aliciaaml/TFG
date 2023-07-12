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

        if(CambiarPlayer.TurnoPlayer1 && ComunPlayers.pierdeTurnoplayer1 == false){
  
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
        
                player1.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            DontDestroy.guardarRotacionPlayer1 = player1.transform.rotation;
            CambiarPlayer.TurnoPlayer1 = false;
        }
        if(CambiarPlayer.TurnoPlayer2 && ComunPlayers.pierdeTurnoplayer2 == false){
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player2.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer2 = player2.transform.position;
            DontDestroy.guardarRotacionPlayer2 = player2.transform.rotation;
            CambiarPlayer.TurnoPlayer2 = false;
        }

        if(CambiarPlayer.TurnoPlayer3 && ComunPlayers.pierdeTurnoplayer3 == false){

            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player3.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer3 = player3.transform.position;
            DontDestroy.guardarRotacionPlayer3 = player3.transform.rotation;
            CambiarPlayer.TurnoPlayer3 = false;
        }

        if(CambiarPlayer.TurnoPlayer4 && ComunPlayers.pierdeTurnoplayer4 == false){
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                player4.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
            DontDestroy.guardarRotacionPlayer4 = player4.transform.rotation;
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
