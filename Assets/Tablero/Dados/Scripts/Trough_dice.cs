using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trough_dice : MonoBehaviour
{
    [SerializeField] GameManager gameManager;
    
    private Animator animator;

    private Animator animator2;

    public static bool dados_tirados = false;

    public static int num = 1;


    void Start()
    {
        

    }

    void Update (){

        if ( gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado ||  gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces ){

            animator = transform.parent.GetComponent<Animator>();

        }
            

        if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado){

            animator = transform.parent.parent.GetComponent<Animator>();

            animator2 = transform.parent.GetComponent<Animator>();


        }



    }


    public void OnMouseDown()
    {
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
