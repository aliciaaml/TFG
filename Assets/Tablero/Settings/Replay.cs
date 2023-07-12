using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Replay : MonoBehaviour
{
    public GameObject dialogo;
    public GameObject CanvasInicio;
    public static bool replay = false;

    public Slider sliderVolum1;
    public Slider sliderVolum2;

    public void OnReplayButtonClicked()
    {    
        sliderVolum1.value = sliderVolum2.value;   
        ComunPlayers.PosicionActualPlayers = new List<List<ComunPlayers.ElementoLista>>();
        ComunPlayers.tolerance = 0.5f;
        ComunPlayers.waypoints_recorrer = new List<Transform>();
        ComunPlayers.IA = false;
        ComunPlayers.PERSONA = false;
        ComunPlayers.OrdenInicioPlayers = new List<string>();
        ComunPlayers.comienza_turno = true;
        ComunPlayers.Inicio = true;
        ComunPlayers.siguiente = false;
        ComunPlayers.index = 0;
        ComunPlayers.primeraRonda = false;
        ComunPlayers.dic_lleno = false;
        ComunPlayers.casilla_destino = 0;
        ComunPlayers.casilla_antes_tirar = 0;
        ComunPlayers.waypoint_final = "";
        ComunPlayers.waypoint_actual= "";
        ComunPlayers.i = 0 ;
        ComunPlayers.pierdeTurnoplayer1 = false;
        ComunPlayers.pierdeTurnoplayer2 = false;
        ComunPlayers.pierdeTurnoplayer3 = false;
        ComunPlayers.pierdeTurnoplayer4 = false;
        ComunPlayers.una_por_turno = true;


        MovementPlayer1.una_vez = true;
        MovementPlayer1.detectar_casilla = false;
        MovementPlayer1.gira_una1 = true;
        MovementPlayer1.aux_LW  = 0f;
        MovementPlayer1.wait_LW = true;
        MovementPlayer1.aux_siguiente = 0f;
        MovementPlayer1.wait_siguiente = true;
        MovementPlayer1.wait_pasar = true;
        MovementPlayer1.aux_pasar = 0f;

        MovementPlayer2.gira_una2= true;
        MovementPlayer2.aux_LW  = 0f;
        MovementPlayer2.wait_LW = true;
        MovementPlayer2.aux_siguiente = 0f;
        MovementPlayer2.wait_siguiente = true;
        MovementPlayer2.wait_pasar = true;
        MovementPlayer2.aux_pasar = 0f;

        MovementPlayer3.aux_LW  = 0f;
        MovementPlayer3.wait_LW = true;
        MovementPlayer3.aux_siguiente = 0f;
        MovementPlayer3.wait_siguiente = true;
        MovementPlayer3.wait_pasar = true;
        MovementPlayer3.aux_pasar = 0f;
        MovementPlayer3.gira_una3 = true;

        MovementPlayer4.aux_LW  = 0f;
        MovementPlayer4.wait_LW = true;
        MovementPlayer4.aux_siguiente = 0f;
        MovementPlayer4.wait_siguiente = true;
        MovementPlayer4.wait_pasar = true;
        MovementPlayer4.aux_pasar = 0f;
        MovementPlayer4.gira_una4 = true;

        ElegirPosiciones.numeroDado = new List<List<int>>();
        ElegirPosiciones.turno_terminado = false;
        ElegirPosiciones.terminadoCactus = false;
        ElegirPosiciones.aux_v = 0f;
        ElegirPosiciones.wait_v = true;
        ElegirPosiciones.aux_j = 0f;
        ElegirPosiciones.wait_j = true;
        ElegirPosiciones.f = 0;
        ElegirPosiciones.aux_f = 0;
        ElegirPosiciones.unica = true;
        ElegirPosiciones.agregar = false;
        ElegirPosiciones.ElegirTurnoTerminado = false;
        ElegirPosiciones.solo_una = true;

        TroughDice.dados_tirados = false;
        TroughDice.num = 1;
        TroughDice.mouse = false;
        TroughDice.aux = 0;
        TroughDice.wait_t = true;

        NumDado.wait_t = true;
        NumDado.wait_t2 = true;
        NumDado.num_sacado = false;
        NumDado.aux = 0f;
        NumDado.aux2 = 0f;
        NumDado.dado_final = false;
        NumDado.resultado_dado_obtenido = false;
        NumDado.ListaNumDado = false;

        CambiarPlayer.TurnoPlayer1 = false;
        CambiarPlayer.TurnoPlayer2 = false;
        CambiarPlayer.TurnoPlayer3 = false;
        CambiarPlayer.TurnoPlayer4 = false;
        CambiarPlayer.uno = true;

        colisionPlayer.actual = 0;
        colisionPlayer.contadorDado = 0;

        DialogControler.i = 0;
        DialogControler.dialog_terminado = false;

        EscogerJugador.one_player = false;
        EscogerJugador.two_player = false;
        EscogerJugador.three_player = false;
        EscogerJugador.four_player = false;

        EscogerPersonaje.contador = 1;
        EscogerPersonaje.selectedCharacter = 0;
        EscogerPersonaje.character_choosed = new List<int>(new int[4]);
        EscogerPersonaje.juegoComenzar = false;

        DontDestroy.una = true;
        DontDestroy.guardarPosPlayer1 = LoadCharacter.posInitPlayer1;
        DontDestroy.guardarPosPlayer2 = LoadCharacter.posInitPlayer2;
        DontDestroy.guardarPosPlayer3 = LoadCharacter.posInitPlayer3;
        DontDestroy.guardarPosPlayer4 = LoadCharacter.posInitPlayer4;

        LoadTablero.minijuego = false;
        LoadTablero.salirMinijuego = false;

        LoadCharacter.una_al_salirMinijuego = false;
        BotonSiguiente.siguientePlayer = false;
        ColliderEnable.collider_casilla = false;
        Rota90.una = true;
        DialogControler.i = 0;
        DialogControler.dialog_terminado = false;

        replay = true;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        
        
    }
}
