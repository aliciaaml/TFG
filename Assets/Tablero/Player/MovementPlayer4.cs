using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer4 : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent4;
    private Animator animator4;


    int m_CurrentWaypointIndex4;

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
    public static bool gira_una4 = true;
    public MovementPlayer1 rotacion;

    public static float guardarPosPlayer4;

    void Start()
    {
        navMeshAgent4 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator4 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer4  ){

            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);

                if(EscogerPersonaje.character_choosed[3] == 0  && MovementPlayer1.una_vez && !EscogerJugador.four_player){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<TroughDice>().IADown();
                    ElegirPosiciones.colliderDado = false;

                    turno_jugador.text = "Cactus";
                    turno_jugador_b.text = "Cactus";

                    Nombre_Player.SetActive(true);
                    MovementPlayer1.detectar_casilla = false;
                    
                }
                if(EscogerPersonaje.character_choosed[3] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado = true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                    MovementPlayer1.detectar_casilla = false;
                }
                if(EscogerJugador.four_player){
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player 4";
                    turno_jugador_b.text = "Player 4";
                    MovementPlayer1.detectar_casilla = false;
                }

            }
            

            else{
                Dado1.SetActive(false);
                Debug.Log("verdad o no: " + (navMeshAgent4.remainingDistance < ComunPlayers.tolerance));
                Debug.Log("blabla: " + (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar));
                

                if (ComunPlayers.comienza_turno )
                {
                    virtualCamera.Follow = transform;
                    virtualCamera.LookAt = transform;
                    gira_una4 = true;

                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    ComunPlayers.comienza_turno = false;

                    navMeshAgent4.speed = 25f;
                    navMeshAgent4.angularSpeed = 120f;
                    navMeshAgent4.acceleration = 8f;
                }

                if (navMeshAgent4.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                { 
                    animator4.SetBool("moving", true);
                    m_CurrentWaypointIndex4 = (m_CurrentWaypointIndex4 + 1) % ComunPlayers.waypoints_recorrer.Count; 
                    navMeshAgent4.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex4].position);
                    


                } 
                if(colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && MovementPlayer1.detectar_casilla == false)
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;
                    
                    if(gira_una4){
                        StartCoroutine(InterpolarRotacion4());
                        gira_una4 = false;
                    }
                  

                    textoDado.SetActive(false);
                    animator4.SetBool("moving", false);
                    navMeshAgent4.speed = 0f;
                    navMeshAgent4.angularSpeed = 0f;
                    navMeshAgent4.acceleration = 0f;

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

    IEnumerator InterpolarRotacion4(){
        float _tiempotrans = 0f;
        float animTime = 2f;
        guardarPosPlayer4 = transform.position.y;

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
