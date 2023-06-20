using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;


public class DialogControler : MonoBehaviour
{
    public static List<string> dialogs = new List<string>();

    public TextMeshProUGUI dialog_text;

    int i = 0;

    public GameObject DialgosFuera;
    public GameObject dado;
    public GameObject TurnoJugador;

    public static bool dialog_terminado = false;

    // Start is called before the first frame update
    void Start()
    {
        Dialogos();
    }

    public void ChangeDialog(){

        if(i<dialogs.Count){

            dialog_text.text = dialogs[i];

            i+=1;
        }
        else{

            DialgosFuera.SetActive(false);
            dado.SetActive(true);
            TurnoJugador.SetActive(true);
            dialog_terminado = true;

        }
        
    }

    void Dialogos(){

        dialogs.Add("Before we start, let me explain the rules of this game.");
        dialogs.Add("Each player must move through the different squares until reaching the final goal. The first to arrive will be crowned as the victorious champion!");
        dialogs.Add("However, the path to the goal won't be so simple, as some squares hide challenging mini-games. If you fail to overcome them, you will lose a turn in the next round.");
        dialogs.Add("But don't be discouraged, you will also come across strategic aids: from the chance to roll the dice again to a valuable double dice that you can use in future turns.");
        dialogs.Add("To determine the starting order, each player will trough the dice, and the one who obtains the highest number will be the first to start. Next, the player who obtains the next highest number, and so on, until the starting order is complete.");
        dialogs.Add("I wish you good luck and may you enjoy the game to the fullest! Let's play!");
    }
}
