using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoAleatorioCana : MonoBehaviour
{
    public static float currentTime = 0f;
    public static float startingTime = 0f;
    public static float aux =0f; 
    public static bool wait = true;

    private Animator animator;

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
