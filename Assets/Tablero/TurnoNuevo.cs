using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurnoNuevo : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public GameObject texto;
    public GameObject texto2;
    public GameObject colliderDado1;
    public GameObject colliderDobleDado;
    public GameObject dado1;
    public GameObject dado2;

    public Collider colliderCasilla;


    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {


        
            if(gameManager.maquina.estadoActual == MaquinaEstados.Estado.TurnoNuevo){

                //PASAMOS AL SIGUIENTE JUGADOR
                


                Num_dado.wait_t = true;
                Num_dado.wait_t2 = true;
                SegundaTirada.wait_seg_dado = true;
                SegundaTirada.wait_vuelve = true;
                Num_dado2.wait_t2d2 = true;
                Player.wait_again = true;
                Num_dado.dado_final = false;
                SegundaTirada.segundaTerminada = false;

                Num_dado.aux = 0f;
                Num_dado.aux2 = 0f;
                SegundaTirada.aux_vuelve = 0f;
                SegundaTirada.aux_seg_dado = 0f;
                Num_dado2.aux2d2 = 0f;

                Player.aux_again = 0f;
                Player.objetivo = 0;
                colliderCasilla.enabled = false;
                ColliderEnable.collider_casilla = false;

                Num_dado.num_sacado =false;
                Num_dado.tira_otra = false;
                Num_dado.numero_dados_total  = 0;
                Player.tirada_terminada = false;
                Player.player_avanza = false;

                Trough_dice.num = 1;
                Trough_dice.dados_tirados = false;

                texto.SetActive(false);
                texto2.SetActive(false);
                colliderDado1.SetActive(true);
                colliderDobleDado.SetActive(false);
                dado1.SetActive(true);
                dado2.SetActive(false);

                gameManager.ActivarEstado(MaquinaEstados.Estado.TirarUnDado);
            }
        
    }

    
}
