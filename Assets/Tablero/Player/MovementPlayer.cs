using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementPlayer : MonoBehaviour
{
    public static Dictionary<string, int> PosicionActualPlayers= new Dictionary<string,int>();

    int casilla_destino = 3;
    private UnityEngine.AI.NavMeshAgent navMeshAgent;
    private Animator animator;

    float tolerance = 1.0f;

    public List<Transform> waypoints_todos = new List<Transform>();
    public List<Transform> waypoints_recorrer = new List<Transform>();

    int m_CurrentWaypointIndex;

    public static bool comienza_turno = true;
    public static bool Inicio = true;
    public static bool siguiente = false;

    public static int index = 0;

    bool primeraRonda = true;

    public static List<string> OrdenInicioPlayers = new List<string>(){

        "player1","player2","player3","player4"
    };

    void Start()
    {
        navMeshAgent = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {

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

        }   
        if(colisionPlayer.actual == casilla_destino)
        {

            Inicio = false;
            comienza_turno = false;
            animator.SetBool("moving", false);
            siguiente = true;
            index+=1;

            if(primeraRonda){

                PosicionActualPlayers.Add(OrdenInicioPlayers[0], colisionPlayer.actual);
                for(int i = 1; i<OrdenInicioPlayers.Count; i++ ){

                    colisionPlayer.actual = 0;
                    PosicionActualPlayers.Add(OrdenInicioPlayers[i], colisionPlayer.actual);
                }
                primeraRonda = false;
            }
  
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

}
