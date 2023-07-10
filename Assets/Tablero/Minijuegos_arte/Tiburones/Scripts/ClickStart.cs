using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStart : MonoBehaviour
{
    public GameObject canvas_juego;
    public GameObject[] player;

    public static bool juegaplayer1 = false;
    public static bool juegaplayer2 = false;
    public static bool juegaplayer3 = false;
    public static bool juegaplayer4 = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Click_Start(){
        PlayerTiburones.contador_tiburones = 0;
        PlayerWin.mover = true;
        canvas_juego.SetActive(true);
        gameObject.SetActive(false);

        if(CasillaMinCoco.player == "player1"){

            player[0].SetActive(true);
            juegaplayer1 = true;
            juegaplayer2 = false;
            juegaplayer3 = false;
            juegaplayer4 = false;

        }
        else if(CasillaMinCoco.player == "player2"){
            player[1].SetActive(true);
            juegaplayer1 = false;
            juegaplayer2 = true;
            juegaplayer3 = false;
            juegaplayer4 = false;
        }
        else if(CasillaMinCoco.player == "player3"){

            player[2].SetActive(true);
            juegaplayer1 = false;
            juegaplayer2 = false;
            juegaplayer3 = true;
            juegaplayer4 = false;
        }
        else if(CasillaMinCoco.player == "player4"){
            
            player[3].SetActive(true);
            juegaplayer1 = false;
            juegaplayer2 = false;
            juegaplayer3 = false;
            juegaplayer4 = true;
        }

    }
}
