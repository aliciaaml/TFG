using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class detectDados : MonoBehaviour
{
    public Animator animator; // Referencia al componente Animator
    public Animator animator2;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnMouseEnter()
    {
        // Reproducir la animación
        animator.SetBool("detected",true);
        animator2.SetBool("detected2",true);
    }

    private void OnMouseExit(){
         animator.SetBool("detected",false);
         animator2.SetBool("detected2",false);
    }
}
