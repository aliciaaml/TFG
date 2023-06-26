using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CasillaColision : MonoBehaviour
{
    public static string player= "";

    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag == "player1"){

            player = "player1";
            Debug.Log("1");
            SceneManager.LoadScene("Cocos");
        }
        else if(other.gameObject.tag == "player2"){
            player = "player2";
            Debug.Log("2");
            SceneManager.LoadScene("Cocos");

        }
        else if(other.gameObject.tag== "player3"){

            player = "player3";
            Debug.Log("3");
            SceneManager.LoadScene("Cocos");

        }
        else{

            player = "player4";
            Debug.Log("4");
            SceneManager.LoadScene("Cocos");
        }
         

    }
}
