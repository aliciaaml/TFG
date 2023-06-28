using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class Tries : MonoBehaviour
{
    [SerializeField] TextMeshProUGUI tries;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        tries.text = "Tries: " + ClickCana0.contador;
    }
}
