using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LoadCharacter : MonoBehaviour
{
    public GameObject canvas_dado;
    public GameObject canvas_inicio;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public static Vector3 posInitPlayer1;
    public static Vector3 posInitPlayer2;
    public static Vector3 posInitPlayer3;
    public static Vector3 posInitPlayer4;

    Vector3 cero = new Vector3(0f,0f,0f);
     
    public static bool una_al_salirMinijuego = false;


    // Start is called before the first frame update
    void Start()
    {
       posInitPlayer1 =  player1.transform.position;
       posInitPlayer2 =  player2.transform.position;
       posInitPlayer3 =  player3.transform.position;
       posInitPlayer4 =  player4.transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if((EscogerPersonaje.juegoComenzar && !Replay.replay) || EscogerJugador.four_player){

            canvas_dado.SetActive(true);
            canvas_inicio.SetActive(false);
           
        }
        
        if(LoadTablero.salirMinijuego && una_al_salirMinijuego == false){
            
            una_al_salirMinijuego = true;
            player1.transform.position = DontDestroy.guardarPosPlayer1;
            player2.transform.position = DontDestroy.guardarPosPlayer2;
            player3.transform.position = DontDestroy.guardarPosPlayer3;
            player4.transform.position = DontDestroy.guardarPosPlayer4;
            
            player1.transform.rotation = DontDestroy.guardarRotacionPlayer1;
            player2.transform.rotation = DontDestroy.guardarRotacionPlayer2;
            player3.transform.rotation = DontDestroy.guardarRotacionPlayer3;
            player4.transform.rotation = DontDestroy.guardarRotacionPlayer4;
                
            
        }
        
        if(DontDestroy.guardarPosPlayer1  == cero){
            DontDestroy.guardarPosPlayer1 = player1.transform.position;
            DontDestroy.guardarRotacionPlayer1 = player1.transform.rotation;

        }
        if(DontDestroy.guardarPosPlayer2  == cero){
            DontDestroy.guardarPosPlayer2 = player2.transform.position;
            DontDestroy.guardarRotacionPlayer2 = player2.transform.rotation;
            
        }
        if(DontDestroy.guardarPosPlayer3  == cero){
            DontDestroy.guardarPosPlayer3 = player3.transform.position; 
            DontDestroy.guardarRotacionPlayer3 = player3.transform.rotation;     
        }
        if (DontDestroy.guardarPosPlayer4  == cero){
            DontDestroy.guardarPosPlayer4 = player4.transform.position;
            DontDestroy.guardarRotacionPlayer4 = player4.transform.rotation;
        }

    }
}
