using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class detectDados : MonoBehaviour,IPointerEnterHandler, IPointerExitHandler
{
    public Animator animator; // Referencia al componente Animator
    public Animator animator2;

    public void OnPointerEnter(PointerEventData eventData)
    {
        // Reproducir la animación
        animator.SetBool("detected",true);
        animator2.SetBool("detected2",true);
    }

    public void OnPointerExit(PointerEventData eventData){
         animator.SetBool("detected",false);
         animator2.SetBool("detected2",false);
    }
}
