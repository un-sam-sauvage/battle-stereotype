using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchSprite : MonoBehaviour
{
    public static bool guiTouch = false;
    Touch touch;
    public void TouchInput (BoxCollider2D collider)
    {
        Vector3 touchPos = Camera.main.ScreenToWorldPoint(touch.position);
        if (collider == Physics2D.OverlapPoint(touchPos))
        {
            touch = Input.GetTouch(0);
            
            switch (Input.GetTouch(0).phase)
            {
                case TouchPhase.Began:
                    guiTouch = true;
                    break;
                case TouchPhase.Moved:
                    guiTouch = true;
                    break;
                case TouchPhase.Ended:
                    guiTouch = false;
                    break;
            }
        }
    }

}
