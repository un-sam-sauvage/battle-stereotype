using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.UI;

public class DragNDrop2 : MonoBehaviour, IDragHandler, IEndDragHandler, IBeginDragHandler
{

    Vector2 startPosition;
    public static GameObject objectBeingDrag;

    public GameObject bulleFoule;
    public Text answerDragged;
    public static bool enabledTransfer = false;

    float countdown = 5f;

    void Start()
    {
        Input.multiTouchEnabled = false;
    }

    public void OnBeginDrag(PointerEventData eventData)
    {
        enabledTransfer = false;
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
    // si l'on relâche l'écran, l'objet revient à sa position de départ. Il envoie aussi le contenu du texte au programme de bataille.
    public void OnEndDrag(PointerEventData eventData)
    {
        objectBeingDrag = null;
        transform.position = startPosition;
        if (enabledTransfer == true)
        {
            Battle battle = FindObjectOfType<Battle>();
            battle.PrintAnswer(answerDragged);
        }


    }
    public void Update()
    {
        if (enabledTransfer == true)    //Après 5 secondes, on désactive la bulle de texte de la foule
        {
            countdown -= Time.deltaTime;
            if (countdown <= 0)
            {
                bulleFoule.SetActive(false);
                countdown = 5f;
            }
        }
    }



}