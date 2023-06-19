using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DetectVisibility : MonoBehaviour
{
    private Dictionary<GameObject, bool> objectStates;


    public void setActiveFalse(){

        GameObject[] objectsToTrack = GameObject.FindGameObjectsWithTag("estadoUI");

        objectStates = new Dictionary<GameObject, bool>();

        foreach (GameObject obj in objectsToTrack)
        {   
            objectStates[obj] = obj.activeSelf;

        }

        foreach (GameObject obj in objectsToTrack)
        {
            obj.SetActive(false);
        }
    }

    public void setActiveTrue(){

        
        foreach (KeyValuePair<GameObject, bool> kvp in objectStates)
        {
            GameObject obj = kvp.Key;
            bool isActive = kvp.Value;

            obj.SetActive(isActive);
        }
    }


}
