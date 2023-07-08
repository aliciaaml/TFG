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
        PlayerCoco.golpeado = false;
        start = true;
        canvas_juego.SetActive(true);
        generadorCocos.SetActive(true);
        generadorCocos2.SetActive(true);
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
