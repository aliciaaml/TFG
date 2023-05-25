using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SegundaTirada : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public Animator animator;

    public static bool segundaTerminada = false;
    public static bool wait_seg_dado = true;
    public static bool wait_vuelve = true;
    public static float aux_seg_dado = 0f;
    public static float aux_vuelve = 0f;

    public GameObject dado_1;
    public GameObject tex_vuelve_tirar;

    public GameObject colliderdado1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        if( gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces){


            if(!segundaTerminada){

                if (!dado_1.activeSelf){
                    
                    Trough_dice.dados_tirados = false;
                    Wait_vuelve_empezar();

                    if(wait_vuelve == false){

                        tex_vuelve_tirar.SetActive(true);
                        Wait_segundo_dado ();
                    }

                    if(wait_seg_dado == false){

                        tex_vuelve_tirar.SetActive(false);
                        Num_dado.wait_t2 = true;
                        Num_dado.aux2 = 0f;

                        Num_dado.range = 0;

                        dado_1.SetActive(true);

                        colliderdado1.SetActive(true);

                        segundaTerminada = true;


                        animator.SetBool("numero1",false);   
                        animator.SetBool("numero2",false);
                        animator.SetBool("numero3",false);
                        animator.SetBool("numero4",false);
                        animator.SetBool("numero5",false);
                        animator.SetBool("numero6",false);

                    }

                }

            }
        }
        
    }

    void Wait_segundo_dado(){
        
        aux_seg_dado += 1*Time.deltaTime;

        if(aux_seg_dado >= 2f) wait_seg_dado = false;

    }

    void Wait_vuelve_empezar(){

        aux_vuelve += 1*Time.deltaTime;

        if(aux_vuelve >= 1.5f) wait_vuelve= false;

    }

}
