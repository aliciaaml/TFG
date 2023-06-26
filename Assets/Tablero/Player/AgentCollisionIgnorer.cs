using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AgentCollisionIgnorer : MonoBehaviour
{
    public LayerMask agentLayer; // Capa de colisión de los agentes

    private void Start()
    {
        
    }

    void Update (){

        // Obtén todos los componentes NavMeshAgent de los agentes en la capa especificada
        UnityEngine.AI.NavMeshAgent[] agents = FindObjectsOfType<UnityEngine.AI.NavMeshAgent>();
        foreach (UnityEngine.AI.NavMeshAgent agent in agents)
        {
            Debug.Log("agent.layer: " + agent.gameObject.layer);
            Debug.Log("Layer: " + agentLayer);
            // Ignora la colisión entre agentes estableciendo su capa de colisión a la capa "Ignore Raycast"
            if (agent.gameObject.layer == 3)
            {
                Debug.Log("Ignorandooo");
                agent.gameObject.layer = LayerMask.NameToLayer("Ignore Raycast");
            }
        }
    }
}
