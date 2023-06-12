using System.Collections;
using System.Collections.Generic;
using UnityEngine;



public class ComunPlayers : MonoBehaviour
{
    public static int casilla_destino= 2;

    public static Dictionary<string, int> PosicionActualPlayers= new Dictionary<string,int>();

    public static float tolerance = 1.0f;

    [SerializeField] List<Transform> waypoints_todos = new List<Transform>();
    public static List<Transform> waypoints_recorrer = new List<Transform>();

    public static List<string> OrdenInicioPlayers = new List<string>(){

        "player1","player2","player3","player4"     //SE CAMBIA POR EL ORDEN ESTABLECIDO POR LOS DADOS
    };

    
    public static bool comienza_turno = true;
    public static bool Inicio = true;
    public static bool siguiente = false;

    public static int index = 0;

    public static bool primeraRonda = true;

    public static bool dic_lleno = false;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(primeraRonda && siguiente){

            PosicionActualPlayers.Add(OrdenInicioPlayers[0], colisionPlayer.actual);
            for(int i = 1; i<OrdenInicioPlayers.Count; i++ ){

                colisionPlayer.actual = 0;
                PosicionActualPlayers.Add(OrdenInicioPlayers[i], colisionPlayer.actual);
            }
            primeraRonda = false;

            dic_lleno = true;

        }
        
    }

    
    public List<Transform> GetWaypointsRecorrer()
    {
        List<Transform> recorrer = new List<Transform>();

        if (casilla_destino >= 0 && casilla_destino < waypoints_todos.Count)
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
