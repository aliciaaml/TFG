using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerTiburones : MonoBehaviour
{
    public float velocidad = 5f;
    public Transform puntoInicial;
    private Vector3 PosicionInicial;

    public GameObject lose;
    public static int contador_tiburones = 0;
    public GameObject tiburones;
    public GameObject explicacion;

    bool tiburones_pegado = false;

    void Start()
    {
        PosicionInicial = puntoInicial.position;
    }
    void Update()
    {
        
        if(PlayerWin.mover){

            //movimiento del personaje en vertical y horizontal
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            float movimientoVertical = Input.GetAxis("Vertical");

            Vector3 movimiento = new Vector3(movimientoHorizontal, 0f, 0f);
            transform.Translate(movimiento * velocidad * Time.deltaTime);

            movimiento = new Vector3(0f, movimientoVertical, 0f);
            transform.Translate(movimiento * velocidad * Time.deltaTime);

        }

        if(contador_tiburones>=5){

            lose.SetActive(true);
            explicacion.SetActive(false);
            tiburones.SetActive(false);
            PlayerWin.mover = false;
        }
        if(transform.position == puntoInicial.position && contador_tiburones<6 && tiburones_pegado){
            contador_tiburones+= 1;
            tiburones.SetActive(true);
            tiburones_pegado = false;
            Debug.Log("Ta pegao");
        }

    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("Tiburon") && PlayerWin.mover){
            tiburones_pegado = true;
            tiburones.SetActive(false);
            transform.position = PosicionInicial;
            
            
            
        }
    }
}
