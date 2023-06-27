using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerWin : MonoBehaviour
{
    public GameObject tiburones;

    public static bool mover = false;

    public GameObject fondo_corazones;
    public GameObject win;

    void Start()
    {
        //rb = GetComponent<Rigidbody>();
    }


    // Update is called once per frame
    void Update()
    {
        
    }

    void OnCollisionEnter2D(Collision2D colision){

        if(colision.gameObject.tag == "Player"){

            tiburones.SetActive(false);
            mover =false;
            fondo_corazones.SetActive(false);
            win.SetActive(true);

        }
    }
}
