using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class DragNDrop2 : MonoBehaviour , IDragHandler, IEndDragHandler , IBeginDragHandler
{

    Vector2 startPosition;
    public static GameObject objectBeingDrag;
    public GameObject panel;

    public void OnBeginDrag(PointerEventData eventData)
    {
        startPosition = transform.position;
        objectBeingDrag = gameObject;
    }

    // lorsque le joueur drag un objet, l'objet prend les coordonnées de l'endroit où le joueur touche l'écran et l'objet prend ces coordonnées.
    public void OnDrag(PointerEventData eventData)
    {
        Touch touch = Input.GetTouch(0);
        Vector2 touchPos = touch.position;
        transform.position = touchPos;
        
    }
    // si l'on relâche l'écran, l'objet revient à sa position de départ.
    public void OnEndDrag(PointerEventData eventData)
    {
        objectBeingDrag = null;
        transform.position = startPosition;
    }
}