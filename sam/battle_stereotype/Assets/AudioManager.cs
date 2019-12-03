using System;
using UnityEngine;
using UnityEngine.Audio;  

public class AudioManager : MonoBehaviour
{
    public Sound[] sounds;

    public static AudioManager Instance;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);  //On ne détruit pas l'objet pendant le chargement
            //On conserve l'objet même en changeant de scène
        if (Instance == null)
        {
            Instance = this;    //Si Instance n'est pas défini, on définit Instance avec notre objet, sinon, on le détruit
        }
        else
        {
            Destroy(gameObject);
        }


        foreach (Sound s in sounds) //Pour chaque son dans notre tableau, on va chercher sa source, son volume et l'option pour le loop
        {
            s.source = gameObject.AddComponent<AudioSource>();
            s.source.clip = s.clip;

            s.source.volume = s.volume;

            s.source.loop = s.loop;
        }
    }



    public void Play(string nameSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameSound); //On joue le son nommé par le nom tapé
        s.source.Play();
    }

    public void Stop(string nameSound)
    {
        Sound s = Array.Find(sounds, sound => sound.name == nameSound); //On arrête le son nommé par le nom tapé
        s.source.Stop();
    }
}
