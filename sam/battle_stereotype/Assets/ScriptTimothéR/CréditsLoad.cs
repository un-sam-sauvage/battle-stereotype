﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CréditsLoad : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void LoadCrédits()
    {// Charge la scene crédits et stop la music du menu
        SceneManager.LoadScene("Crédits");
        FindObjectOfType<AudioManager>().Stop("MenuMusic");
    }

}
