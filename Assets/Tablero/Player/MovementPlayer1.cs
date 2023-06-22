using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class MovementPlayer1 : MonoBehaviour
{
    

    //int casilla_destino = 3; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent1;
    private Animator animator1;


    int m_CurrentWaypointIndex1;

    public ComunPlayers comunPlayers;

    public GameObject Dado1;

    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;
    
    public static bool una_vez = true;


    void Start()
    {
        navMeshAgent1 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator1 = GetComponent<Animator>();

        
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer1){

            if(ElegirPosiciones.turno_terminado == false){

                if(EscogerPersonaje.character_choosed[0] == 0  && una_vez){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<Trough_dice>().IADown();
                    ElegirPosiciones.colliderDado = false;

                    turno_jugador.text = "Mushroom";
                    turno_jugador_b.text = "Mushroom";

                    Nombre_Player.SetActive(true);
                    
                }
                if(EscogerPersonaje.character_choosed[0] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                }

            }
            

            else{
                
                Dado1.SetActive(false);
                
                if (ComunPlayers.comienza_turno )
                {
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent1.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    ComunPlayers.comienza_turno = false;
                }


                if (navMeshAgent1.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino)
                {
                    animator1.SetBool("moving", true);
                    m_CurrentWaypointIndex1 = (m_CurrentWaypointIndex1 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent1.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex1].position);

                } 

                if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index<3)
                {

                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator1.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    ComunPlayers.index+=1;
                    ComunPlayers.casilla_destino = 0;
                    una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;

        
                }
                if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                    ComunPlayers.Inicio = false;
                    ComunPlayers.comienza_turno = false;
                    animator1.SetBool("moving", false);
                    ComunPlayers.siguiente = true;
                    
                    ComunPlayers.index = 0;
                    ComunPlayers.casilla_destino = 0;
                    una_vez = true;
                    Num_dado.resultado_dado_obtenido = false;
                }
                
            }
              
            
        }

    }
        


}
