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
                heart3.gameObject.SetActive(false);
                break;
            case 2:
                heart2.gameObject.SetActive(false);
                break;
            case 3:
                heart1.gameObject.SetActive(false);
                break;
        }
    }
}
