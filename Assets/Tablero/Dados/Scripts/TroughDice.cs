using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TroughDice : MonoBehaviour
{
    public Animator animator;
    public static bool dados_tirados = false;
    public static int num = 1;
    public static bool mouse = false;
    public static float aux = 0;
    public static bool wait_t = true;

    void Start(){
        animator = transform.parent.GetComponent<Animator>();
    }
    void Update (){
        if(ElegirPosiciones.turno_terminado){
            animator.SetBool("lanzado",false);
            mouse = false;
            dados_tirados = false;
            animator.SetBool("repetir",false);
        }
    }

    public void OnMouseDown(){
        if(ElegirPosiciones.colliderDado){
            mouse = true;
            animator.SetBool("lanzado",true);
            dados_tirados = true;
            animator.SetBool("repetir",false);
        }
    }
    public void IADown(){
        Wait();
        if(wait_t == false){
            ElegirPosiciones.unica = false;
            MovementPlayer1.una_vez = false;
            wait_t = true;
            aux = 0;
            animator.SetBool("lanzado",true);
            dados_tirados = true;
            animator.SetBool("repetir",false);
        }
    }
    public static void Wait(){
        aux += 1*Time.deltaTime;
        if(aux >= 2f) wait_t = false;
    }
}