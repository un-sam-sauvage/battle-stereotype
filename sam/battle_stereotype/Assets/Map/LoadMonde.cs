using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadMonde : MonoBehaviour
{
    public string sceneNameToLoad;
    private void OnMouseDown()
    {
        SceneManager.LoadScene(sceneNameToLoad);
    }
}
