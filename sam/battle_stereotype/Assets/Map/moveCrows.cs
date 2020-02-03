using System.Collections;
using System.Collections.Generic;
using DG.Tweening;
using UnityEngine;
using UnityEngine.UIElements;

public class moveCrows : MonoBehaviour
{

    // Update is called once per frame
   void Update() {

       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector2 touchPos = touch.position;
            transform.DOMove(touchPos, 2);
        }
    }
}
