using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_cana0 : MonoBehaviour
{

    private Animator animator;


    void Start(){

        animator = GetComponent<Animator>();
    }


    void OnMouseDown()
    {
        if(Elegir_quien_pez.range == 0){

            animator.SetBool("pez",true);

            Debug.Log("YOU WIN !!!");
        }
        else{

            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);

        }



    }

    void OnMouseUp()
    {
        animator.SetBool("pez",false);
        animator.SetBool("no_pez",false);
    }


}
