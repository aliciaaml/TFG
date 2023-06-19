using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DontDestroy : MonoBehaviour
{

    public AudioClip Start_music;
    public AudioClip Game_music;

    private AudioSource audioSource;
    private static DontDestroy instance;

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

    private void Start()
    {
        audioSource = GetComponent<AudioSource>();
        audioSource.loop = true;
        audioSource.clip = Start_music;
        audioSource.Play();
    }

    private void Update()
    {
        if (EscogerPersonaje.juegoComenzar && audioSource.clip != Game_music)
        {
            audioSource.Stop();
            audioSource.clip = Game_music;
            audioSource.Play();
        }
    }
}



