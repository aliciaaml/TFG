using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer2 : MonoBehaviour
{
    

    //int casilla_destino = 4; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent2;
    private Animator animator2;


    int m_CurrentWaypointIndex2;

    public ComunPlayers comunPlayers;



    void Start()
    {
        navMeshAgent2 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator2 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer2){

            if (ComunPlayers.comienza_turno)
            {
                ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                navMeshAgent2.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                ComunPlayers.comienza_turno = false;
            }

            if (navMeshAgent2.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino)
            {
                animator2.SetBool("moving", true);
                m_CurrentWaypointIndex2 = (m_CurrentWaypointIndex2 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                navMeshAgent2.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex2].position);

            }   
            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index<3)
            {

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator2.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                ComunPlayers.index+=1;

    
            }

            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator2.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                
                ComunPlayers.index = 0;
            }
        }

    }
        


}
