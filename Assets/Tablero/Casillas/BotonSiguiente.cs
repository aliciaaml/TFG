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
        player1.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer1;
        player2.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer2;
        player3.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer3;
        player4.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer4;
        /*
        if (CambiarPlayer.TurnoPlayer1)
        {
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                CambiarPlayer.TurnoPlayer1 = false;
                Debug.Log("1");
                player1.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer1;


                ComunPlayers.espaldas = true;
            }
        }
        if (CambiarPlayer.TurnoPlayer2)
        {

            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                CambiarPlayer.TurnoPlayer2 = false;
                Debug.Log("2");
                player2.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer2;
                ComunPlayers.espaldas = true;
            }
        }
        if (CambiarPlayer.TurnoPlayer3)
        {
            CambiarPlayer.TurnoPlayer3 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                Debug.Log("3");
                player3.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer3;
                ComunPlayers.espaldas = true;
            }
        }
        if (CambiarPlayer.TurnoPlayer4)
        {
            CambiarPlayer.TurnoPlayer4 = false;
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                Debug.Log("4");
                player4.transform.rotation = ComunPlayers.guardarRotacionAlanteplayer4;
                ComunPlayers.espaldas = true;
            }
        }
        */
    }

    public void SiguientePlayer(){

        siguientePlayer = true;

        //ROTAR DE NUEVO JUGADOR
        /*
        if(CambiarPlayer.TurnoPlayer1 && ComunPlayers.pierdeTurnoplayer1 == false){
  
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {
                Debug.Log("entra1");
                player1.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            DontDestroy.guardarRotacionPlayer1 = player1.transform.rotation;
            CambiarPlayer.TurnoPlayer1 = false;
        }
        if(CambiarPlayer.TurnoPlayer2 && ComunPlayers.pierdeTurnoplayer2 == false){
            if (ComunPlayers.espaldas == false) //Si está mirando a camara
            {   Debug.Log("entra2");
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
                Debug.Log("entra3");
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
                Debug.Log("entra4");
                player4.transform.Rotate(Vector3.up, -180f);
                ComunPlayers.espaldas = true;
            }
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
            DontDestroy.guardarRotacionPlayer4 = player4.transform.rotation;
            CambiarPlayer.TurnoPlayer4 = false;
        }
        */
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
