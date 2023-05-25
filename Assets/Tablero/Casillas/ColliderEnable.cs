using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderEnable : MonoBehaviour
{

    public static bool collider_casilla = false;
    // Start is called before the first frame update
    void Start()
    {
        Collider collider = GetComponent<Collider>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Num_dado.dado_final){
            
            GetComponent<Collider>().enabled = true;
            collider_casilla = true;
        }
    }
}
