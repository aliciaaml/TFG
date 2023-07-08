using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickCana3 : MonoBehaviour
{

    private Animator animator;

    public static bool mouse_fuera = true;
    public static bool gana = false;
    public static bool pierde = false;

    public GameObject win;
    public GameObject lose;
    public GameObject canas;
    public GameObject tries;

    void Start(){

        animator = GetComponent<Animator>();
    }

    void Update (){

        if(gana){

            ClickCana0.Wait_pesca();

            if(ClickCana0.wait_pesca == false){
                Debug.Log("YOU WIN !!!");
                tries.SetActive(false);
                canas.SetActive(false);
                win.SetActive(true);
                
            }
        }
        else if(pierde){

            ClickCana0.Wait_pesca();

            if(ClickCana0.wait_pesca == false){
                
                Debug.Log("YOU LOST");
                tries.SetActive(false);
                canas.SetActive(false);
                lose.SetActive(true);
                
            }
            
        }

        if(mouse_fuera){

            ClickCana0.Wait_pesca2();

            if(ClickCana0.wait_pesca2 == false){

                animator.SetBool("pez",false);
                animator.SetBool("no_pez",false);
                ClickCana0.wait_pesca2 = true;
                ClickCana0.aux_pesca2 = 0f;
            }

        }

    }


    void OnMouseDown()
    {
        mouse_fuera = false;
        if(ElegirQuienPez.range == 3){

            animator.SetBool("pez",true);
            gana = true;
            
        }
        else if(ClickCana0.contador>1){

            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);
            ClickCana0.contador-=1;
        }
        else{

            ClickCana0.contador = 0;
            pierde = true;
            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);

            
        }



    }

    void OnMouseUp()
    {
        mouse_fuera = true;
    }


}
