using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class NumDado : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    private Animator animator;

    public static bool wait_t = true;
    public static bool wait_t2 = true;
    public static int range;
    public static bool num_sacado = false;
    public static float aux = 0f;
    public static float aux2 = 0f;
    public static bool dado_final = false;

    public GameObject texto_numero_total1;
    public TextMeshProUGUI numero_total1;
    
    public GameObject colliderDado1;
    public static int auxNumDado;

    public static bool resultado_dado_obtenido = false;

    public static bool ListaNumDado = false;

    

    // Start is called before the first frame update
    void Start()
    {
        animator = GetComponent<Animator>();
        
    }

    // Update is called once per frame
    void Update()
    {

        if(TroughDice.dados_tirados == true){

            Wait_trough();

            if(wait_t == false){

                animator.SetBool("lanzado",false);

                range = Random.Range(1,7);

                num_sacado = true;

                aux = 0f;

                wait_t = true;

                TroughDice.dados_tirados = false;
                
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


        }
   

        if(( gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado ||  gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado) && (animator.GetBool("numero1") || animator.GetBool("numero2") 
            || animator.GetBool("numero3") || animator.GetBool("numero4") || animator.GetBool("numero5") || animator.GetBool("numero6"))){

            Wait_trough2();
            
            if(wait_t2 == false){

                gameObject.SetActive(false);

                if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado){

                    numero_total1.text = range.ToString();
                    ComunPlayers.no_detect_casilla_minijuego = false;

                    if(ElegirPosiciones.ElegirTurnoTerminado){

                        ComunPlayers.casilla_destino = range;
                        auxNumDado = range;
                        resultado_dado_obtenido = true;
                        
                    } 
                
                    texto_numero_total1.SetActive(true);
                    if(!ElegirPosiciones.ElegirTurnoTerminado && !ElegirPosiciones.terminadoCactus){

                        ElegirPosiciones.numeroDado.Add(new List<int> { range, ElegirPosiciones.f });
                        ListaNumDado = true;
                    }
                    

                    ElegirPosiciones.turno_terminado = true;

                }

                dado_final = true;

                wait_t2 = true;
                aux2 = 0;

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
