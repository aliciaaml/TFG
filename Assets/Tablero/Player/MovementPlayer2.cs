using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementPlayer2 : MonoBehaviour
{
    

    //int casilla_destino = 4; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent2;
    private Animator animator2;


    int m_CurrentWaypointIndex2;

    public ComunPlayers comunPlayers;

    public GameObject Dado1;

    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;

    public GameObject textoDado;


    void Start()
    {
        navMeshAgent2 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator2 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer2 ){

            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);

                if(EscogerPersonaje.character_choosed[1] == 0  && MovementPlayer1.una_vez && !EscogerJugador.four_player){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<Trough_dice>().IADown();
                    ElegirPosiciones.colliderDado=false;

                    turno_jugador.text = "Frog";
                    turno_jugador_b.text = "Frog";

                    Nombre_Player.SetActive(true);
                    MovementPlayer1.detectar_casilla = false;
                    
                }
                if(EscogerPersonaje.character_choosed[1] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado=true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[1].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[1].ToString();
                    MovementPlayer1.detectar_casilla = false;
                }
                if(EscogerJugador.four_player){
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player 2";
                    turno_jugador_b.text = "Player 2";
                    MovementPlayer1.detectar_casilla = false;
                }

            }
            

            else{
                
                Dado1.SetActive(false);
                Debug.Log("verdad o no: " + (navMeshAgent2.remainingDistance < ComunPlayers.tolerance));
                Debug.Log("blabla: " + (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar));
                if (ComunPlayers.comienza_turno)
                {
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent2.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    Debug.Log("ESTA ENTRANDO: " + ComunPlayers.waypoints_recorrer[0]);
                    ComunPlayers.comienza_turno = false;

                    navMeshAgent2.speed = 25f;
                    navMeshAgent2.angularSpeed = 120f;
                    navMeshAgent2.acceleration = 8f;

                    gameObject.layer = LayerMask.NameToLayer("Players");
                }

                if (navMeshAgent2.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {
                    Debug.Log("ESTA ENTRANDO2");
                    animator2.SetBool("moving", true);
                    m_CurrentWaypointIndex2 = (m_CurrentWaypointIndex2 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent2.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex2].position);

                    


                }
                if(colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && ComunPlayers.index<3 && MovementPlayer1.detectar_casilla == false)
                {
                    ComunPlayers.ActualizarPosicionPlayer();
                    Debug.Log("ESTA ENTRANDO3");
                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator2.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    ComunPlayers.index+=1;
                    ComunPlayers.casilla_destino = 0;
                    MovementPlayer1.una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;
                    MovementPlayer1.detectar_casilla = true;
                    ElegirPosiciones.turno_terminado = false;

                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    navMeshAgent2.speed = 0f;
                    navMeshAgent2.angularSpeed = 0f;
                    navMeshAgent2.acceleration = 0f;

        
                }

                if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3 && MovementPlayer1.detectar_casilla == false){

                    ComunPlayers.ActualizarPosicionPlayer();

                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator2.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    
                    ComunPlayers.index = 0;
                    ComunPlayers.casilla_destino = 0;
                    MovementPlayer1.una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;
                    MovementPlayer1.detectar_casilla = true;
                    ElegirPosiciones.turno_terminado = false;

                    gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
                    navMeshAgent2.speed = 0f;
                    navMeshAgent2.angularSpeed = 0f;
                    navMeshAgent2.acceleration = 0f;
                }

            }
            
        }

    }


}
