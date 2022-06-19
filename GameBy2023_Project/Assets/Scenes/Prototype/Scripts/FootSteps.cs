using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FootSteps : MonoBehaviour
{

    public AudioClip footstep;
    public AudioSource source;


    //in the animator add event when he steps and call footsound()
    void footsound()
    {
        source.clip = footstep;
        source.Play();
    }
}
