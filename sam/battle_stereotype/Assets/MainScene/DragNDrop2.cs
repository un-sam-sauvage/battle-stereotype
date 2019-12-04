using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop2 : MonoBehaviour , IDragHandler, IEndDragHandler
{
    public GameObject boss;
    public GameObject bouton;

    // lorsque le joueur drag un objet, l'objet prend les coordonnées de l'endroit où le joueur touche l'écran 
    public void OnDrag(PointerEventData eventData)
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = touch.position;
        transform.position = touchPos;
        RectTransform boss = transform as RectTransform;
        if (!RectTransformUtility.RectangleContainsScreenPoint(boss,touchPos))
        {
            bouton.SetActive(true);
        }
        
    }

    public void OnEndDrag(PointerEventData eventData)
    {
        transform.localPosition = Vector2.zero;
    }
}
 