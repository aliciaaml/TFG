using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PantallaCompleta2 : MonoBehaviour
{
    public Toggle toggle2;
    // Start is called before the first frame update
    void Start()
    {
        if(Screen.fullScreen)
        {
            toggle2.isOn = true;
        }
        else if (toggle2 != null){
            toggle2.isOn = false;
        }
    }

    public void ActivarPantallaCompleta2(bool pantallaCompleta){

        Screen.fullScreen = pantallaCompleta;
    }
}
