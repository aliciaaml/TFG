using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour
{
    public GameObject canvas_juego;
    public GameObject[] player;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_Start(){

        PlayerWin.mover = true;
        canvas_juego.SetActive(true);
        gameObject.SetActive(false);

        if(CasillaColision.player == "player1"){

            player[0].SetActive(true);
        }
        else if(CasillaColision.player == "player2"){
            player[1].SetActive(true);
        }
        else if(CasillaColision.player == "player3"){

            player[2].SetActive(true);
        }
        else if(CasillaColision.player == "player4"){
            
            player[3].SetActive(true);
        }

    }
}
