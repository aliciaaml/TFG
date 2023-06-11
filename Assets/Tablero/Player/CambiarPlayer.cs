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

    string player;


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

        CameraSwitcher.SwitchCamera(player1Camera); // AQUI SE PONDRA LA CAMARA EN LA QUE SE VE A TODOS LOS PERSONAJES

    }

    private void OnDisable(){

        CameraSwitcher.Unregister(player1Camera);
        CameraSwitcher.Unregister(player2Camera);
        CameraSwitcher.Unregister(player3Camera);
        CameraSwitcher.Unregister(player4Camera);
    }

    // Update is called once per frame
    void Update()
    {

        if(MovementPlayer.siguiente){

            MovementPlayer.siguiente = false;
            MovementPlayer.comienza_turno = true;

            player = MovementPlayer.OrdenInicioPlayers[MovementPlayer.index];

            colisionPlayer.actual = MovementPlayer.PosicionActualPlayers[player];

            if(CameraSwitcher.IsActiveCamera(player1Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player2Camera)){

                if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player3Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                }
                else if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                }
                else if(player == "player4"){
                    CameraSwitcher.SwitchCamera(player4Camera);
                }
            }
            else if(CameraSwitcher.IsActiveCamera(player4Camera)){

                if(player == "player2"){
                    CameraSwitcher.SwitchCamera(player2Camera);
                }
                else if(player == "player3"){
                    CameraSwitcher.SwitchCamera(player3Camera);
                }
                else if(player == "player1"){
                    CameraSwitcher.SwitchCamera(player1Camera);
                }
            }
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
