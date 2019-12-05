using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bossDetectCollision : MonoBehaviour, IDropHandler
{
    public GameObject text;
    public GameObject item
    {
        get
        {
            // le panel boss accepte d'avoir 4 enfants.
            if (transform.childCount > 0)
            {
                text.SetActive(true);
                //DragNDrop2.objectBeingDrag.SetActive(false);
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