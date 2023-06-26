using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class TimerCoco : MonoBehaviour
{
    [SerializeField] int min,seg;
    [SerializeField] TextMeshProUGUI tiempo;

    private float restante;
    public static bool enMarcha;

    public GameObject win;
    public GameObject explicacion;
    public GameObject generadorCocos;
    public GameObject generadorCocos2;

    public SpriteRenderer spriteRenderer;
    Sprite nuevoSprite;

    void Awake(){

    
        if(CasillaColision.player == "player1"){

            Debug.Log(CasillaColision.player);
            nuevoSprite = Resources.Load<Sprite>("Minijuegos_arte/fichas/seta");

            spriteRenderer.sprite = nuevoSprite;
        }
        if(CasillaColision.player == "player2"){
            Debug.Log(CasillaColision.player);
            nuevoSprite = Resources.Load<Sprite>("Minijuegos_arte/fichas/rana");

            spriteRenderer.sprite = nuevoSprite;
        }
        if(CasillaColision.player == "player3"){
            Debug.Log(CasillaColision.player);
            nuevoSprite = Resources.Load<Sprite>("Minijuegos_arte/fichas/queso");

            spriteRenderer.sprite = nuevoSprite;
        }
        if(CasillaColision.player == "player4"){
            Debug.Log(CasillaColision.player);
            nuevoSprite = Resources.Load<Sprite>("Minijuegos_arte/fichas/cactus");

            spriteRenderer.sprite = nuevoSprite;
        }

        restante = (min*60)+seg;
        enMarcha = true;
    }

    // Update is called once per frame
    void Update()
    {
        if(enMarcha){
            restante -= Time.deltaTime;

            if(restante< 1){

                enMarcha = false;
                win.SetActive(true);
                explicacion.SetActive(false);
                generadorCocos.SetActive(false);
                generadorCocos2.SetActive(false);
                PlayerCoco.golpeado = true;
            }
            int tempMin = Mathf.FloorToInt(restante/60);
            int tempSeg = Mathf.FloorToInt(restante % 60);
            tiempo.text = string.Format("{00:00}:{01:00}", tempMin, tempSeg);
        }
    }
}
