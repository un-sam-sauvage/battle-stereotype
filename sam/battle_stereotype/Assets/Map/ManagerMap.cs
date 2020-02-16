using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ManagerMap : MonoBehaviour
{    
    public static int nbLvlAllow=1;
    public GameObject[] triggerLevel;

    private void Start()
    {
        for (int i = 0; i < nbLvlAllow; i++)
        {
            triggerLevel[i].SetActive(true);
        }
    }
}