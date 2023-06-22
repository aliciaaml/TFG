using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class ElegirPosiciones : MonoBehaviour
{
    public GameObject flechaSeta;
    public GameObject flechaRana;
    public GameObject flechaQueso;
    public GameObject flechaCactus;

    public static List<List<int>> numeroDado = new List<List<int>>();

    public static bool turno_terminado = false;

    public GameObject dado1;
    public GameObject texto_dado1;

    float aux_v = 0f;
    bool wait_v = true;
    
    float aux_j = 0f;
    bool wait_j = true;

    public GameObject[] flechas_characters;
    public GameObject[] num_pos_salida;
    public static int f = 0;
    int aux_f = 0;

    public static bool unica = true;

    public GameObject trough;

    public static bool colliderDado;

    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;
    public GameObject turno;

    bool una_por_jugador= true;
    public static bool agregar = false;

    public static bool ElegirTurnoTerminado = false;

    public GameObject comenzar;

    public void Wait_ver_num(){

        aux_v += 1*Time.deltaTime;

        if(aux_v >= 2f) wait_v = false;
        
    }

    public void Wait_comenzar_juego(){

        aux_j += 1*Time.deltaTime;

        if(aux_j >= 4f) wait_j = false;
    }

    // Update is called once per frame
    void Update()
    {
        if(!ElegirTurnoTerminado){

            if(DialogControler.dialog_terminado){

                if(!EscogerJugador.four_player){

                    if(flechas_characters[f] && turno_terminado== false){

                        if(EscogerPersonaje.character_choosed[f] == 0 && unica){        //IA
                            trough.GetComponent<Trough_dice>().IADown();

                            colliderDado = false;
                            if(f==0){
                                turno_jugador.text = "Mushroom";
                                turno_jugador_b.text = "Mushroom";
                            }
                            else if(f == 1){
                                turno_jugador.text = "Frog";
                                turno_jugador_b.text = "Frog";
                            }
                            else if(f== 2){
                                turno_jugador.text = "Cheese";
                                turno_jugador_b.text = "Cheese";
                            }
                            else if (f==3){
                                turno_jugador.text = "Cactus";
                                turno_jugador_b.text = "Cactus";
                            }
                            

                        }
                        if(EscogerPersonaje.character_choosed[f] != 0){
                            
                            colliderDado = true;
                            turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[f].ToString();
                            turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[f].ToString();
    
                        } 

                            
                    }
                    if(turno_terminado){
                        if(f<3){
                            Wait_ver_num();
                            if(wait_v == false){
                                
                                dado1.SetActive(true);
                                colliderDado=true;
                                texto_dado1.SetActive(false);

                                flechas_characters[f].SetActive(false);
                                f++;
                                una_por_jugador = true;
                                flechas_characters[f].SetActive(true);

                                turno_terminado = false;
                                wait_v = true;
                                aux_v = 0;
                                unica = true;
                                    
                            }
                        }
                        else{           //CACTUS

                            flechas_characters[f].SetActive(false);

                            Wait_ver_num();
                            if(wait_v == false){

                                texto_dado1.SetActive(false);
                                turno.SetActive(false);

                                wait_v = true;
                                aux_v = 0;


                                for(int i = 0; i<num_pos_salida.Length;i++){

                                    num_pos_salida[i].SetActive(true);
                                }
                                comenzar.SetActive(true);
                            }

                            // Ordena la lista de mayor a menor
                            numeroDado.Sort((a, b) => b[0].CompareTo(a[0]));;

                            for (int i = 0; i < numeroDado.Count; i++)
                            {
                                int f_personaje = numeroDado[i][1];
                                TextMeshProUGUI texto_posSalida = num_pos_salida[f_personaje].GetComponent<TextMeshProUGUI>();
                                texto_posSalida.text = (i+1).ToString() + "º";

                                if(f_personaje == 0){
                                    ComunPlayers.OrdenInicioPlayers.Add("player1");
                                }
                                else if (f_personaje == 1){
                                    ComunPlayers.OrdenInicioPlayers.Add("player2");
                                }
                                else if (f_personaje == 2){
                                    ComunPlayers.OrdenInicioPlayers.Add("player3");
                                }
                                else if (f_personaje == 3){
                                    ComunPlayers.OrdenInicioPlayers.Add("player4");
                                }
                            }

                            //ELEGIR TURNO TERMINADO//
                            MovementPlayer1.una_vez = true;
                            Wait_comenzar_juego();
                            if(wait_j == false){
                                ElegirTurnoTerminado = true;
                                
                                //Debug.Log("ElegirTurnoTerminado: " + ElegirTurnoTerminado);

                                for(int i = 0; i<num_pos_salida.Length;i++){

                                    num_pos_salida[i].SetActive(false);
                                }
                                comenzar.SetActive(false);
                                turno_terminado = false;
                                
                                
                            }
                        }                 
                    }
                        
                }
                else{              //CUATRO JUGADORES //

                    if(turno_terminado){
                        if(f<3){
                            Wait_ver_num();
                            if(wait_v == false){
                                
                                dado1.SetActive(true);
                                colliderDado=true;
                                texto_dado1.SetActive(false);

                                flechas_characters[f].SetActive(false);
                                f++;
                                una_por_jugador = true;
                                flechas_characters[f].SetActive(true);
                                aux_f = f+1;
                                turno_jugador.text = "Player " + aux_f.ToString();
                                turno_jugador_b.text = "Player " + aux_f.ToString();

                                turno_terminado = false;
                                wait_v = true;
                                aux_v = 0;
                                unica = true;
                                    
                            }
                        }
                        else{           

                            flechas_characters[f].SetActive(false);

                            Wait_ver_num();
                            if(wait_v == false){

                                texto_dado1.SetActive(false);
                                turno.SetActive(false);

                                wait_v = true;
                                aux_v = 0;

                                for(int i = 0; i<num_pos_salida.Length;i++){

                                    num_pos_salida[i].SetActive(true);
                                }
                                comenzar.SetActive(true);
                            }

                            // Ordena la lista de mayor a menor
                            numeroDado.Sort((a, b) => b[0].CompareTo(a[0]));

                            for (int i = 0; i < numeroDado.Count; i++)
                            {
                                int f_personaje = numeroDado[i][1];
                                TextMeshProUGUI texto_posSalida = num_pos_salida[f_personaje].GetComponent<TextMeshProUGUI>();
                                texto_posSalida.text = (i+1).ToString() + "º" ;

                                if(f_personaje == 0){
                                    ComunPlayers.OrdenInicioPlayers.Add("player1");
                                }
                                else if (f_personaje == 1){
                                    ComunPlayers.OrdenInicioPlayers.Add("player2");
                                }
                                else if (f_personaje == 2){
                                    ComunPlayers.OrdenInicioPlayers.Add("player3");
                                }
                                else if (f_personaje == 3){
                                    ComunPlayers.OrdenInicioPlayers.Add("player4");
                                }
                            }

                            //ELEGIR TURNO TERMINADO//

                            Wait_comenzar_juego();
                            if(wait_j == false){
                                ElegirTurnoTerminado = true;
                                
                                Debug.Log("ElegirTurnoTerminado: " + ElegirTurnoTerminado);

                                for(int i = 0; i<num_pos_salida.Length;i++){

                                    num_pos_salida[i].SetActive(false);
                                }
                                comenzar.SetActive(false);
                                turno_terminado = false;
                                
                            }
                        }                 
                    }
                }
        
            }

        }

                
    }
}
