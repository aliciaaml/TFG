using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoco : MonoBehaviour
{
    public float velocidad = 5f;
    public static bool golpeado = false;
    public static int contador=0;

    public GameObject lose;
    public GameObject explicacion;
    public GameObject generadorCocos;
    public GameObject generadorCocos2;

    void Update()
    {
        if(contador>=3){

            golpeado = true;

        }

        if(!golpeado){//contador<3 para tener 3 oportunidades
            float movimientoHorizontal = Input.GetAxis("Horizontal");
            transform.Translate(Vector2.right * movimientoHorizontal * velocidad * Time.deltaTime);
        }
        else if(contador>=3){

            TimerCoco.enMarcha = false;
            
            lose.SetActive(true);
            explicacion.SetActive(false);
            generadorCocos.SetActive(false);
            generadorCocos2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("coco") && !golpeado){
            Debug.Log("Te ha golpeado un coco!");

            contador +=1; 

            Destroy(other);
        }
    }
}
