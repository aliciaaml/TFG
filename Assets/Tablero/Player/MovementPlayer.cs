using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    int casilla_destino = 16;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;

    float tolerance = 1.0f;

    public List<Transform> waypoints_todos = new List<Transform>();
    public List<Transform> waypoints_recorrer = new List<Transform>();

    int m_CurrentWaypointIndex;

    bool comienza_turno = true;
    bool Inicio = true;

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        //Debug.Log("ACTUAL: "  + colisionPlayer.actual );
        //Debug.Log("DESTINO: " + casilla_destino);

        if (comienza_turno)
        {
            waypoints_recorrer = GetWaypointsRecorrer();
            navMeshAgent.SetDestination(waypoints_recorrer[0].position);
            comienza_turno = false;
        }

        if (navMeshAgent.remainingDistance < tolerance && colisionPlayer.actual != casilla_destino)
        {
            animator.SetBool("moving", true);
            m_CurrentWaypointIndex = (m_CurrentWaypointIndex + 1) % waypoints_recorrer.Count; 
            navMeshAgent.SetDestination(waypoints_recorrer[m_CurrentWaypointIndex].position);
            //RotateTowards(waypoints_recorrer[m_CurrentWaypointIndex].position);
        }   
        if(colisionPlayer.actual == casilla_destino)
        {

            Inicio = false;
            comienza_turno = false;
            animator.SetBool("moving", false);
        }
    }

    List<Transform> GetWaypointsRecorrer()
    {
        List<Transform> recorrer = new List<Transform>();

        if (casilla_destino >= 0 && casilla_destino < waypoints_todos.Count)
        {
            if(Inicio){

                for (int i = 0; i < casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                }
            }
            else{

                for (int i = colisionPlayer.actual-1; i < casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                }

            }

        }

        return recorrer;
    }
    /*
    void RotateTowards(Vector3 targetPosition){
        Vector3 direction = targetPosition - transform.position;
        direction.y = 0;
        if(direction!=Vector3.zero){

            Quaternion toRotation = Quaternion.LookRotation(direction);
            transform.rotation = Quaternion.RotateTowards(transform.rotation,toRotation,navMeshAgent.angularSpeed * Time.deltaTime);
        }
    }
    */
}
