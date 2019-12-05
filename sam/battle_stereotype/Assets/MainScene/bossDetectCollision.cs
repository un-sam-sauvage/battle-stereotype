using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bossDetectCollision : MonoBehaviour, IDropHandler
{
    public GameObject bulleFoule;

    public GameObject item
    {
        get
        {
            // le panel boss accepte d'avoir 4 enfants.
            if (transform.childCount > 0)
            {
                bulleFoule.SetActive(true);
                DragNDrop2.enabledTransfer = true;

                return transform.GetChild(0).gameObject;
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragNDrop2.objectBeingDrag.transform.SetParent(transform);
        }
    }
}