using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundClick : MonoBehaviour
{
    private AudioSource audioSource;


    void Start(){

        audioSource = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void Click()
    {
        audioSource.Play();
    }
}
