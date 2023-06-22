using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ComunPlayers : MonoBehaviour
{
    public static int casilla_destino;
    
    //public static Dictionary<string, int> PosicionActualPlayers= new Dictionary<string,int>();

    public struct ElementoLista
    {
        public string texto;
        public int numero;

        public ElementoLista(string texto, int numero)
        {
            this.texto = texto;
            this.numero = numero;
        }
    }

    public static List<List<ElementoLista>> PosicionActualPlayers = new List<List<ElementoLista>>();

    public static float tolerance = 1.0f;

    [SerializeField] List<Transform> waypoints_todos = new List<Transform>();
    public static List<Transform> waypoints_recorrer = new List<Transform>();

    public static bool IA = false;
    public static bool PERSONA = false;

    public static List<string> OrdenInicioPlayers = new List<string>();

    
    public static bool comienza_turno = true;
    public static bool Inicio = true;
    public static bool siguiente = false;

    public static int index = 0;

    public static bool primeraRonda = false;

    public static bool dic_lleno = false;

    // Update is called once per frame
    void Update()
    {
        //Debug.Log("primeraRonda: " + primeraRonda);
        //Debug.Log("index: " + index );

        if(primeraRonda && siguiente){
            
            primeraRonda=false;
            
            List<ElementoLista> sublista1 = new List<ElementoLista>();
            sublista1.Add(new ElementoLista(OrdenInicioPlayers[0], colisionPlayer.actual));
            PosicionActualPlayers.Add(sublista1);
            //Debug.Log("LISTA PLAYERS: " + PosicionActualPlayers[0][0].texto);

            for(int i = 1; i<4; i++ ){

                colisionPlayer.actual = 0;

                List<ElementoLista> sublista2 = new List<ElementoLista>();
                // Agregar elementos a la sublista
                sublista2.Add(new ElementoLista(OrdenInicioPlayers[i], colisionPlayer.actual));
                PosicionActualPlayers.Add(sublista2);

                //Debug.Log("LISTA PLAYERS: " +  PosicionActualPlayers[i][0].texto);
                
            }

            Debug.Log("CHE: " + ComunPlayers.PosicionActualPlayers.Count );
            dic_lleno = true;

            Debug.Log("dic_lleno: " + dic_lleno);
        }
        
    }

    
    public List<Transform> GetWaypointsRecorrer()
    {
        List<Transform> recorrer = new List<Transform>();

        if (casilla_destino > 0 && casilla_destino < waypoints_todos.Count)
        {
            if(Inicio){

                for (int i = 0; i < casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                }
            }
            else{

                for (int i = colisionPlayer.actual-1; i < casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                }

            }

        }

        return recorrer;
    }
}
