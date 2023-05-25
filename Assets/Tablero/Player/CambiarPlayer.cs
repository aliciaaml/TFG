using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CambiarPlayer : MonoBehaviour
{
    [SerializeField] GameManager gameManager;

    public Transform player;

    public List<Transform> players;

    public static int currentPlayerIndex;


    // Start is called before the first frame update
    void Start()
    {
        
        if(player == null && players.Count >= 1 ){          //EMPIEZA EN EL PLAYER 1

            player = players[0];
        }
    }

    // Update is called once per frame
    void Update()
    {

        if(Player.tirada_terminada)
        {
            if(currentPlayerIndex != 3)
                currentPlayerIndex++;

            else if(currentPlayerIndex == 3)
                currentPlayerIndex = 0;

            Swap();

            gameManager.ActivarEstado(MaquinaEstados.Estado.TurnoNuevo);
        }
        
    }

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
}
