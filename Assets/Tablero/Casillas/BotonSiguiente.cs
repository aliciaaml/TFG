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

    public void ClickBoton()
    {
        if (CambiarPlayer.TurnoPlayer1)
        {
            CambiarPlayer.TurnoPlayer1 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                ComunPlayers.espaldas = true;

                Quaternion newRotation = Quaternion.Euler(player1.transform.eulerAngles.x, player1.transform.eulerAngles.y -180f, player1.transform.eulerAngles.z);
                player1.transform.rotation = newRotation;
                DontDestroy.guardarRotacionPlayer1 = player1.transform.rotation;
               
            }
        }
        if (CambiarPlayer.TurnoPlayer2)
        {
            CambiarPlayer.TurnoPlayer2 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                ComunPlayers.espaldas = true;
                
                
                Quaternion newRotation = Quaternion.Euler(player2.transform.eulerAngles.x, player2.transform.eulerAngles.y -180f, player2.transform.eulerAngles.z);
                player2.transform.rotation = newRotation;
                DontDestroy.guardarRotacionPlayer2 = player2.transform.rotation;
              
            }
        }
        if (CambiarPlayer.TurnoPlayer3)
        {
            CambiarPlayer.TurnoPlayer3 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                ComunPlayers.espaldas = true;
               
                Quaternion newRotation = Quaternion.Euler(player3.transform.eulerAngles.x, player3.transform.eulerAngles.y -180f, player3.transform.eulerAngles.z);
                player3.transform.rotation = newRotation;
                DontDestroy.guardarRotacionPlayer3 = player3.transform.rotation;
   
            }
        }
        if (CambiarPlayer.TurnoPlayer4)
        {
            CambiarPlayer.TurnoPlayer4 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                ComunPlayers.espaldas = true;
                
                Quaternion newRotation = Quaternion.Euler(player4.transform.eulerAngles.x, player4.transform.eulerAngles.y -180f, player4.transform.eulerAngles.z);
                player4.transform.rotation = newRotation;
                DontDestroy.guardarRotacionPlayer4 = player4.transform.rotation;

            }
        }
        
    }

    public void SiguientePlayer(){

        siguientePlayer = true;
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
