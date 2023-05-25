using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public MaquinaEstados maquina;

    void Start()
    {
        maquina = GetComponent<MaquinaEstados>();
    }


    public void ActivarEstado(MaquinaEstados.Estado estado)
    {
        maquina.estadoActual = estado;
        
    }
}
