using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class bossDetectCollision : MonoBehaviour, IDropHandler
{
    public GameObject item
    {
        get
        {
            // le panel boss accepte d'avoir 4 enfants.
            if (transform.childCount > 3)
            {
                return transform.GetChild(3).gameObject;                
            }
            return null;
        }
    }

    public void OnDrop(PointerEventData eventData)
    {
        if (!item)
        {
            DragNDrop2.objectBeingDrag.transform.SetParent(transform);
            
            DragNDrop2.objectBeingDrag.SetActive(false);

        }
    }
}