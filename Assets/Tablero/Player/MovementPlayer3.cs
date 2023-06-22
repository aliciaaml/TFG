using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementPlayer3 : MonoBehaviour
{
    

    //int casilla_destino = 5; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent3;
    private Animator animator3;


    int m_CurrentWaypointIndex3;

    public ComunPlayers comunPlayers;
    public GameObject Dado1;
    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;


    void Start()
    {
        navMeshAgent3 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator3 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer3  ){
            
            if(ElegirPosiciones.turno_terminado == false){

                if(EscogerPersonaje.character_choosed[2] == 0  && MovementPlayer1.una_vez){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<Trough_dice>().IADown();
                    ElegirPosiciones.colliderDado= false;

                    turno_jugador.text = "Cheese";
                    turno_jugador_b.text = "Cheese";

                    Nombre_Player.SetActive(true);
                    
                }
                if(EscogerPersonaje.character_choosed[2] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado=true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                }

            }
            

            else{
                
                Dado1.SetActive(false);

                if (ComunPlayers.comienza_turno)
                {
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent3.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    ComunPlayers.comienza_turno = false;
                }

                if (navMeshAgent3.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino)
                {
                    animator3.SetBool("moving", true);
                    m_CurrentWaypointIndex3 = (m_CurrentWaypointIndex3 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent3.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex3].position);

                }
                if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index<3)
                {
                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator3.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    ComunPlayers.index+=1;
                    ComunPlayers.casilla_destino = 0;
                    MovementPlayer1.una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;

        
                }

                if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator3.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    
                    ComunPlayers.index = 0;
                    ComunPlayers.casilla_destino = 0;
                    MovementPlayer1.una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;
                }   

            }
            
        }

    }
        


}
