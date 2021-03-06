﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    
    public string scenetoload;
    public GameObject GameOverPanel;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1f;
    }
     void Awake()
    {
        GameOverPanel.SetActive(false);
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void LoadMenu()
    {//Sert à Load le MenuStart 

        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("MobMusic");
        FindObjectOfType<AudioManager>().Stop("BossMusic");
        SceneManager.LoadScene("menu_start");
        
    }
    public void RestartTheLvl()
    {// Recharge le niv ou est "mort" le joueur

        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("MobMusic");
        FindObjectOfType<AudioManager>().Stop("BossMusic");
        SceneManager.LoadScene(scenetoload);
        

    }
    public void GameOverOn()
    {// Rend visible le GameOver

        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;


    }
}
