using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Volumen2 : MonoBehaviour
{
    public Slider slider1;
    public Slider slider2;
    public float sliderValue2;

    // Start is called before the first frame update
    void Start()
    {
        
        slider2.value = slider1.value;
        //sliderValue2 = slider1.value;
        AudioListener.volume = slider2.value;

    }

    public void ChangeSlider2(float valor){

        sliderValue2 = valor;
        PlayerPrefs.SetFloat("volumenAudio2",sliderValue2);
        AudioListener.volume = slider2.value;
    }
}
