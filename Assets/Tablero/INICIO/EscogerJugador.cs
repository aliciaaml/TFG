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

    }

    public void TwoPlayer(){

        SceneManager.LoadScene("ChoosePlayers");
        two_player = true;

    }

    public void ThreePlayer(){

        SceneManager.LoadScene("ChoosePlayers");
        three_player = true;
    }

    public void FourPlayer(){

        SceneManager.LoadScene("Terreno");
        four_player = true;
        EscogerPersonaje.juegoComenzar = true;

    }

    public void Back (){

        SceneManager.LoadScene("Terreno");
        EscogerPersonaje.juegoComenzar = false;
    }

}
