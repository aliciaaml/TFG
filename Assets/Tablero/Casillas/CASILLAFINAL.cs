using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CASILLAFINAL : MonoBehaviour
{
    public GameObject pantallaFinal;
    public GameObject dado;
    public GameObject textoPlayer;
    public GameObject setings;
    public GameObject textoDados;
    private void OnTriggerEnter(Collider other)
    {
        pantallaFinal.SetActive(true);
        dado.SetActive(false);
        textoPlayer.SetActive(false);
        setings.SetActive(false);
        textoDados.SetActive(false);

        CasillaMinCoco.casilla_minijuego = "CASILLA_FINAL";
        

    }

}
