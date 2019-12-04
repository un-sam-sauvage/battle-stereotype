﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class changement_scene_menu_start : MonoBehaviour
{
    public string sceneNameToLoad ;
    bool startCountdown=false;
    public GameObject imageFade;
    float countdown = 1f;

    public void ChangementScene()
    {
        // quand on clique sur le bouton, lance l'animation et le compte à rebours
        imageFade.SetActive(true);
        startCountdown = true;          
    }
    void Update()
    {
        if (startCountdown == true)
        {
            countdown -= Time.deltaTime;
            Debug.Log(countdown);
        }
        //une fois que le compte à rebours est fini, change de scène.
        if (countdown <= 0)
        {
            SceneManager.LoadScene(sceneNameToLoad);
        }

    }
}
