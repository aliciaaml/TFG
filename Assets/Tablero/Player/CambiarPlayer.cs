using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Cinemachine;

public class CambiarPlayer : MonoBehaviour
{
    [SerializeField] CinemachineVirtualCamera player1Camera;
    [SerializeField] CinemachineVirtualCamera player2Camera;
    [SerializeField] CinemachineVirtualCamera player3Camera;
    [SerializeField] CinemachineVirtualCamera player4Camera;
    [SerializeField] CinemachineVirtualCamera CameraTodos;

    string player;

    public static bool TurnoPlayer1 = false;
    public static bool TurnoPlayer2 = false;
    public static bool TurnoPlayer3 = false;
    public static bool TurnoPlayer4 = false;


/*
    public Transform player;

    public List<Transform> players;

    public static int currentPlayerIndex;

*/
    // Start is called before the first frame update
    void Start()
    {
        /*
        if(player == null && players.Count >= 1 ){          //EMPIEZA EN EL PLAYER 1

            player = players[0];
        }
        */
    }

    private void OnEnable(){

        CameraSwitcher.Register(player1Camera);
        CameraSwitcher.Register(player2Camera);
        CameraSwitcher.Register(player3Camera);
        CameraSwitcher.Register(player4Camera);
        CameraSwitcher.Register(CameraTodos);

        CameraSwitcher.SwitchCamera(CameraTodos); // AQUI SE PONDRA LA CAMARA EN LA QUE SE VE A TODOS LOS PERSONAJES
        TurnoPlayer1 = true;                        // AQUÍ SE PONDRA EL TURNO DEL JUGADOR QUE EMPIEZA
    }

    private void OnDisable(){

        CameraSwitcher.Unregister(player1Camera);
        CameraSwitcher.Unregister(player2Camera);
        CameraSwitcher.Unregister(player3Camera);
        CameraSwitcher.Unregister(player4Camera);
        CameraSwitcher.Unregister(CameraTodos);
    }

    // Update is called once per frame
    void Update()
    {

        if(ComunPlayers.siguiente && ComunPlayers.dic_lleno){


            player = ComunPlayers.OrdenInicioPlayers[ComunPlayers.index];

            colisionPlayer.actual = ComunPlayers.PosicionActualPlayers[player];
            Debug.Log("ACTUAL DEL PLAYER: " + colisionPlayer.actual);
            if(colisionPlayer.actual==0){
                ComunPlayers.Inicio = true;
            }

            if(CameraSwitcher.IsActiveCamera(CameraTodos)){

                if(player == "player1"){

                    CameraSwitcher.SwitchCamera(player1Camera);
                    TurnoPlayer1 = true;

                }

                else if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                    TurnoPlayer2 = true;

                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);

                    TurnoPlayer3 = true;
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                    TurnoPlayer4 = true;
                }
            }

            else if(CameraSwitcher.IsActiveCamera(player1Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                    TurnoPlayer1 = false;
                    TurnoPlayer2 = true;
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                    TurnoPlayer1 = false;
                    TurnoPlayer3 = true;
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                    TurnoPlayer1 = false;
                    TurnoPlayer4 = true;
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player2Camera)){

                if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                    TurnoPlayer1 = true;
                    TurnoPlayer2 = false;
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                    TurnoPlayer3 = true;
                    TurnoPlayer2 = false;
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                    TurnoPlayer4 = true;
                    TurnoPlayer2 = false;
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player3Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                    TurnoPlayer2 = true;
                    TurnoPlayer3 = false;
                }
                else if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                    TurnoPlayer1 = true;
                    TurnoPlayer3 = false;
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                    TurnoPlayer4 = true;
                    TurnoPlayer3 = false;
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player4Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                    TurnoPlayer2 = true;
                    TurnoPlayer4 = false;
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                    TurnoPlayer3 = true;
                    TurnoPlayer4 = false;
                }
                else if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                    TurnoPlayer1 = true;
                    TurnoPlayer4 = false;
                }
            }

            ComunPlayers.siguiente = false;
            ComunPlayers.comienza_turno = true;
        }
        /*
        if(Player.tirada_terminada)
        {
            if(currentPlayerIndex != 3)
                currentPlayerIndex++;

            else if(currentPlayerIndex == 3)
                currentPlayerIndex = 0;

            Swap();

            gameManager.ActivarEstado(MaquinaEstados.Estado.TurnoNuevo);
        }
        */
    }

/*
    public void Swap()
    {
    
        player = players[currentPlayerIndex];

        player.GetComponent<Player>().enabled = true;
        player.GetComponent<NavMeshController>().enabled = true;

        for(int i = 0; i< players.Count; i++) 
        {
            if(players[i]!= player){

                players[i].GetComponent<Player>().enabled = false;

                players[i].GetComponent<NavMeshController>().enabled = false;
            }
        }

    }

    */
}
