using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;
using UnityEngine.SceneManagement;


public class MovementPlayer4 : MonoBehaviour
{
    

    //int casilla_destino = 6; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent4;
    private Animator animator4;


    int m_CurrentWaypointIndex4;

    public ComunPlayers comunPlayers;

    public GameObject Dado1;

    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;

    public GameObject textoDado;

    public GameObject LetreroMinijuego;
    public GameObject botonMinijuego;
    public GameObject LetreroNoMinijuego;
    public GameObject botonPlayerSig;
    public TextMeshProUGUI nombreMinijuego;
    public TextMeshProUGUI nombreMinijuego2;

    void Start()
    {
        navMeshAgent4 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator4 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer4  ){

            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);

                if(EscogerPersonaje.character_choosed[3] == 0  && MovementPlayer1.una_vez && !EscogerJugador.four_player){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<Trough_dice>().IADown();
                    ElegirPosiciones.colliderDado = false;

                    turno_jugador.text = "Cactus";
                    turno_jugador_b.text = "Cactus";

                    Nombre_Player.SetActive(true);
                    MovementPlayer1.detectar_casilla = false;
                    
                }
                if(EscogerPersonaje.character_choosed[3] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado = true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                    MovementPlayer1.detectar_casilla = false;
                }
                if(EscogerJugador.four_player){
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player 4";
                    turno_jugador_b.text = "Player 4";
                    MovementPlayer1.detectar_casilla = false;
                }

            }
            

            else{
                Dado1.SetActive(false);
                Debug.Log("verdad o no: " + (navMeshAgent4.remainingDistance < ComunPlayers.tolerance));
                Debug.Log("blabla: " + (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar));
                

                if (ComunPlayers.comienza_turno )
                {
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    Debug.Log("ESTA ENTRANDO: " + ComunPlayers.waypoints_recorrer[0]);
                    ComunPlayers.comienza_turno = false;

                    navMeshAgent4.speed = 25f;
                    navMeshAgent4.angularSpeed = 120f;
                    navMeshAgent4.acceleration = 8f;
                }

                if (navMeshAgent4.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {
                    Debug.Log("ESTA ENTRANDO2");
                    animator4.SetBool("moving", true);
                    m_CurrentWaypointIndex4 = (m_CurrentWaypointIndex4 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex4].position);
                    


                } 
                if(colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && MovementPlayer1.detectar_casilla == false)
                {
                    textoDado.SetActive(false);
                    animator4.SetBool("moving", false);
                    navMeshAgent4.speed = 0f;
                    navMeshAgent4.angularSpeed = 0f;
                    navMeshAgent4.acceleration = 0f;

                    if(CasillaMinCoco.casilla_minijuego == ""){
                        
                        LetreroNoMinijuego.SetActive(true);
                        botonPlayerSig.SetActive(true);

                    }
                    else{

                        if(CasillaMinCoco.casilla_minijuego == "juego_pesca"){

                            nombreMinijuego.text = "Fishing minigame" ;
                            nombreMinijuego2.text = "Fishing minigame" ;
                        }
                        if(CasillaMinCoco.casilla_minijuego == "juego_cocos"){

                            nombreMinijuego.text = "Coconuts minigame";
                            nombreMinijuego2.text = "Coconuts minigame";
                        }
                        if(CasillaMinCoco.casilla_minijuego == "juego_tiburones"){
                            nombreMinijuego.text = "Sharks minigame";
                            nombreMinijuego2.text = "Sharks minigame";
                            
                        }

                        LetreroMinijuego.SetActive(true);
                        botonMinijuego.SetActive(true);

                    }
                    
                    
                }

            }

              
            
        }

    }


}
