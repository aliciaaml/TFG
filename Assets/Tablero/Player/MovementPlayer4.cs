using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer4 : MonoBehaviour
{
    

    //int casilla_destino = 6; //HAY QUE CAMBIARLA POR EL VALOR DEL DADO
    private UnityEngine.AI.NavMeshAgent navMeshAgent4;
    private Animator animator4;


    int m_CurrentWaypointIndex4;

    public ComunPlayers comunPlayers;

    void Start()
    {
        navMeshAgent4 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator4 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer4){

            if (ComunPlayers.comienza_turno)
            {
                ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                ComunPlayers.comienza_turno = false;
            }

            if (navMeshAgent4.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino)
            {
                animator4.SetBool("moving", true);
                m_CurrentWaypointIndex4 = (m_CurrentWaypointIndex4 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex4].position);

            }   
            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index<3)
            {

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator4.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                ComunPlayers.index+=1;

    
            }

            if(colisionPlayer.actual == ComunPlayers.casilla_destino && ComunPlayers.index ==3){

                ComunPlayers.Inicio = false;
                ComunPlayers.comienza_turno = false;
                animator4.SetBool("moving", false);
                ComunPlayers.siguiente = true;
                
                ComunPlayers.index = 0;
            }
        }

    }
        


}
