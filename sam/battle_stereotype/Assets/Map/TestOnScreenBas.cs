using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TestOnScreenBas : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("schnel");
        GetComponentInParent<Swipe>().triggerBas = true;
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        GetComponentInParent<Swipe>().triggerBas = false;
    }
}
