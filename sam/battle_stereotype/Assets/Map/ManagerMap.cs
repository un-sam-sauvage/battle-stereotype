using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ManagerMap : MonoBehaviour
{    
    public static int nbLvlAllow=1;
    public GameObject[] button;

    private void Start()
    {
        for (int i = 0; i < nbLvlAllow; i++)
        {
            button[i].SetActive(true);
        }
    }
}
