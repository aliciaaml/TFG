using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movimiento_aleatorio_cana : MonoBehaviour
{
    float currentTime = 0f;
    float startingTime = 0f;
    float aux =0f;
    private Animator animator;
    bool wait = true;

    // Start is called before the first frame update
    void Start()
    {   animator = GetComponent<Animator>();
        startingTime = Random.Range(1f,5f);
        currentTime = startingTime;
    }

    // Update is called once per frame
    void Update()
    {
        currentTime -= 1 * Time.deltaTime;
        if(currentTime <= 0){
            animator.SetBool("mover",true);
            Wait();
            if(wait == false){
                animator.SetBool("mover",false);
                startingTime = Random.Range(1f,5f);
                currentTime = startingTime;
                wait = true;
                aux = 0f;
            }
        }   
    }

    void Wait(){
        aux += 1*Time.deltaTime;
        if(aux >= 0.5f) wait = false;
    }   
}
