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

    bool uno = true;


    private void OnEnable(){

        CameraSwitcher.Register(player1Camera);
        CameraSwitcher.Register(player2Camera);
        CameraSwitcher.Register(player3Camera);
        CameraSwitcher.Register(player4Camera);
        CameraSwitcher.Register(CameraTodos);

        CameraSwitcher.SwitchCamera(CameraTodos);


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
        // PRIMER JUGADOR EN SALIR //

        if(ElegirPosiciones.ElegirTurnoTerminado && uno){
            uno = false;

            if(ComunPlayers.OrdenInicioPlayers[0] == "player1"){

                TurnoPlayer1 = true;
                CameraSwitcher.SwitchCamera(player1Camera);
            }
            else if(ComunPlayers.OrdenInicioPlayers[0] == "player2"){
                TurnoPlayer2 = true;
                CameraSwitcher.SwitchCamera(player2Camera);
            }
            else if(ComunPlayers.OrdenInicioPlayers[0] == "player3"){
                TurnoPlayer3 = true;
                CameraSwitcher.SwitchCamera(player3Camera);
            }
            else{
                TurnoPlayer4 = true;
                CameraSwitcher.SwitchCamera(player4Camera);
            }
        }
        //Debug.Log("ENTRANDOOO: " + ComunPlayers.PosicionActualPlayers.Count );
        if(ComunPlayers.siguiente && ComunPlayers.dic_lleno && ComunPlayers.PosicionActualPlayers.Count == 4){

            Debug.Log("index: " + ComunPlayers.index );

            player = ComunPlayers.OrdenInicioPlayers[ComunPlayers.index];

            
            
            colisionPlayer.actual = ComunPlayers.PosicionActualPlayers[ComunPlayers.index][0].numero;

            Debug.Log("Posicion Actual: " + ComunPlayers.PosicionActualPlayers[ComunPlayers.index][0].numero);
            //Debug.Log("ACTUAL DEL PLAYER: " + colisionPlayer.actual);
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
    }
}
