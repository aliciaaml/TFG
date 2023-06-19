using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class brillo_aux : MonoBehaviour
{
    public Image panelBrillo_aux;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {   
        panelBrillo_aux.color = new Color(panelBrillo_aux.color.r,panelBrillo_aux.color.g,panelBrillo_aux.color.b,Brillo.sliderValue);
    }
}
