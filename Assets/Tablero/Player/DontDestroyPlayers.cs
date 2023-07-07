using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroyPlayers : MonoBehaviour
{
    private static DontDestroyPlayers instance;

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
