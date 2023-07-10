using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStartCoco : MonoBehaviour
{
    public GameObject canvas_juego;
    public GameObject generadorCocos;
    public GameObject generadorCocos2;

    public GameObject[] player;

    public static bool start = false;

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

    public void clickStartCoco(){
        PlayerCoco.contador = 0;
        PlayerCoco.aux_coco = 0f;
        PlayerCoco.golpeado = false;

        CocoSpawn.tiempoEntreCocos = 1f;
        CocoSpawn.alturaGeneracion = 10f;

        CocoSpawn.temporizador = 0f;

        start = true;
        canvas_juego.SetActive(true);
        generadorCocos.SetActive(true);
        generadorCocos2.SetActive(true);
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
