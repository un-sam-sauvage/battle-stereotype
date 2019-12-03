using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class Sound : MonoBehaviour
{
    public string nameSound;

    public AudioClip clip ;

    [Range(0f, 1f)] 
    public float volume ;

    public bool loop ;

    [HideInInspector]
    public AudioSource source ;
}
