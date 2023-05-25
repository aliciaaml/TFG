using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Player : MonoBehaviour
{

    [SerializeField] GameManager gameManager;

    public static bool player_avanza = false;
    public static int objetivo = 0;
    public GameObject casilla_actual;
    public static float aux_again = 0f;
    public static bool tirada_terminada = false;
    public static bool wait_again = true;

    public GameObject textoDado1;
    public GameObject textoDado2;
    public GameObject textoDobleDado;
    public GameObject textoTotal;
    public TextMeshProUGUI num;

    void OnCollisionEnter(Collision collision) {

        casilla_actual = collision.gameObject;

        if(gameManager.maquina.estadoActual != MaquinaEstados.Estado.TurnoNuevo && !player_avanza && Num_dado.dado_final){       //YA SE HA TIRADO EL DADO PERO EL PLAYER NO HA AVANZADO
    
            for(int i = 1; i<=12; i++ ){            //Numero de casillas
                
                if (collision.gameObject.tag == i.ToString()){

                    //Debug.Log("I  " + i);
                    objetivo = Num_dado.numero_dados_total + i;

                    if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarUnDado){
                         player_avanza = true;

                    }
                       
                    else if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDosVeces && Trough_dice.num >= 2)
                    {

                        

                        textoDado1.SetActive(false);
                        textoDado2.SetActive(false);

                        num.text =  Num_dado.numero_dados_total.ToString();
                        textoTotal.SetActive(true);

                        player_avanza = true;
                    }

                    else if (gameManager.maquina.estadoActual == MaquinaEstados.Estado.TirarDobleDado ){


                        textoDado1.SetActive(false);
                        textoDobleDado.SetActive(false);

                        num.text =  Num_dado.numero_dados_total.ToString();
                        textoTotal.SetActive(true);

                        player_avanza = true;
                    }
                        
                }

            }

            //SI EL JUGADOR HA LLEGADO A LA CASILLA QUE LE CORRESPONDE AL TIRAR CON LOS DADOS
            //Debug.Log("colision: " + collision.gameObject.tag + "objetivo:  " + objetivo.ToString());
            if(collision.gameObject.tag == objetivo.ToString()){

                textoTotal.SetActive(false);

                //AQUI HAY QUE CAMBIAR LA CAMARA AL SIGUIENTE JUGADOR
            }

        }
            

    }

    void Update(){
        
        

        //Debug.Log("Casilla actual : " + casilla_actual.tag);
        //Debug.Log("objetivo: " + objetivo);

        if(objetivo == int.Parse(casilla_actual.tag)){
            //Debug.Log("lo pilla");
            
            Wait_toStartAgain();
            
            if(wait_again== false){

                tirada_terminada = true;
            }

            


        }
    }

    void Wait_toStartAgain(){

        aux_again += 1*Time.deltaTime;

        if(aux_again >= 2f) wait_again = false;

    }

    
}


