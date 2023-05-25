using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Num_dado2 : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public Animator animator2;
    public static int range2;

    public static float aux2d2 = 0f;

    public static bool wait_t2d2 = true;

    public GameObject colliderDado1;
    public GameObject colliderDobleDado;
    public GameObject dado2;
    public GameObject texto2;
    public TextMeshProUGUI numero_total2;

    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado){


            colliderDado1.SetActive(false);
            colliderDobleDado.SetActive(true);
            dado2.SetActive(true);


            if(Trough_dice.dados_tirados == true){
                
                Num_dado.Wait_trough();

                if(Num_dado.wait_t == false){

                    animator2.SetBool("lanzadod2",false);

                    range2 = Random.Range(1,6);


                }

                if( range2 == 1){

            
                    animator2.SetBool("numero1d2",true);

                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero3d2",false);
                    animator2.SetBool("numero4d2",false);
                    animator2.SetBool("numero5d2",false);
                    animator2.SetBool("numero6d2",false);

                }

                else if( range2 == 2){

                    animator2.SetBool("numero2d2",true);

                    animator2.SetBool("numero1d2",false);
                    animator2.SetBool("numero3d2",false);
                    animator2.SetBool("numero4d2",false);
                    animator2.SetBool("numero5d2",false);
                    animator2.SetBool("numero6d2",false);

                }

                else if( range2 == 3){

                    animator2.SetBool("numero3d2",true);

                    animator2.SetBool("numero1d2",false);
                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero4d2",false);
                    animator2.SetBool("numero5d2",false);
                    animator2.SetBool("numero6d2",false);

                }

                else if( range2 == 4){

                    animator2.SetBool("numero4d2",true);

                    animator2.SetBool("numero1d2",false);
                    animator2.SetBool("numero3d2",false);
                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero5d2",false);
                    animator2.SetBool("numero6d2",false);
                    
                }

                else if( range2 == 5){

                    animator2.SetBool("numero5d2",true);

                    animator2.SetBool("numero1d2",false);
                    animator2.SetBool("numero3d2",false);
                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero6d2",false);
                    
                }

                else if( range2 == 6){

                    animator2.SetBool("numero6d2",true);

                    animator2.SetBool("numero1d2",false);
                    animator2.SetBool("numero3d2",false);
                    animator2.SetBool("numero2d2",false);
                    animator2.SetBool("numero5d2",false);
                    animator2.SetBool("numero2d2",false);
    
                }
            }
            
            if((animator2.GetBool("numero1d2") || animator2.GetBool("numero2d2") 
                || animator2.GetBool("numero3d2") || animator2.GetBool("numero4d2") || animator2.GetBool("numero5d2") || animator2.GetBool("numero6d2"))){

                Debug.Log("ENTRAA");
                Wait_trough2d2();

                if(wait_t2d2 == false){
                    Debug.Log("ENTRAA2");
                    dado2.SetActive(false);

                    colliderDado1.SetActive(false);
                    colliderDobleDado.SetActive(false);

                    //numero_total2.text = range2.ToString();

                   // texto2.SetActive(true);

                    Num_dado.dado_final = true;

                    //LLAMAR AL PLAYER QUE LE TOQUE Y HACER QUE AVANCE 

                    Num_dado.numero_dados_total = Num_dado.range +  range2;

                }

            }
                    
        }
      
        
    }

    void Wait_trough2d2 () {

        aux2d2 += 1*Time.deltaTime;

        if(aux2d2 >= 4f) wait_t2d2 = false;


    }
}
