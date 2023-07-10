using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyCameras : MonoBehaviour
{
    private static DontDestroyCameras instance;

    private void Awake()
    {
        if (instance == null)
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}
