using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Click_cana0 : MonoBehaviour
{
    private Animator animator;
    public static int contador = 0;

    public static float aux_pesca = 0f;
    public static bool wait_pesca = true;

    public static float aux_pesca2 = 0f;
    public static bool wait_pesca2 = true;

    bool gana = false;
    bool pierde = false;

    bool mouse_fuera = true;

    public GameObject win;
    public GameObject lose;
    public GameObject canas;
    public GameObject explicacion;
    public GameObject explicacion2;

    void Start(){

        animator = GetComponent<Animator>();
    }
    
    void Update (){

        if(gana){

            Wait_pesca();

            if(wait_pesca == false){
                Debug.Log("YOU WIN !!!");
                explicacion.SetActive(false);
                explicacion2.SetActive(false);
                canas.SetActive(false);
                win.SetActive(true);

                
            }
        }
        else if(pierde){

            Wait_pesca();

            if(wait_pesca == false){
                
                Debug.Log("YOU LOST");
                canas.SetActive(false);
                lose.SetActive(true);
                explicacion.SetActive(false);
                explicacion2.SetActive(false);
                
            }
            
        }

        if(mouse_fuera){

            Wait_pesca2();

            if(wait_pesca2 == false){

                animator.SetBool("pez",false);
                animator.SetBool("no_pez",false);
                wait_pesca2 = true;
                aux_pesca2 = 0f;
            }

        }
    }

    void OnMouseDown()
    {
        mouse_fuera = false;
        if(Elegir_quien_pez.range == 0){

            animator.SetBool("pez",true);

            gana = true;
            
        }
        else if(contador<2){

            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);
            contador+=1;
        }
        else{

            pierde = true;
            animator.SetBool("pez",false);
            animator.SetBool("no_pez",true);
            
        }
    }

    void OnMouseUp()
    {
        mouse_fuera = true;
        
    }


    public static void Wait_pesca(){

        aux_pesca += 1*Time.deltaTime;

        if(aux_pesca >= 2f) wait_pesca = false;
        
    }

    public static void Wait_pesca2(){
        
        aux_pesca2 += 1*Time.deltaTime;

        if(aux_pesca2 >= 0.4f) wait_pesca2 = false;
        
    }
}
