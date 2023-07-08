using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerCoco : MonoBehaviour
{
    public float velocidad = 5f;
    public static bool golpeado = true;
    public static int contador=3;

    public GameObject lose;
    public GameObject corazon;
    public GameObject generadorCocos;
    public GameObject generadorCocos2;

    float aux_coco = 0f;

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
            corazon.SetActive(false);
            lose.SetActive(true);
            generadorCocos.SetActive(false);
            generadorCocos2.SetActive(false);
        }
    }

    private void OnTriggerEnter2D(Collider2D other){
        if(other.CompareTag("coco") && !golpeado){
            Destroy(other.gameObject);
            Wait_coco();
        }
    }

    void Wait_coco(){
        aux_coco+= 1*Time.deltaTime;
        if(aux_coco >= 0.02f) contador +=1; 
    }
}
