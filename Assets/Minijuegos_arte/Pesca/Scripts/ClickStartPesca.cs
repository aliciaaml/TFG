using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ClickStartPesca : MonoBehaviour
{
    public GameObject canvas_juego;
    public GameObject[] player;
    public GameObject canas;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void clickStartPesca(){
        ClickCana0.contador = 3;
        ElegirQuienPez.range = Random.Range(0,4);
        MovimientoAleatorioCana.startingTime = Random.Range(1f,5f);
        MovimientoAleatorioCana.currentTime = MovimientoAleatorioCana.startingTime;
        MovimientoAleatorioCana.aux = 0f;

        ClickCana0.aux_pesca = 0f;
        ClickCana0.aux_pesca2 = 0f;
        ClickCana0.wait_pesca = true;
        ClickCana0.wait_pesca2 = true;
        ClickCana0.gana = false;
        ClickCana0.pierde = false;
        ClickCana0.mouse_fuera = true;

        ClickCana1.gana = false;
        ClickCana1.pierde = false;
        ClickCana1.mouse_fuera = true;

        ClickCana2.gana = false;
        ClickCana2.pierde = false;
        ClickCana2.mouse_fuera = true;

        ClickCana3.gana = false;
        ClickCana3.pierde = false;
        ClickCana3.mouse_fuera = true;



        canas.SetActive(true);
        canvas_juego.SetActive(true);
        gameObject.SetActive(false);

        if(CasillaMinCoco.player == "player1"){

            player[0].SetActive(true);
        }
        else if(CasillaMinCoco.player == "player2"){
            player[1].SetActive(true);
        }
        else if(CasillaMinCoco.player == "player3"){

            player[2].SetActive(true);
        }
        else if(CasillaMinCoco.player == "player4"){
            
            player[3].SetActive(true);
        }

    }
}
