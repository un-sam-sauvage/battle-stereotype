using System.Collections;
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

        SceneManager.LoadScene("menu_start");
        Time.timeScale = 1f;
    }
    public void RestartTheLvl()
    {// Recharge le niv ou est "mort" le joueur

        SceneManager.LoadScene(scenetoload);
        Time.timeScale = 1f;

    }
    public void GameOverOn()
    {

        GameOverPanel.SetActive(true);
        Time.timeScale = 0f;


    }
}
