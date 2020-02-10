using System;
using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEngine;

public class TestOnScreenHaut : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("shit");
        GetComponentInParent<Swipe>().triggerHaut = true;
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<Swipe>().triggerHaut = false;
    }
}

