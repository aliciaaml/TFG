using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Elegir_quien_pez : MonoBehaviour
{

    public static int range;

    // Start is called before the first frame update
    void Start()
    {

        range = Random.Range(0,4);
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(range);
    }
}
