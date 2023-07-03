using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LoadCharacter : MonoBehaviour
{
    bool una_vez = false;

    public GameObject canvas_dado;
    public GameObject canvas_inicio;

    private DontDestroy dontDestroy;

    public static bool IA;
    public static bool PERSONA;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        if(una_vez == false){

            for(int i= 0; i<EscogerPersonaje.character_choosed.Count; i++ ){

                Debug.Log("LISTA: " + EscogerPersonaje.character_choosed[i]);
            }
            una_vez = true;
        }

        if(EscogerPersonaje.juegoComenzar){

            canvas_dado.SetActive(true);
            canvas_inicio.SetActive(false);   
        }



        
    }
}
