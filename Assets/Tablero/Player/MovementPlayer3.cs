using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer3 : MonoBehaviour
{
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

    //public static float guardarPosPlayer3;
    public float velocidad3 = 15f;

    public GameObject panelPierdeTurno;

    public GameObject panelPierdeTurnoIA;
    public TextMeshProUGUI pierdeturnoIAtext;
    public TextMeshProUGUI pierdeturnoIAtext2;

    public BotonSiguiente botonSiguiente;
    public TextMeshProUGUI cartelWinIA;
    public TextMeshProUGUI cartelLoseIA;
    public GameObject panelIAWin;
    public GameObject panelIALose;

    public static  float aux_LW  = 0f;
    public static bool wait_LW = true;
    public static float aux_siguiente = 0f;
    public static bool wait_siguiente = true;

    public static bool wait_pasar = true;
    public static float aux_pasar = 0f;

    public TextMeshProUGUI cartelFinal;
    public TextMeshProUGUI cartelFinal2;

    void Start()
    {
        animator3 = GetComponent<Animator>();

    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer3  && ComunPlayers.pierdeTurnoplayer3){
            virtualCamera.Follow = transform;
            virtualCamera.LookAt = transform;
            if(EscogerPersonaje.character_choosed[2] == 0 && EscogerJugador.four_player == false ){
                Dado1.SetActive(false);
                virtualCamera.Follow = transform;
                virtualCamera.LookAt = transform;
                turno_jugador.text = "Cheese";
                turno_jugador_b.text = "Cheese";

                panelPierdeTurnoIA.SetActive(true);
                pierdeturnoIAtext.text = "Cheese loses turn!!";
                pierdeturnoIAtext2.text = "Cheese loses turn!!";

                Wait_pasar();
                if(wait_pasar == false){
                    panelPierdeTurnoIA.SetActive(false);
                    botonSiguiente.SiguientePlayer();
                    wait_pasar = true;
                    aux_pasar = 0f;
                    ComunPlayers.pierdeTurnoplayer3 = false;
                }
            }
            if (EscogerPersonaje.character_choosed[2] != 0) {
                Dado1.SetActive(false);
                turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[2].ToString();
                panelPierdeTurno.SetActive(true);
                ComunPlayers.pierdeTurnoplayer3 = false;
            }

            if (EscogerJugador.four_player) { 
                Dado1.SetActive(false);
                turno_jugador.text = "Player 3";
                turno_jugador_b.text = "Player 3";
                panelPierdeTurno.SetActive(true);
                ComunPlayers.pierdeTurnoplayer3 = false;
            }
            
            
            
        }

        else if(CambiarPlayer.TurnoPlayer3  && panelPierdeTurno.activeSelf == false && panelPierdeTurnoIA.activeSelf == false){
            //Debug.Log("nooo entresss3");
            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);
                virtualCamera.Follow = transform;
                virtualCamera.LookAt = transform;

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
                if (ComunPlayers.comienza_turno)
                {
                    gira_una3 = true;
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    m_CurrentWaypointIndex3 = 0; // Establecer el índice del waypoint actual en 0
                    ComunPlayers.comienza_turno = false;
                }

                if (transform.position != ComunPlayers.waypoints_recorrer[ComunPlayers.waypoints_recorrer.Count -1].position
                    && m_CurrentWaypointIndex3 < ComunPlayers.waypoints_recorrer.Count)
                {
                    animator3.SetBool("moving", true);
                    Vector3 objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex3].position;
                    float distancia = Vector3.Distance(transform.position, objetivo);

                    if (distancia <= 0.1f)
                    {
                        m_CurrentWaypointIndex3++;
                        if (m_CurrentWaypointIndex3 < ComunPlayers.waypoints_recorrer.Count)
                        {
                            objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex3].position;
                        }
                        else
                        {
                            animator3.SetBool("moving", false); // Detener la animación de movimiento
                            return;
                        }
                    }

                    Vector3 direccion = (objetivo - transform.position).normalized;
                    transform.LookAt(objetivo);
                    transform.position += direccion * velocidad3 * Time.deltaTime;
                }

                else
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;

                    if(gira_una3){
                        ComunPlayers.espaldas = false;
                        transform.Rotate(Vector3.up, 180f);
                        //StartCoroutine(InterpolarRotacion3());
                        gira_una3 = false;
                    }

                    textoDado.SetActive(false);
                    animator3.SetBool("moving", false);

                    if(CasillaMinCoco.casilla_minijuego == ""){
                        
                        LetreroNoMinijuego.SetActive(true);
                        if(EscogerPersonaje.character_choosed[2] != 0 || EscogerJugador.four_player){
                            DontDestroy.guardarPosPlayer3 = transform.position;
                            
                            botonPlayerSig.SetActive(true);
                        }

                        if (EscogerPersonaje.character_choosed[2] == 0 && EscogerJugador.four_player == false)
                        {
                            Wait_Siguiente();
                            if(wait_siguiente == false){
                                if (ComunPlayers.espaldas == false) //Si está mirando a camara
                                {
                                    Debug.Log("IA");
                                    transform.Rotate(Vector3.up, -180f);
                                    ComunPlayers.espaldas = true;
                                }
                                DontDestroy.guardarPosPlayer3 = transform.position;
                                DontDestroy.guardarRotacionPlayer3 = transform.rotation;
                                CambiarPlayer.TurnoPlayer3 = false;

                                botonSiguiente.SiguientePlayer();
                                wait_siguiente = true;
                                aux_siguiente = 0f;
                            }
                        }

                    }
                    else if(CasillaMinCoco.casilla_minijuego != "CASILLA_FINAL"){

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
                        if(EscogerPersonaje.character_choosed[2] != 0 || EscogerJugador.four_player){
                            DontDestroy.guardarPosPlayer3 = transform.position;
                            
                            botonMinijuego.SetActive(true);
                        }
                        if (EscogerPersonaje.character_choosed[2] == 0 && EscogerJugador.four_player == false)
                        {
                            Wait_LoseWin();
                            if(wait_LW == false){
                                LetreroMinijuego.SetActive(false);
                                
                                ComunPlayers.ganar_perder = ComunPlayers.juegaIA();
     
                                if(ComunPlayers.ganar_perder == 0 && ComunPlayers.una_por_turno == false){
                                    cartelLoseIA.text= "Cheese lose the minigame!";
                                    panelIALose.SetActive(true);
                                    
                                    Wait_Siguiente();
                                    if(wait_siguiente == false){
                                        CambiarPlayer.TurnoPlayer3 = false;
                                        ComunPlayers.pierdeTurnoplayer3 = true;
                                        ComunPlayers.una_por_turno = true;
                                        if (ComunPlayers.espaldas == false) //Si está mirando a camara
                                        {
                                            Debug.Log("IA");
                                            transform.Rotate(Vector3.up, -180f);
                                            ComunPlayers.espaldas = true;
                                        }
                                        DontDestroy.guardarPosPlayer3 = transform.position;
                                        DontDestroy.guardarRotacionPlayer3 = transform.rotation;
            
            
                                        botonSiguiente.SiguientePlayer();
                                        panelIALose.SetActive(false);
                                        wait_siguiente = true;
                                        aux_siguiente = 0f;
                                        wait_LW = true;
                                        aux_LW = 0f;
                                    }
                                }
                                if(ComunPlayers.ganar_perder != 0 && ComunPlayers.una_por_turno == false){
                                    cartelWinIA.text = "Cheese wins the minigame!";
                                    panelIAWin.SetActive(true);
                                    Wait_Siguiente();
                                    if(wait_siguiente == false ){
                                        CambiarPlayer.TurnoPlayer3 = false;
                                        if (ComunPlayers.espaldas == false) //Si está mirando a camara
                                        {
                                            Debug.Log("IA");
                                            transform.Rotate(Vector3.up, -180f);
                                            ComunPlayers.espaldas = true;
                                        }
                                        DontDestroy.guardarPosPlayer3 = transform.position;
                                        DontDestroy.guardarRotacionPlayer3 = transform.rotation;
 

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
                        if(CasillaMinCoco.casilla_minijuego == "CASILLA_FINAL"){
                            if (ComunPlayers.espaldas == false) //Si está mirando a camara
                            {
                                Debug.Log("IA");
                                transform.Rotate(Vector3.up, -180f);
                                ComunPlayers.espaldas = true;
                            }
                            if(EscogerPersonaje.character_choosed[2] != 0 || EscogerJugador.four_player){

                                cartelFinal.text = "PLAYER" + EscogerPersonaje.character_choosed[2].ToString() + "WIN!! CONGRATULATIONS";
                                cartelFinal2.text = "PLAYER " + EscogerPersonaje.character_choosed[2].ToString() + "WIN!! CONGRATULATIONS";
                                
                            }
                            if (EscogerPersonaje.character_choosed[2] == 0 && EscogerJugador.four_player == false)
                            {
                                cartelFinal.text = "CHEESE WIN!! CONGRATULATIONS";
                                cartelFinal2.text = "CHEESE WIN!! CONGRATULATIONS";
                            }
                        }

                    }
                    
                }   

            }
            
        }

    }


    IEnumerator InterpolarRotacion3(){
        if (ComunPlayers.espaldas == false)
        {
            float _tiempotrans = 0f;
            float animTime = 2f;
            Debug.Log("interpolacion");
            Quaternion rotacionDeseada = Quaternion.Euler(transform.eulerAngles.x, transform.eulerAngles.y + 180f, transform.eulerAngles.z);

            float _ratio = 0;
            while (_tiempotrans < animTime)
            {

                _tiempotrans += Time.deltaTime;
                _ratio = _tiempotrans / animTime;

                transform.rotation = Quaternion.Lerp(transform.rotation, rotacionDeseada, _ratio);

                yield return new WaitForSeconds(1f / 60f);

                _tiempotrans += 1f / 60f;
            }

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
