using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class lives_tiburones : MonoBehaviour
{
    public GameObject heart1,heart2,heart3,heart4,heart5;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        switch(PlayerTiburones.contador_tiburones){

            case 1:
                heart5.gameObject.SetActive(false);
                heart4.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                break;
            case 2:
                heart5.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart3.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                break;
            case 3:
                heart5.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(true);
                heart1.gameObject.SetActive(true);
                break;
            case 4:
                heart5.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart1.gameObject.SetActive(true);
                break;
            case 5: 
                heart5.gameObject.SetActive(false);
                heart4.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart1.gameObject.SetActive(false);
                break;
        }
    }
}
