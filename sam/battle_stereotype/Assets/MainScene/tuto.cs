using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto : MonoBehaviour
{
    public GameObject handTuto;

    // Update is called once per frame
    void Update()
    {
        if (Input.touchCount > 0)
        {
            handTuto.SetActive(false);
        }
    }
}
