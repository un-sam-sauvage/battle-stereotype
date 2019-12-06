using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
public class CréditLoadToMenu : MonoBehaviour
{
    public float tiimer = 10f;
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("EndMusic");
    }

    // Update is called once per frame
    void Update()
    {// Lance le timer avant de load le menu
        tiimer -= Time.deltaTime;
        if (tiimer <= 0)
        {
            FindObjectOfType<AudioManager>().Stop("EndMusic");
            SceneManager.LoadScene("menu_start");


        }

            
    }
}
