using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer1 : MonoBehaviour
{
    

    //int casilla_destino = 3; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent1;
    private Animator animator1;


    int m_CurrentWaypointIndex1;

    public ComunPlayers comunPlayers;


    void Start()
    {
        navMeshAgent1 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator1 = GetComponent<Animator>();

        
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer1){

            if (ComunPlayers.comienza_turno)
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

    
            }
            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator1.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                
                ComunPlayers.index = 0;
            }
        }

    }
        


}
