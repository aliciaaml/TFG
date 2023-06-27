using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BotonSiguiente : MonoBehaviour
{
    public GameObject LetreroNoMinijuego;
    public GameObject botonPlayerSig;

    public void SiguientePlayer(){

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
            Num_dado.resultado_dado_obtenido = false;
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
            Num_dado.resultado_dado_obtenido = false;
            MovementPlayer1.detectar_casilla = true;
            ElegirPosiciones.turno_terminado = false;

        }
    }
}
