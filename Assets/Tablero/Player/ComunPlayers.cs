using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComunPlayers : MonoBehaviour
{
    public static int casilla_destino;
    public static int casilla_antes_tirar = 0;

    public struct ElementoLista{
        public string texto;
        public int numero;
        public ElementoLista(string texto, int numero)
        {
            this.texto = texto;
            this.numero = numero;
        }
        public ElementoLista Copy()
        {
            return new ElementoLista(texto, numero);
        }
    }

    public static List<List<ElementoLista>> PosicionActualPlayers = new List<List<ElementoLista>>();
    public static float tolerance = 0.5f;
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

    public GameObject dialogo;
    public static bool no_detect_casilla_minijuego = false;

    // Update is called once per frame
    void Update()
    {        
        if(primeraRonda && siguiente){         
            primeraRonda=false;
            List<ElementoLista> sublista1 = new List<ElementoLista>();
            sublista1.Add(new ElementoLista(OrdenInicioPlayers[0], colisionPlayer.actual));
            PosicionActualPlayers.Add(sublista1);;

            for(int i = 1; i<OrdenInicioPlayers.Count; i++ ){
                colisionPlayer.actual = 0;
                List<ElementoLista> sublista2 = new List<ElementoLista>();
                // Agregar elementos a la sublista
                sublista2.Add(new ElementoLista(OrdenInicioPlayers[i], colisionPlayer.actual));
                PosicionActualPlayers.Add(sublista2);  
            }
            dic_lleno = true;
            ActualizarPosicionPlayer();
        }

        if(LoadTablero.minijuego){
            dialogo.SetActive(false);
            LoadTablero.minijuego = false;
        }
        Debug.Log("INDEX" + index);
        Debug.Log("Lista pos actual length: " + PosicionActualPlayers.Count);
        Debug.Log("Pos actual:  " + colisionPlayer.actual);
    }

    public List<Transform> GetWaypointsRecorrer()
    {
        List<Transform> recorrer = new List<Transform>();

        if (casilla_destino > 0 && casilla_destino < waypoints_todos.Count && NumDado.resultado_dado_obtenido)
        {
            if(Inicio){
                casilla_antes_tirar = colisionPlayer.actual;
                for (int i = 0; i < casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                    Debug.Log("waypoints_inicio: " + waypoints_todos[i]);
                }
            }
            else{
                casilla_antes_tirar = colisionPlayer.actual;
                for (int i = colisionPlayer.actual; i < colisionPlayer.actual +  casilla_destino; i++)
                {
                    recorrer.Add(waypoints_todos[i]);
                    Debug.Log("waypoints_despues_inicio: " + waypoints_todos[i]);
                }
            }
        }
        return recorrer;
    }

    public static void ActualizarPosicionPlayer(){
        Debug.Log("AAAAA");
        if(PosicionActualPlayers.Count==4){
            //PosicionActualPlayers[index][1].numero = colisionPlayer.actual;
            ElementoLista elemento = PosicionActualPlayers[index][0].Copy();
            // Modificar la propiedad deseada en la copia
            elemento.numero = colisionPlayer.actual;
            // Asignar la copia modificada de nuevo a la lista interna
            PosicionActualPlayers[index][0] = elemento;
            Debug.Log("Posicion actual players: " + PosicionActualPlayers[index][0]);
        }
    }
}
