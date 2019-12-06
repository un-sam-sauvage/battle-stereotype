using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class ChargeFirstScene : MonoBehaviour
{
    public string levelToload;
    public float timer = 26f;
    AudioManager audioManager;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("IntroMusic");
    }

    // Update is called once per frame
    void Update()
    {// Décompte timer avant de load une scene "Intromusic"
        timer -= Time.deltaTime;

        if ( timer <= 0)
        {
            SceneManager.LoadScene(levelToload);
            FindObjectOfType<AudioManager>().Stop("IntroMusic");


        }
    }
}
