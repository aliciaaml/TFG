using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class BotonMinijuego : MonoBehaviour
{
    public BotonSiguiente ScriptBotonSiguiente;
    public GameObject LetreroMinijuego;
    public GameObject botonMinijuego;

    public void f_IrMinijuego(){

        LetreroMinijuego.SetActive(false);
        botonMinijuego.SetActive(false);

        ScriptBotonSiguiente.SiguientePlayer();

        if(CasillaMinCoco.casilla_minijuego == "juego_pesca"){

            SceneManager.LoadScene("Minijuego_pesca");
        }
        if(CasillaMinCoco.casilla_minijuego == "juego_cocos"){
            SceneManager.LoadScene("Cocos");
        }
        if(CasillaMinCoco.casilla_minijuego == "juego_tiburones"){
            SceneManager.LoadScene("tiburones");
        }

    }
}
