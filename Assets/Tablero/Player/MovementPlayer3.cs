using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer3 : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent3;
    private Animator animator3;

    int m_CurrentWaypointIndex3;

    public ComunPlayers comunPlayers;
    public GameObject Dado1;
    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;

    public GameObject textoDado;

    public GameObject LetreroMinijuego;
    public GameObject botonMinijuego;
    public GameObject LetreroNoMinijuego;
    public GameObject botonPlayerSig;
    public TextMeshProUGUI nombreMinijuego;
    public TextMeshProUGUI nombreMinijuego2;

    public CinemachineVirtualCamera virtualCamera;
    public static bool gira_una3 = true;
    public MovementPlayer1 rotacion;

    public static float guardarPosPlayer3;

    void Start()
    {
        navMeshAgent3 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator3 = GetComponent<Animator>();

        //StartCoroutine(InterpolarRotacion());
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer3  ){
            
            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);

                if(EscogerPersonaje.character_choosed[2] == 0  && MovementPlayer1.una_vez && !EscogerJugador.four_player){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<TroughDice>().IADown();
                    ElegirPosiciones.colliderDado= false;

                    turno_jugador.text = "Cheese";
                    turno_jugador_b.text = "Cheese";

                    Nombre_Player.SetActive(true);
                    MovementPlayer1.detectar_casilla = false;
                    
                }
                if(EscogerPersonaje.character_choosed[2] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado=true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                    MovementPlayer1.detectar_casilla = false;
                }
                if(EscogerJugador.four_player){
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player 3";
                    turno_jugador_b.text = "Player 3";
                     MovementPlayer1.detectar_casilla = false;
                }

            }
            

            else{
                
                Dado1.SetActive(false);
                Debug.Log("verdad o no: " + (navMeshAgent3.remainingDistance < ComunPlayers.tolerance));
                Debug.Log("blabla: " + (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar));
                if (ComunPlayers.comienza_turno)
                {
                    virtualCamera.Follow = transform;
                    virtualCamera.LookAt = transform;
                    gira_una3 = true;
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent3.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    ComunPlayers.comienza_turno = false;

                    navMeshAgent3.speed = 25f;
                    navMeshAgent3.angularSpeed = 120f;
                    navMeshAgent3.acceleration = 8f;
                }

                if (navMeshAgent3.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {
                    animator3.SetBool("moving", true);
                    m_CurrentWaypointIndex3 = (m_CurrentWaypointIndex3 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent3.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex3].position);

                    


                }

                if(colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && MovementPlayer1.detectar_casilla == false)
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;

                    if(gira_una3){
                        StartCoroutine(InterpolarRotacion3());
                        gira_una3 = false;
                    }

                    textoDado.SetActive(false);
                    animator3.SetBool("moving", false);
                    navMeshAgent3.speed = 0f;
                    navMeshAgent3.angularSpeed = 0f;
                    navMeshAgent3.acceleration = 0f;

                    if(CasillaMinCoco.casilla_minijuego == ""){
                        
                        LetreroNoMinijuego.SetActive(true);
                        botonPlayerSig.SetActive(true);

                    }
                    else{

                        if(CasillaMinCoco.casilla_minijuego == "juego_pesca"){

                            nombreMinijuego.text = "Fishing minigame" ;
                            nombreMinijuego2.text = "Fishing minigame" ;
                        }
                        if(CasillaMinCoco.casilla_minijuego == "juego_cocos"){

                            nombreMinijuego.text = "Coconuts minigame";
                            nombreMinijuego2.text = "Coconuts minigame";
                        }
                        if(CasillaMinCoco.casilla_minijuego == "juego_tiburones"){
                            nombreMinijuego.text = "Sharks minigame";
                            nombreMinijuego2.text = "Sharks minigame";
                            
                        }

                        LetreroMinijuego.SetActive(true);
                        botonMinijuego.SetActive(true);

                    }
                    
                }   

            }
            
        }

    }


    IEnumerator InterpolarRotacion3(){
        float _tiempotrans = 0f;
        float animTime = 2f;

        guardarPosPlayer3 = transform.position.y;
        Quaternion rotacionDeseada = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180f, transform.eulerAngles.z);
  
        float _ratio = 0;

        while(_tiempotrans < animTime){

            Debug.Log("AHORAAA");  
            _tiempotrans += Time.deltaTime;
            _ratio = _tiempotrans / animTime;

            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada,_ratio);

            yield return new WaitForSeconds(1f / 60f);

            _tiempotrans +=1f/60f;
        }

        
        yield return null;
    }


}
