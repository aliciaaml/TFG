using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NavMeshController : MonoBehaviour
{

    private GameObject casilla;
    private NavMeshAgent agente;
    
    // Start is called before the first frame update
    void Start()
    {
        agente = GetComponent<NavMeshAgent>();
        
    }

    // Update is called once per frame
    void Update()
    {
        

        if(Player.player_avanza){

            //Debug.Log(casilla);

            casilla = GameObject.FindWithTag(Player.objetivo.ToString());

            agente.destination = casilla.transform.position;



        }

            
    }
}
