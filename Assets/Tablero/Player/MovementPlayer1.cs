using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer1 : MonoBehaviour
{
    private UnityEngine.AI.NavMeshAgent navMeshAgent1;
    private Animator animator1;

    int m_CurrentWaypointIndex1;

    public ComunPlayers comunPlayers;

    public GameObject Dado1;

    public GameObject trough;

    public GameObject Nombre_Player;
    public TextMeshProUGUI turno_jugador;
    public TextMeshProUGUI turno_jugador_b;

    public TextMeshProUGUI nombreMinijuego;
    public TextMeshProUGUI nombreMinijuego2;

    public static bool una_vez = true;
    public static bool detectar_casilla = false;

    public GameObject textoDado;

    public GameObject LetreroMinijuego;
    public GameObject botonMinijuego;
    public GameObject LetreroNoMinijuego;
    public GameObject botonPlayerSig;

    public CinemachineVirtualCamera virtualCamera;
    private bool gira_una = true;

    public static Quaternion rotacionDeseada;
    public static float suavidadRotacion = 5f;
    public static float toleranciaRotacion = 0.001f;



    void Start()
    {
        navMeshAgent1 = GetComponent<UnityEngine.AI.NavMeshAgent>();
        animator1 = GetComponent<Animator>();
    }

    void Update()
    {
        if (CambiarPlayer.TurnoPlayer1) {

            if (ElegirPosiciones.turno_terminado == false) {

                textoDado.SetActive(false);

                if (EscogerPersonaje.character_choosed[0] == 0 && una_vez && !EscogerJugador.four_player) {    //IA

                    Dado1.SetActive(true);
                    trough.GetComponent<TroughDice>().IADown();
                    ElegirPosiciones.colliderDado = false;

                    turno_jugador.text = "Mushroom";
                    turno_jugador_b.text = "Mushroom";

                    Nombre_Player.SetActive(true);
                    detectar_casilla = false;

                }
                if (EscogerPersonaje.character_choosed[0] != 0) {           //JUGADOR

                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);
                    ElegirPosiciones.colliderDado = true;
                    turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                    turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                    detectar_casilla = false;
                }
                if (EscogerJugador.four_player) {                         //4 JUGADORES
                    Dado1.SetActive(true);
                    Nombre_Player.SetActive(true);
                    ElegirPosiciones.colliderDado = true;
                    turno_jugador.text = "Player 1";
                    turno_jugador_b.text = "Player 1";
                    detectar_casilla = false;
                }

            }

            else {

                Dado1.SetActive(false);
                Debug.Log("verdad o no: " + (navMeshAgent1.remainingDistance < ComunPlayers.tolerance));
                Debug.Log("blabla: " + (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar));
                if (ComunPlayers.comienza_turno)
                {
                    virtualCamera.Follow = transform;
                    virtualCamera.LookAt = transform;
                    gira_una = true;

                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    navMeshAgent1.SetDestination(ComunPlayers.waypoints_recorrer[0].position);
                    ComunPlayers.comienza_turno = false;

                    navMeshAgent1.speed = 25f;
                    navMeshAgent1.angularSpeed = 120f;
                    navMeshAgent1.acceleration = 8f;
                }


                if (navMeshAgent1.remainingDistance < ComunPlayers.tolerance && colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {

                    animator1.SetBool("moving", true);
                    m_CurrentWaypointIndex1 = (m_CurrentWaypointIndex1 + 1) % ComunPlayers.waypoints_recorrer.Count;
                    navMeshAgent1.SetDestination(ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex1].position);

                }

                if (colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && detectar_casilla == false)
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;

                    if (gira_una)
                    {
                        RotarInterpolado();
                        
                    }

                    textoDado.SetActive(false);
                    animator1.SetBool("moving", false);
                    navMeshAgent1.speed = 0f;
                    navMeshAgent1.angularSpeed = 0f;
                    navMeshAgent1.acceleration = 0f;

                    if (CasillaMinCoco.casilla_minijuego == "") {

                        LetreroNoMinijuego.SetActive(true);
                        botonPlayerSig.SetActive(true);

                    }
                    else {

                        if (CasillaMinCoco.casilla_minijuego == "juego_pesca") {

                            nombreMinijuego.text = "Fishing minigame";
                            nombreMinijuego2.text = "Fishing minigame";
                        }
                        if (CasillaMinCoco.casilla_minijuego == "juego_cocos") {

                            nombreMinijuego.text = "Coconuts minigame";
                            nombreMinijuego2.text = "Coconuts minigame";
                        }
                        if (CasillaMinCoco.casilla_minijuego == "juego_tiburones") {
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

    void RotarInterpolado()
    {
        
        // Calcular la rotacion deseada sumando la rotacion actual con un giro de 90 grados
        rotacionDeseada = transform.rotation* Quaternion.Euler(0f, 180f, 0f);

        Debug.Log("ahaha:   "+ rotacionDeseada);

        // Aplicar una interpolacion suave para rotar el jugador gradualmente
        transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, suavidadRotacion* Time.deltaTime);

        if (Quaternion.Angle(transform.rotation, rotacionDeseada) < toleranciaRotacion)
        {
            gira_una = false;
        }
    }

}
