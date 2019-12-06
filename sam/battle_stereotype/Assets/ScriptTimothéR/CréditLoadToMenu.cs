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
        
    }

    // Update is called once per frame
    void Update()
    {
        tiimer -= Time.deltaTime;
        if (tiimer <= 0)
        {
            SceneManager.LoadScene("menu_start");


        }

            
    }
}
