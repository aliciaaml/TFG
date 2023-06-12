using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer3 : MonoBehaviour
{
    

    //int casilla_destino = 5; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent3;
    private Animator animator3;


    int m_CurrentWaypointIndex3;

    public ComunPlayers comunPlayers;


    void Start()
    {
        navMeshAgent3 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator3 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer3){

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

    
            }

            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator3.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                
                ComunPlayers.index = 0;
            }
        }

    }
        


}
