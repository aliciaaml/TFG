using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class PlayerNavmesh : MonoBehaviour
{
    [SerializeField] private Transform movePositionTransform;
    private NavMeshAgent navMeshAgent;

    private Animator animator;

    public float speed;


    void Start()
    {
        animator = GetComponent<Animator>();
    }
    private void Awake()
    {
        navMeshAgent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        navMeshAgent.destination = movePositionTransform.position;

        //Rotacion personaje
        Vector3 movementDirection = navMeshAgent.velocity.normalized;


        if(navMeshAgent.destination == movePositionTransform.position)
        {
            animator.SetBool("moving", false);
        }

        else if( movementDirection.magnitude>0)
        {
           

            Debug.Log("entrandooo");
            animator.SetBool("moving", true);

            transform.forward = movementDirection;

        }


    }
}
