using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ElegirPosiciones : MonoBehaviour
{
    public GameObject flechaSeta;
    public GameObject flechaRana;
    public GameObject flechaQueso;
    public GameObject flechaCactus;

    public List<int> numeroDado = new List<int>();

    public static bool turno_terminado = false;

    public GameObject dado1;
    public GameObject texto_dado1;

    float aux_v = 0f;
    bool wait_v = true;

    public GameObject[] flechas_characters;
    int f = 0;

    public static bool unica = true;

    public GameObject trough;

    public GameObject colliderDado;

    void Start(){

        
    }

    public void Wait_ver_num(){

        aux_v += 1*Time.deltaTime;

        if(aux_v >= 2f) wait_v = false;

    }

    // Update is called once per frame
    void Update()
    {
        if(DialogControler.dialog_terminado){

            if(!EscogerJugador.four_player){

                if(flechas_characters[f] && turno_terminado== false){

                    if(EscogerPersonaje.character_choosed[f] == 0 && unica){        //IA
                        trough.GetComponent<Trough_dice>().IADown();
                        numeroDado.Add(Num_dado.range);
                        colliderDado.SetActive(false);
                    }
                    else if(Trough_dice.mouse && unica){
                        numeroDado.Add(Num_dado.range);

                    }
                }
                if(turno_terminado){
                    if(f<3){
                        Wait_ver_num();
                        if(wait_v == false){
                            
                            dado1.SetActive(true);
                            colliderDado.SetActive(true);
                            texto_dado1.SetActive(false);

                            flechas_characters[f].SetActive(false);
                            f++;
                            flechas_characters[f].SetActive(true);

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
                            turno_terminado = false;
                            wait_v = true;
                            aux_v = 0;
                        }
                        // Ordena la lista de mayor a menor
                        numeroDado.Sort((a, b) => b.CompareTo(a));

                        Debug.Log("YA TENEMOS LOS TURNOS");
                    }                 
                }
                    
            }
     
        }        
    }
}
