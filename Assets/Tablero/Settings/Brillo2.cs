using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Brillo2 : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public static float slider2Value;
    public Image panelBrillo;

    // Start is called before the first frame update
    void Start()
    {
        slider2.value = slider1.value;
        panelBrillo.color = new Color(panelBrillo.color.r,panelBrillo.color.g,panelBrillo.color.b,slider2.value);
    }

    public void ChangeSlider2(float valor){

        slider2Value = valor;
        PlayerPrefs.SetFloat("brillo",slider2Value);
        panelBrillo.color = new Color(panelBrillo.color.r,panelBrillo.color.g,panelBrillo.color.b,slider2.value);
    }
}
