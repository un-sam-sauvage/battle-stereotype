using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class PauseMenu : MonoBehaviour
{
    public static bool GameIsPaused = false;
    public GameObject pauseMenuUI;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {// Sert à activer le tactile pour ensuite lancer le MenuPause
        if (Input.touchCount < 0)
        {
            Touch touch = Input.GetTouch(0);
            if (GameIsPaused)
            {
                Resume();

            } else
            {

                Pause();
            }

        }

    }
    public void Resume()
    {// Sert à reprendre le jeu
        pauseMenuUI.SetActive(false);
        Time.timeScale = 1f;
        GameIsPaused = false;
    }
  public void Pause()
    {// Sert à freeze le jeu et atcive le MenuPause

        pauseMenuUI.SetActive(true);
        Time.timeScale = 0f;
        GameIsPaused = true;
    }
    public void LoadMenu()
    {//Sert à Load le MenuStart et remet le temps de jeu à 1f

        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("MobMusic");
        FindObjectOfType<AudioManager>().Stop("BossMusic");
        SceneManager.LoadScene("menu_start");

    }

    public void LoadCarte()
    {// Sert à Load la Map et remet le temps de jeu à 1f
        Time.timeScale = 1f;
        FindObjectOfType<AudioManager>().Stop("MobMusic");
        FindObjectOfType<AudioManager>().Stop("BossMusic");
        SceneManager.LoadScene("Map");
    }
    public void QuitGame()
    {//Quit l'appli

        Application.Quit();

    }
}

