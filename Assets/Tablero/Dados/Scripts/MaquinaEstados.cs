using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MaquinaEstados : MonoBehaviour
{
    public enum Estado
    {

        TirarUnDado,
        TirarDobleDado,
        TirarDosVeces,
        TurnoNuevo



    }

    public Estado estadoInicial;
    public Estado estadoActual;

    void Start()
    {
        estadoActual = estadoInicial ;
    }
}
