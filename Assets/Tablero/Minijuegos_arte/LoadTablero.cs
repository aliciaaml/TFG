using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadTablero : MonoBehaviour
{
    public static bool minijuego = false;
    public static bool salirMinijuego = false;

    public void Back(){

        salirMinijuego = true;
        LoadCharacter.una_al_salirMinijuego = false;
        minijuego = true;
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
            /*
            ComunPlayers.contadorTurnos+=1;

            if(ComunPlayers.contadorTurnos >=2){
                ComunPlayers.contadorTurnos = 0;
                
                ComunPlayers.pierdeTurnoplayer1 = false;
                ComunPlayers.pierdeTurnoplayer2 = false;
                ComunPlayers.pierdeTurnoplayer3 = false;
                ComunPlayers.pierdeTurnoplayer4 = false;
            }
            */
        }
        SceneManager.LoadScene("Terreno");
    
    }

    
}
