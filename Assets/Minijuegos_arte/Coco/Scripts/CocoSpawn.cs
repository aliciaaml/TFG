using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CocoSpawn : MonoBehaviour
{
    public GameObject cocoPrefab;
    public float tiempoEntreCocos = 1f;
    public float alturaGeneracion = 10f;

    private float temporizador = 0f;
    private Camera mainCamera;

    private void Start(){
        mainCamera = Camera.main;
    }

    private void Update(){
        temporizador += Time.deltaTime;

        if (temporizador>=tiempoEntreCocos)
        {
            GenerarCocos();
            temporizador = 0f;
        }
        DestruirCocos();

    }

    private void GenerarCocos()
    {
        //obtenemos medidas de la camara para generar cocos dentro de ella
        float camHeight = 2f * mainCamera.orthographicSize;
        float camWidth = camHeight * mainCamera.aspect;

        float xMin = mainCamera.transform.position.x - camWidth / 2f;
        float xMax = mainCamera.transform.position.x + camWidth / 2f;

        //Generamos los cocos dentro de las medidas de la camara
        Vector3 posicionGeneracion = new Vector3(Random.Range(xMin, xMax), alturaGeneracion, 0f);
        GameObject coco = Instantiate(cocoPrefab, posicionGeneracion, Quaternion.identity);

    }

    private void DestruirCocos()
    {
        GameObject[] cocos = GameObject.FindGameObjectsWithTag("coco");

        foreach (GameObject coco in cocos){
            if(coco.transform.position.y < mainCamera.transform.position.y-mainCamera.orthographicSize){
                Destroy(coco);
            }
        }
    }
}
