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

    public GameObject panelPierdeTurno;
    public GameObject panelPierdeTurnoIA;
    public TextMeshProUGUI pierdeturnoIAtext;
    public TextMeshProUGUI pierdeturnoIAtext2;

    public BotonSiguiente botonSiguiente;
    public GameObject panelIAWin;
    public GameObject panelIALose;
    public TextMeshProUGUI cartelWinIA;
    public TextMeshProUGUI cartelLoseIA;
    public static float aux_LW  = 0f;
    public static bool wait_LW = true;
    public static float aux_siguiente = 0f;
    public static bool wait_siguiente = true;

    public static bool wait_pasar = true;
    public static float aux_pasar = 0f;

    void Start()
    {
        animator1 = GetComponent<Animator>();
        
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer1 && ComunPlayers.pierdeTurnoplayer1){
            
            if(EscogerPersonaje.character_choosed[0] == 0){
                turno_jugador.text = "Mushroom";
                turno_jugador_b.text = "Mushroom";
                panelPierdeTurnoIA.SetActive(true);
                pierdeturnoIAtext.text = "Mushroom loses turn!!";
                pierdeturnoIAtext2.text = "Mushroom loses turn!!";

                Wait_pasar();
                if(wait_pasar == false){
                    panelPierdeTurnoIA.SetActive(false);
                    botonSiguiente.SiguientePlayer();
                    wait_pasar = true;
                    aux_pasar = 0f;
                    ComunPlayers.pierdeTurnoplayer1 = false;
                }


            }
            if (EscogerPersonaje.character_choosed[0] != 0) {
                turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[0].ToString();
                panelPierdeTurno.SetActive(true);
                ComunPlayers.pierdeTurnoplayer1 = false;
            }

            if (EscogerJugador.four_player) { 

                turno_jugador.text = "Player 1";
                turno_jugador_b.text = "Player 1";
                panelPierdeTurno.SetActive(true);
                ComunPlayers.pierdeTurnoplayer1 = false;
            }

            
            
        }

        else if (CambiarPlayer.TurnoPlayer1 && ComunPlayers.pierdeTurnoplayer1 == false) {
            
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

                if (transform.position != ComunPlayers.waypoints_recorrer[ComunPlayers.waypoints_recorrer.Count -1].position
                    && m_CurrentWaypointIndex1 < ComunPlayers.waypoints_recorrer.Count)
                {
                    animator1.SetBool("moving", true);
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
                    //Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
                    //float velocidadRotacion = 40f; // Ajusta la velocidad de rotación según tus necesidades

                    //transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);
                    transform.LookAt(objetivo);
                    //lookAt.StartRotation(gameObject, ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex1]);
                    transform.position += direccion * velocidad1 * Time.deltaTime;
                }
                
                else
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;

                    if(gira_una1){
                        StartCoroutine(InterpolarRotacion());
                        //ComunPlayers.angle = Vector3.Angle(transform.forward, ComunPlayers.worldForwardDirection);
                        gira_una1 = false;
                    }
                    
                    

                    textoDado.SetActive(false);
                    animator1.SetBool("moving", false);

                    if(CasillaMinCoco.casilla_minijuego == ""){
                        
                        LetreroNoMinijuego.SetActive(true);
                        if(EscogerPersonaje.character_choosed[0] != 0){
                            botonPlayerSig.SetActive(true);
                        }
                            
                        else{
                            Wait_Siguiente();
                            if(wait_siguiente == false){
                                /*
                                if (ComunPlayers.angle < 90f) //Si está hacia detras se gira
                                {
                                    transform.Rotate(Vector3.up, -180f);
                                    //ComunPlayers.angle = Vector3.Angle(transform.forward, ComunPlayers.worldForwardDirection);
                                }
                                */
                                DontDestroy.guardarPosPlayer1 = transform.position;
                                CambiarPlayer.TurnoPlayer1 = false;

                                botonSiguiente.SiguientePlayer();
                                wait_siguiente = true;
                                aux_siguiente = 0f;
                            }
                        }

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
                        if(EscogerPersonaje.character_choosed[0] != 0){
                            botonMinijuego.SetActive(true);
                        }
                        else{
                            Wait_LoseWin();
                            if(wait_LW == false){
                                LetreroMinijuego.SetActive(false);
                                
                                ComunPlayers.ganar_perder = ComunPlayers.juegaIA();

                                if(ComunPlayers.ganar_perder == 0 && ComunPlayers.una_por_turno == false){
                                    cartelLoseIA.text= " Mushroom loses the minigame!";
                                    panelIALose.SetActive(true);
                                    
                                    Wait_Siguiente();
                                    if(wait_siguiente == false){
                                        ComunPlayers.pierdeTurnoplayer1 = true;
                                        ComunPlayers.una_por_turno = true;
                                        /*
                                        if (ComunPlayers.angle < 90f) //Si está hacia detras se gira
                                        {
                                            transform.Rotate(Vector3.up, -180f);
                                            ComunPlayers.angle = Vector3.Angle(transform.forward, ComunPlayers.worldForwardDirection);
                                        }
                                        */
                                        DontDestroy.guardarPosPlayer1 = transform.position;
                                        CambiarPlayer.TurnoPlayer1 = false;
            
                                        botonSiguiente.SiguientePlayer();
                                        panelIALose.SetActive(false);
                                        wait_siguiente = true;
                                        aux_siguiente = 0f;
                                        wait_LW = true;
                                        aux_LW = 0f;
                                    }
                                }
                                if(ComunPlayers.ganar_perder != 0 && ComunPlayers.una_por_turno == false){
                                    cartelWinIA.text = "Mushroom wins the minigame!";
                                    panelIAWin.SetActive(true);
                                    Wait_Siguiente();
                                    if(wait_siguiente == false){
                                        /*
                                        if (ComunPlayers.angle < 90f) //Si está hacia detras se gira
                                        {
                                            transform.Rotate(Vector3.up, -180f);
                                            ComunPlayers.angle = Vector3.Angle(transform.forward, ComunPlayers.worldForwardDirection);
                                        }
                                        */
                                        
                                        DontDestroy.guardarPosPlayer1 = transform.position;
                                        CambiarPlayer.TurnoPlayer1 = false;

                                        botonSiguiente.SiguientePlayer();
                                        ComunPlayers.una_por_turno = true;
                                        panelIAWin.SetActive(false);
                                        wait_siguiente = true;
                                        aux_siguiente = 0f;
                                        wait_LW = true;
                                        aux_LW = 0f;
                                    }
                                }
                            }
                            
                        }

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
            _tiempotrans += Time.deltaTime;
            _ratio = _tiempotrans / animTime;

            transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada,_ratio);

            yield return new WaitForSeconds(1f / 60f);

            _tiempotrans +=1f/60f;
        }

        yield return null;
    }
    

    public void Wait_LoseWin(){

        aux_LW += 1*Time.deltaTime;

        if(aux_LW >= 5f) wait_LW = false;

    }

    public void Wait_Siguiente(){

        aux_siguiente += 1*Time.deltaTime;

        if(aux_siguiente >= 2f) wait_siguiente = false;

    }

    void Wait_pasar(){
        aux_pasar += 1*Time.deltaTime;

        if(aux_pasar >= 5f) wait_pasar= false;
    }
}
