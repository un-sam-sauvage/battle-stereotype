using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class Swipe : MonoBehaviour
{
    private bool _swipeUp, _swipeDown;
    private bool _isDragging=false;
    public bool triggerHaut,triggerBas;
    private Vector2 _startPos, _swipeDelta;

    public GameObject topMap;
    // Update is called once per frame
    void Update()
    {

        //Effectue la translation vers le haut ou le bas
        if (_swipeUp && !triggerBas)
        {
            gameObject.transform.position += Vector3.up*7;
        }

        if (_swipeDown && !triggerHaut)
        {
            gameObject.transform.position += Vector3.down*7;
        }
        
        _swipeDown = _swipeUp = false;
//pour tester avec la souris
        if (Input.GetMouseButtonDown(0))
        {
            _isDragging = true;
            _startPos = Input.mousePosition;
        }else if (Input.GetMouseButtonUp(0))
        {
            ResetFunction();
        }
        //détecte quand notre doigt et sur l'écran ou qu'il se relache.
        if (Input.touches.Length > 0)
        {
            if (Input.touches[0].phase == TouchPhase.Began)
            {
                _isDragging = true;
                _startPos = Input.touches[0].position;
            }
            else if (Input.touches[0].phase == TouchPhase.Ended || Input.touches[0].phase == TouchPhase.Canceled)
            {
                _isDragging = false;
                ResetFunction();
            }
        }
      //crée le vecteur directionnel. 
        _swipeDelta =Vector2.zero;
        if (_isDragging)
        {
            if (Input.touches.Length > 0)
            {
                _swipeDelta = Input.touches[0].position - _startPos;
            }

            if (Input.GetMouseButton(0))
            {
                _swipeDelta = (Vector2) Input.mousePosition - _startPos;
            }
        }
//active la condition correspondante a la diection.
        if (_swipeDelta.magnitude>100)
        {
            if (_swipeDelta.y<0)
            {
                _swipeDown = true;
            }

            if (_swipeDelta.y > 0)
            {
                _swipeUp = true;
            }
        }
    }

    private void OnBecameVisible()
    {
        
    }

    // remet les variables a zero.
    private void ResetFunction()
    {
        _startPos = _swipeDelta = Vector2.zero;
        _isDragging = false; 
    }
}
