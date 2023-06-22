using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Num_dado : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    private Animator animator;

    public static bool wait_t = true;
    public static bool wait_t2 = true;
    public static int range;
    public static bool num_sacado = false;
    public static bool tira_otra = false;
    public static float aux = 0f;
    public static float aux2 = 0f;
    public static int numero_dados_total = 0;
    public static bool dado_final = false;

    public GameObject texto_numero_total1;
    public TextMeshProUGUI numero_total1;
    public GameObject texto_numero_total2_veces;
    public TextMeshProUGUI numero_total2_veces;
    public GameObject colliderDado1;

    public static bool resultado_dado_obtenido = false;

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(Trough_dice.dados_tirados == true){

            Wait_trough();

            if(wait_t == false){

                animator.SetBool("lanzado",false);

                range = Random.Range(1,7);

                numero_dados_total += range;

                num_sacado = true;

                aux = 0f;

                wait_t = true;

                Trough_dice.dados_tirados = false;
                
                animator.SetBool("repetir",false);
            }

            
            if(range == 1){

                animator.SetBool("numero1",true);

                animator.SetBool("numero2",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero6",false);

            }

                
            else if(range == 2){


                animator.SetBool("numero2",true);

                animator.SetBool("numero1",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero6",false);

            }

            else if (range == 3){


                animator.SetBool("numero3",true);

                animator.SetBool("numero1",false);
                animator.SetBool("numero2",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero6",false);
        
            }

            else if ( range == 4){


                animator.SetBool("numero4",true);

                animator.SetBool("numero1",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero2",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero6",false);
        

            }

            else if (range == 5){


                animator.SetBool("numero5",true);

                animator.SetBool("numero1",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero2",false);
                animator.SetBool("numero6",false);

            }

            else if (range == 6){


                animator.SetBool("numero6",true);

                animator.SetBool("numero1",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero2",false);

            }


            //////// TIRA OTRA VEZ ///////
            
            if(Trough_dice.num == 2 && gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces){

                animator.SetBool("numero1",false);
                animator.SetBool("numero2",false);
                animator.SetBool("numero3",false);
                animator.SetBool("numero4",false);
                animator.SetBool("numero5",false);
                animator.SetBool("numero6",false);

                animator.SetBool("repetir", true);

                aux = 0f;

                wait_t = true;
                Trough_dice.num+=1;



            }


        }
        

        //////// NO   TIRA OTRA VEZ , DADO1 ///////

        if(( gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado ||  gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado) && (animator.GetBool("numero1") || animator.GetBool("numero2") 
            || animator.GetBool("numero3") || animator.GetBool("numero4") || animator.GetBool("numero5") || animator.GetBool("numero6"))){

            Wait_trough2();
            
            if(wait_t2 == false){

                gameObject.SetActive(false);

                //Dado1.SetActive(false);

                if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado){

                    numero_total1.text = range.ToString();

                    if(ElegirPosiciones.ElegirTurnoTerminado){

                        ComunPlayers.casilla_destino = range;
                        resultado_dado_obtenido = true;
                        
                    } 
                
                    texto_numero_total1.SetActive(true);
                    ElegirPosiciones.numeroDado.Add(new List<int> { range, ElegirPosiciones.f });

                    ElegirPosiciones.turno_terminado = true;

                }

                dado_final = true;

                wait_t2 = true;
                aux2 = 0;

            }         
            
        }

        //TIRA OTRA VEZ

        if( gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces){

            if(animator.GetBool("numero1") || animator.GetBool("numero2") 
                || animator.GetBool("numero3") || animator.GetBool("numero4") || animator.GetBool("numero5") || animator.GetBool("numero6")){


                Wait_trough2();
            
                if(wait_t2 == false ){

                    gameObject.SetActive(false);

                    //colliderDado1.SetActive(false);


                    //PRIMER DADO
                    if(Trough_dice.num < 2 ){

                        numero_total1.text = range.ToString();
                        texto_numero_total1.SetActive(true);
                        
                        
                    }   
                        
                    //SEGUNDO DADO
                    else if(Trough_dice.num >= 2 ){

                        numero_total2_veces.text = range.ToString();
                        texto_numero_total2_veces.SetActive(true);

                        dado_final = true;
                    }

                }


            }

            
        }

        
    }

    public static void Wait_trough(){

        aux += 1*Time.deltaTime;

        if(aux >= 0.5f) wait_t = false;

    }

    void Wait_trough2 () {

        aux2 += 1*Time.deltaTime;
        
        if(aux2 >= 4f){
            
             wait_t2 = false;
        }
    }



}
