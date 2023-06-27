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
    public GameObject generadorCocos;
    public GameObject generadorCocos2;

    public SpriteRenderer spriteRenderer;
    Sprite nuevoSprite;

    void Start(){

        if(Click_start_coco.start){

            restante = (min*60)+seg;
            enMarcha = true;
        }
            
    }

    // Update is called once per frame
    void Update()
    {
        if(enMarcha){
            restante -= Time.deltaTime;

            if(restante< 1){

                enMarcha = false;
                win.SetActive(true);
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
