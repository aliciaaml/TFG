using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trough_dice : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    public Animator animator;
    public Animator animator2;
    public static bool dados_tirados = false;
    public static int num = 1;

    public static bool mouse = false;

    public static float aux = 0;
    public static bool wait_t = true;

    void Update (){

        if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado ||  gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces ){

            animator = transform.parent.GetComponent<Animator>();
        }

        if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado){

            animator = transform.parent.parent.GetComponent<Animator>();
            animator2 = transform.parent.GetComponent<Animator>();

        }


        if(ElegirPosiciones.turno_terminado){
            animator.SetBool("lanzado",false);

            mouse = false;
            dados_tirados = false;

            animator.SetBool("repetir",false);
        }

    }


    public void OnMouseDown()
    {
        if(ElegirPosiciones.colliderDado){

            mouse = true;
            animator.SetBool("lanzado",true);
            dados_tirados = true;

            animator.SetBool("repetir",false);

            if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado)
                animator2.SetBool("lanzadod2",true);

            //TIRA OTRA VEZ//

            if(Num_dado.num_sacado && gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces){
                num +=1;
                Num_dado.num_sacado = false;   

            }

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

            if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado)
                animator2.SetBool("lanzadod2",true);

            //TIRA OTRA VEZ//

            if(Num_dado.num_sacado && gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces){
                num +=1;
                Num_dado.num_sacado = false;   

            }

            

                
        }

    }

    public static void Wait(){

        aux += 1*Time.deltaTime;

        if(aux >= 2f) wait_t = false;

    }

}
