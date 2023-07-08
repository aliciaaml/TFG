using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer1 : MonoBehaviour
{
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
    public static bool gira_una1 = true;

    public float velocidad1 = 20f;


    void Start()
    {
        animator1 = GetComponent<Animator>();
    }

    void Update()
    {
        if (CambiarPlayer.TurnoPlayer1) {

            if (ElegirPosiciones.turno_terminado == false) {

                virtualCamera.Follow = transform;
                virtualCamera.LookAt = transform;
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

                if (ComunPlayers.comienza_turno)
                {
                    gira_una1 = true;
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    m_CurrentWaypointIndex1 = 0; // Establecer el índice del waypoint actual en 0
                    ComunPlayers.comienza_turno = false;
                }

                if (colisionPlayer.actual != ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar)
                {
                    animator1.SetBool("moving", true);

                    if (m_CurrentWaypointIndex1 < ComunPlayers.waypoints_recorrer.Count)
                    {
                        Vector3 objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex1].position;
                        float distancia = Vector3.Distance(transform.position, objetivo);

                        if (distancia <= 0.1f)
                        {
                            m_CurrentWaypointIndex1++;
                            if (m_CurrentWaypointIndex1 < ComunPlayers.waypoints_recorrer.Count)
                            {
                                objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex1].position;
                            }
                            else
                            {
                                animator1.SetBool("moving", false); // Detener la animación de movimiento
                                return;
                            }
                        }

                        Vector3 direccion = (objetivo - transform.position).normalized;
                        Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
                        float velocidadRotacion = 120f; // Ajusta la velocidad de rotación según tus necesidades
                        transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
                        transform.position += direccion * velocidad1 * Time.deltaTime;
                    }
                }

                if (colisionPlayer.actual == ComunPlayers.casilla_destino + ComunPlayers.casilla_antes_tirar && detectar_casilla == false)
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;

                    if(gira_una1){
                        StartCoroutine(InterpolarRotacion());
                        gira_una1 = false;
                    }
                    
                    

                    textoDado.SetActive(false);
                    animator1.SetBool("moving", false);

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
    IEnumerator InterpolarRotacion(){
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
