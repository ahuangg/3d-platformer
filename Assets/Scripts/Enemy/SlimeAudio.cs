using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlimeAudio : MonoBehaviour
{
    // References to two AudioSources
    AudioSource aud1;
    AudioSource aud2;

    void Start()
    {
        // Get all AudioSource components attached to the GameObject
        AudioSource[] audioSources = GetComponents<AudioSource>();

            aud1 = audioSources[0];
            aud2 = audioSources[1];
 
    }

    void Update()
    {
        
    }

    // Method to play the first audio source
    public void PlaySound1()
    {
  
            aud1.Play();
   
    }

    // Method to play the second audio source
    public void PlaySound2()
    {

            aud2.Play();

    }
}