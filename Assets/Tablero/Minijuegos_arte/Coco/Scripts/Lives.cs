using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lives : MonoBehaviour
{
    public GameObject heart1,heart2,heart3;

    // Update is called once per frame
    void Update(){
        switch(PlayerCoco.contador){
            case 1:
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                break;
            case 3:

                heart3.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                break;
        }
    }
}
