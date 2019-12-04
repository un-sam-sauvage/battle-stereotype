using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop2 : MonoBehaviour , IDragHandler, IEndDragHandler
{

    public void OnDrag(PointerEventData eventData)
    {
        Touch touch = Input.GetTouch(0);
        //Vector2 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        Vector2 touchPos = touch.position;
        transform.position = touchPos;
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
    }
}
 