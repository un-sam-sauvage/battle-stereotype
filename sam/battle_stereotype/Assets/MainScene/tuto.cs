using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class tuto : MonoBehaviour
{
    public GameObject handTuto;

    public void UndoTuto(bool disableTuto)
    {
        if (disableTuto)
        {
            handTuto.SetActive(false);
        }
    }
}