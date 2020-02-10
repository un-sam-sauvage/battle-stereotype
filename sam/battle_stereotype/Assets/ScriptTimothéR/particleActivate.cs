using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class particleActivate : MonoBehaviour
{
    public ParticleSystem particule;

    public bool particuleActivate = false;
    // Start is called before the first frame update
    void Start()
    {
        particule = GetComponent<ParticleSystem>();
        
    }

    // Update is called once per frame
    void Update()
    {// Permet de réactiver les particules + les désactivés
        if (particuleActivate)
        {
            particule.Stop(true, ParticleSystemStopBehavior.StopEmitting);
        }
        else if (particule.isStopped && particuleActivate == false)
        {
            particule.Play(gameObject);
        }
        
    }
}
