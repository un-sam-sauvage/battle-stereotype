using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMap : MonoBehaviour
{    
    public static int nbLvlAllow=1;
    public GameObject[] button;

    public void LoadScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}
