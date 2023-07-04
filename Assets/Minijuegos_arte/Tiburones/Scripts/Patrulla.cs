using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Patrulla : MonoBehaviour
{
    public float velocidad = 5f;
    public int direccion = -1; //-1 izquierda y 1 derecha
    private float originalX;
    private float maxX;
    private float minX;

    private void Awake(){
        originalX = transform.position.x;
        float camDistance = Vector3.Distance(transform.position, 
        Camera.main.transform.position);//Calculamos distancia objeto y camara principal
        Vector2 bottomCorner = Camera.main.ViewportToWorldPoint(new Vector3(0, 0, camDistance)); //Aqui guardamos la esquina inferior izquierda
        Vector2 topCorner = Camera.main.ViewportToWorldPoint(new Vector3(1, 0, camDistance)); //Aqui guardamos la esquina inferior derecha
        //Aqui almacenamos el parametro x de las coordenadas anteriores
        maxX = topCorner.x;
        minX = bottomCorner.x;
    }

    private void Update()
    {
        transform.Translate(Vector2.right * 
        velocidad * direccion * Time.deltaTime); //movimiento horizontal
        if(transform.position.x >= maxX+1.8 || transform.position.x <= minX-1.8){
            float clampedX = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(clampedX, transform.position.y, transform.position.z);
            Flip();
        }
    }

    private void Flip(){
        transform.Rotate(0f, 180f, 0f);
    }
}
