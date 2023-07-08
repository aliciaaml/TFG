using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;

public class MovementPlayer2 : MonoBehaviour
{
    private Animator animator2;

    int m_CurrentWaypointIndex2;

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
    public static bool gira_una2 = true;
    public MovementPlayer1 rotacion;
    public float velocidad2 = 15f;

    void Start()
    {
        animator2 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer2 ){

            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);
                virtualCamera.Follow = transform;
                virtualCamera.LookAt = transform;

                if(EscogerPersonaje.character_choosed[1] == 0  && MovementPlayer1.una_vez && !EscogerJugador.four_player){    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<TroughDice>().IADown();
                    ElegirPosiciones.colliderDado=false;

                    turno_jugador.text = "Frog";
                    turno_jugador_b.text = "Frog";

                    Nombre_Player.SetActive(true);
                    MovementPlayer1.detectar_casilla = false;
                    
                }
                if(EscogerPersonaje.character_choosed[1] != 0){           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado=true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[1].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[1].ToString();
                    MovementPlayer1.detectar_casilla = false;
                }
                if(EscogerJugador.four_player){
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);                    
                    ElegirPosiciones.colliderDado= true;
                    turno_jugador.text = "Player 2";
                    turno_jugador_b.text = "Player 2";
                    MovementPlayer1.detectar_casilla = false;
                }

            }
            

            else{

                if (ComunPlayers.comienza_turno)
                {
                    gira_una2 = true;
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    m_CurrentWaypointIndex2 = 0; // Establecer el índice del waypoint actual en 0
                    ComunPlayers.comienza_turno = false;
                }

                if (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {
                    animator2.SetBool("moving", true);

                    if (m_CurrentWaypointIndex2 < ComunPlayers.waypoints_recorrer.Count)
                    {
                        Vector3 objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex2].position;
                        float distancia = Vector3.Distance(transform.position, objetivo);

                        if (distancia <= 0.1f)
                        {
                            m_CurrentWaypointIndex2++;
                            if (m_CurrentWaypointIndex2 < ComunPlayers.waypoints_recorrer.Count)
                            {
                                objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex2].position;
                            }
                            else
                            {
                                animator2.SetBool("moving", false); // Detener la animación de movimiento
                                return;
                            }
                        }

                        Vector3 direccion = (objetivo - transform.position).normalized;
                        Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
                        float velocidadRotacion = 5f; // Ajusta la velocidad de rotación según tus necesidades
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
                        transform.position += direccion * velocidad2 * Time.deltaTime;
                    }
                }
                if(colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && MovementPlayer1.detectar_casilla == false)
                {
                   
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;
                    if(gira_una2){
                        StartCoroutine(InterpolarRotacion2());
                        gira_una2 = false;
                    }
                    textoDado.SetActive(false);
                    animator2.SetBool("moving", false);

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

    IEnumerator InterpolarRotacion2(){
        float _tiempotrans = 0f;
        float animTime = 2f;

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
