using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EscogerJugador : MonoBehaviour
{
    public static bool one_player = false;
    public static bool two_player = false;
    public static bool three_player = false;
    public static bool four_player = false;

    public void OnePlayer(){

        SceneManager.LoadScene("ChoosePlayers");
        one_player = true;
        two_player = false;
        three_player = false;
        four_player = false;

    }

    public void TwoPlayer(){

        SceneManager.LoadScene("ChoosePlayers");
        two_player = true;
        one_player = false;
        three_player = false;
        four_player = false;

    }

    public void ThreePlayer(){

        SceneManager.LoadScene("ChoosePlayers");
        three_player = true;
        two_player = false;
        one_player = false;
        four_player = false;
    }

    public void FourPlayer(){

        SceneManager.LoadScene("Terreno");
        four_player = true;
        two_player = false;
        three_player = false;
        one_player = false;
        EscogerPersonaje.juegoComenzar = true;

    }

    public void Back (){

        SceneManager.LoadScene("Terreno");
        EscogerPersonaje.juegoComenzar = false;

        one_player = false;
        two_player = false;
        three_player = false;
        four_player = false;
    }

}
