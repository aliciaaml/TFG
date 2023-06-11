using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavmesh : MonoBehaviour
{
    int casilla_destino = 5; //EL NÚMERO SERÁ EL QUE SALGA EN LOS DADOS
    private NavMeshAgent navMeshAgent;

    private Animator animator;

    float distanceToDestination;

    float tolerance;

    public Transform[] waypoints_todos;

    Transform[] waypoints_recorrer;

    int m_CurrentWaypointIndex;

    bool comienza_turno = true;
    bool Inicio = true;

    int  i=0;
    int aux = 0;
    int actual;

    void Start()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();

        animator = GetComponent<Animator>();

        

    }


    private void Update()
    {

        if ( comienza_turno){

            i = 0;
            aux = 0;
            Transform[] waypoints_recorrer = new Transform[casilla_destino];

            if (Inicio){

                while(i<waypoints_recorrer.Length){
            
                    if(i ==0){

                        waypoints_recorrer[i] = waypoints_todos[aux];
                    }
                    else{

                        waypoints_recorrer[i] = waypoints_todos[aux+ 1];
                    }
            
                    i++;
                    
                }
                
            }
            else{
                
                for(int j = 0; j<waypoints_todos.Length; j++){

                    if(waypoints_todos[j] == colisionPlayer.casilla_actual){

                        actual = j;
                    }

                }
                while(i<waypoints_recorrer.Length){
            
                    if(i ==0){

                        waypoints_recorrer[i] = waypoints_todos[actual];
                    }
                    else{

                        waypoints_recorrer[i] = waypoints_todos[actual+ 1];
                    }
            
                    i++;
            
                }
            }
            
            
            navMeshAgent.SetDestination (waypoints_recorrer[0].position);
            comienza_turno = false;
        }
           

        if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
        {
            animator.SetBool("moving", true);
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints_recorrer.Length;
            navMeshAgent.SetDestination (waypoints_recorrer[m_CurrentWaypointIndex].position);
        }
        else{

            Inicio = false;
            comienza_turno = false;
            animator.SetBool("moving", false);
        }

        /*
        if(INICIO){

            navMeshAgent.SetDestination (waypoints[0].position);
            if(navMeshAgent.remainingDistance < navMeshAgent.stoppingDistance)
            {
                if(colisionPlayer.casilla_actual != movePositionTransform ){   // Entre paretesis  poner la CASILLA A LA QUE TIENE QUE IR EL PERSONAJE
                    m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints.Length;
                    navMeshAgent.SetDestination (waypoints[m_CurrentWaypointIndex].position); 
                }
                else{

                    
                    llegado = true;
                }
                
            }
        
        }
        //navMeshAgent.destination = movePositionTransform.position;


        ////////// MIRA DISTANCIA  A LA QUE DEJAR DE CAMINAR////////////////////////

        if(llegado){

            distanceToDestination = Vector3.Distance(transform.position, navMeshAgent.destination);
            tolerance = 0.1f; // Tolerancia para considerar que el personaje ha llegado

            if (distanceToDestination <= tolerance)
            {

                animator.SetBool("moving", false);
                llegado = false;
            }

            else
            {
                animator.SetBool("moving", true);

            }

        }

    */

    }
}
