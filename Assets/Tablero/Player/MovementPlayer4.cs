using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using Cinemachine;


public class MovementPlayer4 : MonoBehaviour
{
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

    public float velocidad4 = 15f;

    public BotonSiguiente botonSiguiente;
    public GameObject panelPierdeTurno;
    public GameObject panelPierdeTurnoIA;
    public TextMeshProUGUI pierdeturnoIAtext;
    public TextMeshProUGUI pierdeturnoIAtext2;

    public TextMeshProUGUI cartelWinIA;
    public TextMeshProUGUI cartelLoseIA;
    public GameObject panelIAWin;
    public GameObject panelIALose;
    float aux_LW  = 0f;
    bool wait_LW = true;
    float aux_siguiente = 0f;
    bool wait_siguiente = true;

    bool wait_pasar = true;
    float aux_pasar = 0f;

    void Start()
    {
        animator4 = GetComponent<Animator>();
    }

    void Update()
    {
        if(CambiarPlayer.TurnoPlayer4  && ComunPlayers.pierdeTurnoplayer4){

            if(EscogerPersonaje.character_choosed[3] == 0){
                turno_jugador.text = "Cactus";
                turno_jugador_b.text = "Cactus";

                panelPierdeTurnoIA.SetActive(true);
                pierdeturnoIAtext.text = "Cactus loses turn!!";
                pierdeturnoIAtext2.text = "Cactus loses turn!!";

                Wait_pasar();
                if(wait_pasar == false){
                    panelPierdeTurnoIA.SetActive(false);
                    botonSiguiente.SiguientePlayer();
                    wait_pasar = true;
                    aux_pasar = 0f;
                }
            }
            if (EscogerPersonaje.character_choosed[3] != 0) {
                turno_jugador.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                turno_jugador_b.text = "Player " + EscogerPersonaje.character_choosed[3].ToString();
                panelPierdeTurno.SetActive(true);
            }

            if (EscogerJugador.four_player) { 

                turno_jugador.text = "Player 4";
                turno_jugador_b.text = "Player 4";
                panelPierdeTurno.SetActive(true);
            }

            
        }

        if(CambiarPlayer.TurnoPlayer4  && ComunPlayers.pierdeTurnoplayer4 == false){
            //wait_LW = true;
            //aux_LW = 0f;
            if(ElegirPosiciones.turno_terminado == false){
                textoDado.SetActive(false);
                virtualCamera.Follow = transform;
                virtualCamera.LookAt = transform;

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

                if (ComunPlayers.comienza_turno)
                {
                    gira_una4 = true;
                    ComunPlayers.waypoints_recorrer = comunPlayers.GetWaypointsRecorrer();
                    m_CurrentWaypointIndex4 = 0; // Establecer el índice del waypoint actual en 0
                    ComunPlayers.comienza_turno = false;
                }


                if (transform.position != ComunPlayers.waypoints_recorrer[ComunPlayers.waypoints_recorrer.Count -1].position
                    && m_CurrentWaypointIndex4 < ComunPlayers.waypoints_recorrer.Count)
                {
                    animator4.SetBool("moving", true);
                    Vector3 objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex4].position;
                    float distancia = Vector3.Distance(transform.position, objetivo);

                    if (distancia <= 0.1f)
                    {
                        m_CurrentWaypointIndex4++;
                        if (m_CurrentWaypointIndex4 < ComunPlayers.waypoints_recorrer.Count)
                        {
                            objetivo = ComunPlayers.waypoints_recorrer[m_CurrentWaypointIndex4].position;
                        }
                        else
                        {
                            animator4.SetBool("moving", false); // Detener la animación de movimiento
                            return;
                        }
                    }

                    Vector3 direccion = (objetivo - transform.position).normalized;
                    Quaternion rotacionDeseada = Quaternion.LookRotation(direccion);
                    float velocidadRotacion = 40f; // Ajusta la velocidad de rotación según tus necesidades

                    transform.rotation = Quaternion.RotateTowards(transform.rotation, rotacionDeseada, velocidadRotacion * Time.deltaTime);

                    transform.position += direccion * velocidad4 * Time.deltaTime;
                }

                else
                {
                    virtualCamera.Follow = null;
                    virtualCamera.LookAt = null;
                    
                    if(gira_una4){
                        StartCoroutine(InterpolarRotacion4());
                        gira_una4 = false;
                    }
                  

                    textoDado.SetActive(false);
                    animator4.SetBool("moving", false);

                    if(CasillaMinCoco.casilla_minijuego == ""){
                        
                        LetreroNoMinijuego.SetActive(true);
                        if(EscogerPersonaje.character_choosed[3] != 0){
                            botonPlayerSig.SetActive(true);
                        }
                            
                        else{
                            Wait_Siguiente();
                            if(wait_siguiente == false){
                                
                                transform.Rotate(Vector3.up, -180f);
                                DontDestroy.guardarPosPlayer4 = transform.position;
                                CambiarPlayer.TurnoPlayer4 = false;

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
                        if(EscogerPersonaje.character_choosed[3] != 0){
                            botonMinijuego.SetActive(true);
                        }
                        else{
                            Wait_LoseWin();
                            if(wait_LW == false){
                                LetreroMinijuego.SetActive(false);
                                
                                ComunPlayers.ganar_perder = ComunPlayers.juegaIA();
                                Debug.Log("ComunPlayers.ganar_perder: " + ComunPlayers.ganar_perder);
                                if(ComunPlayers.ganar_perder == 0 && ComunPlayers.una_por_turno ==false){
                                    cartelLoseIA.text= "Cactus loses the minigame!";
                                    panelIALose.SetActive(true);
                                    
                                    Wait_Siguiente();
                                    if(wait_siguiente == false){
                                        CambiarPlayer.TurnoPlayer4 = false;
                                        ComunPlayers.pierdeTurnoplayer4 = true;
                                        ComunPlayers.una_por_turno = true;

                                        transform.Rotate(Vector3.up, -180f);
                                        DontDestroy.guardarPosPlayer4 = transform.position;
            
            
                                        botonSiguiente.SiguientePlayer();
                                        panelIALose.SetActive(false);
                                        wait_siguiente = true;
                                        aux_siguiente = 0f;
                                        wait_LW = true;
                                        aux_LW = 0f;
                                    }
                                }
                                
                                if(ComunPlayers.ganar_perder != 0 && ComunPlayers.una_por_turno ==false){
                                    cartelWinIA.text = "Cactus wins the minigame!";
                                    panelIAWin.SetActive(true);
                                    Wait_Siguiente();
                                    if(wait_siguiente == false && ComunPlayers.una_por_turno){
                                        CambiarPlayer.TurnoPlayer4 = false;

                                        transform.Rotate(Vector3.up, -180f);
                                        DontDestroy.guardarPosPlayer4 = transform.position;
 

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

    IEnumerator InterpolarRotacion4(){
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

        if(aux_pasar >= 2f) wait_pasar= false;
    }
}
