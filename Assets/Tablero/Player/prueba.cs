using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class prueba : MonoBehaviour
{

    public struct ElementoLista1
    {
        public string texto;
        public int numero;

        public ElementoLista1(string texto, int numero)
        {
            this.texto = texto;
            this.numero = numero;
        }
    }

    public static List<List<ElementoLista1>> PosicionActualPlayers1 = new List<List<ElementoLista1>>();

    bool una = true;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(una && ElegirPosiciones. ElegirTurnoTerminado){

            for(int i = 0; i<4; i++ ){
                
                colisionPlayer.actual = 0;

                List<ElementoLista1> sublista = new List<ElementoLista1>();
                sublista.Add(new ElementoLista1(ComunPlayers.OrdenInicioPlayers[i], colisionPlayer.actual));
                PosicionActualPlayers1.Add(sublista);

                Debug.Log("LISTA PLAYERS: " +  PosicionActualPlayers1[i][0].texto);
                
            }

            ComunPlayers.dic_lleno = true;

            una = false;
            Debug.Log("CHE: " + PosicionActualPlayers1.Count );
        }
        
        
    }
}
