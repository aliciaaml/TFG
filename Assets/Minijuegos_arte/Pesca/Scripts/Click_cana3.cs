using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_cana3 : MonoBehaviour
{

    private Animator animator;

    bool mouse_fuera = true;
    bool gana = false;
    bool pierde = false;

    public GameObject win;
    public GameObject lose;
    public GameObject canas;
    public GameObject tries;

    void Start(){

        animator = GetComponent<Animator>();
    }

    void Update (){

        if(gana){

            Click_cana0.Wait_pesca();

            if(Click_cana0.wait_pesca == false){
                Debug.Log("YOU WIN !!!");
                tries.SetActive(false);
                canas.SetActive(false);
                win.SetActive(true);
                
            }
        }
        else if(pierde){

            Click_cana0.Wait_pesca();

            if(Click_cana0.wait_pesca == false){
                
                Debug.Log("YOU LOST");
                tries.SetActive(false);
                canas.SetActive(false);
                lose.SetActive(true);
                
            }
            
        }

        if(mouse_fuera){

            Click_cana0.Wait_pesca2();

            if(Click_cana0.wait_pesca2 == false){

                animator.SetBool("pez",false);
                animator.SetBool("no_pez",false);
                Click_cana0.wait_pesca2 = true;
                Click_cana0.aux_pesca2 = 0f;
            }

        }

    }


    void OnMouseDown()
    {
        mouse_fuera = false;
        if(Elegir_quien_pez.range == 3){

            animator.SetBool("pez",true);
            gana = true;
            
        }
        else if(Click_cana0.contador>1){

            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);
            Click_cana0.contador-=1;
        }
        else{

            Click_cana0.contador = 0;
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
