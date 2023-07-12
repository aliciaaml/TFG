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

    public List<Transform> waypoints_personaje1;
    public List<Transform> waypoints_personaje2;
    public List<Transform> waypoints_personaje3;
    public List<Transform> waypoints_personaje4;

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
    public GameObject cameraTodos;
    public GameObject texto_turno;
    public static bool no_detect_casilla_minijuego = false;
    public static string waypoint_final = "";
    public static string waypoint_actual= "";
    public static int i = 0 ;

    public static bool pierdeTurnoplayer1 = false;
    public static bool pierdeTurnoplayer2 = false;
    public static bool pierdeTurnoplayer3 = false;
    public static bool pierdeTurnoplayer4 = false;

    public static int ganar_perder;

    public static bool una_por_turno = true;

    public GameObject player1;
    public GameObject player2;
    public GameObject player3;
    public GameObject player4;

    public static Quaternion guardarRotacionAlanteplayer1;
    public static Quaternion guardarRotacionAlanteplayer2;
    public static Quaternion guardarRotacionAlanteplayer3;
    public static Quaternion guardarRotacionAlanteplayer4;

    public static bool espaldas = true;
    
    private void Start()
    {
    
    }
    void Update()
    {   
        if(primeraRonda && siguiente){
            

            primeraRonda =false;
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
            cameraTodos.SetActive(false);
            texto_turno.SetActive(true);
            LoadTablero.minijuego = false;
        }
    }

    public List<Transform> GetWaypointsRecorrer()
    {


        List<Transform> recorrer = new List<Transform>();
        
        if (NumDado.resultado_dado_obtenido)
        {      
            casilla_antes_tirar = colisionPlayer.actual;
            
            if(CambiarPlayer.TurnoPlayer1){
                
                waypoint_actual = "Sphere" + (colisionPlayer.actual).ToString() + " (1)" + " (UnityEngine.Transform)";
                if(ComunPlayers.Inicio){
                    i = 0;
                }
                else{
                    i = GetWaypointActual(waypoint_actual, waypoints_personaje1);
                }
               

                waypoint_final = "Sphere" + (casilla_destino + colisionPlayer.actual).ToString() + " (1)" + " (UnityEngine.Transform)";

                while (i< waypoints_personaje1.Count-1 && waypoints_personaje1[i].ToString() != waypoint_final)
                {
                    
                    recorrer.Add(waypoints_personaje1[i]);
                    i++;
                }
                recorrer.Add(waypoints_personaje1[i]);
                if(i>=waypoints_personaje1.Count-1){
                    i = waypoints_personaje1.Count - 1;
                    recorrer.Add(waypoints_personaje1[i]);
                }
                
            }
            if(CambiarPlayer.TurnoPlayer2){

                waypoint_actual = "Sphere" + (colisionPlayer.actual).ToString() + " (2)" + " (UnityEngine.Transform)";
                
                if(ComunPlayers.Inicio){
                    i = 0;
                }
                else{
                    i = GetWaypointActual(waypoint_actual, waypoints_personaje2);
                }
                waypoint_final = "Sphere" + (casilla_destino + colisionPlayer.actual).ToString() + " (2)" + " (UnityEngine.Transform)";

                while (i<waypoints_personaje2.Count-1 && waypoints_personaje2[i].ToString() != waypoint_final)
                {    
                    recorrer.Add(waypoints_personaje2[i]);
                    i++;
                }
                recorrer.Add(waypoints_personaje2[i]);
                if(i>=waypoints_personaje2.Count-1){
                    i = waypoints_personaje2.Count - 1;
                    recorrer.Add(waypoints_personaje2[i]);
                }

            }
            if(CambiarPlayer.TurnoPlayer3){

                waypoint_actual = "Sphere" + (colisionPlayer.actual).ToString() + " (3)" + " (UnityEngine.Transform)";
                if(ComunPlayers.Inicio){
                    i = 0;
                }
                else{
                    i = GetWaypointActual(waypoint_actual, waypoints_personaje3);
                }
                waypoint_final = "Sphere" + (casilla_destino + colisionPlayer.actual).ToString() + " (3)" + " (UnityEngine.Transform)";
                while (i<waypoints_personaje3.Count-1 && waypoints_personaje3[i].ToString() != waypoint_final)
                {
                    
                    recorrer.Add(waypoints_personaje3[i]);
                    i++;
                }
                recorrer.Add(waypoints_personaje3[i]);
                if(i>=waypoints_personaje3.Count-1){
                    i = waypoints_personaje3.Count - 1;
                    recorrer.Add(waypoints_personaje3[i]);
                }
            }
            if(CambiarPlayer.TurnoPlayer4){

                waypoint_actual = "Sphere" + (colisionPlayer.actual).ToString() + " (4)" + " (UnityEngine.Transform)";

                if(ComunPlayers.Inicio){
                    i = 0;
                }
                else{
                    i = GetWaypointActual(waypoint_actual, waypoints_personaje4);
                }
                waypoint_final = "Sphere" + (casilla_destino + colisionPlayer.actual).ToString() + " (4)" + " (UnityEngine.Transform)";
                while (i<waypoints_personaje4.Count-1 && waypoints_personaje4[i].ToString() != waypoint_final)
                {                   
                    recorrer.Add(waypoints_personaje4[i]);
                    i++;
                }
                recorrer.Add(waypoints_personaje4[i]);
                if(i>=waypoints_personaje4.Count-1){
                    i = waypoints_personaje4.Count - 1;
                    recorrer.Add(waypoints_personaje4[i]);
                }
                
            }
        }
        return recorrer;
        
    }
    

    public static void ActualizarPosicionPlayer(){
        if(PosicionActualPlayers.Count==4){
            //PosicionActualPlayers[index][1].numero = colisionPlayer.actual;
            ElementoLista elemento = PosicionActualPlayers[index][0].Copy();
            // Modificar la propiedad deseada en la copia
            elemento.numero = colisionPlayer.actual;
            // Asignar la copia modificada de nuevo a la lista interna
            PosicionActualPlayers[index][0] = elemento;
        }
    }

    public int GetWaypointActual(string actual, List<Transform> waypoints_personaje){

        for(int i = 0; i<waypoints_personaje.Count; i++){
            
            if(waypoints_personaje[i].ToString() == actual){
                return i;
            }  
        }
        return -1;
    }

    public static int juegaIA(){
        if(una_por_turno){
            ganar_perder = Random.Range(0, 2);
            una_por_turno = false;
        }
        
        return ganar_perder;
    }
}
