using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TouchDrag : TouchSprite
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        TouchInput(GetComponent<BoxCollider2D>());
    }
    void onFisrtTouch()
    {
        Vector3 pos;
        pos = new Vector3(Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).x, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).y, Camera.main.ScreenToWorldPoint(Input.GetTouch(0).position).z);
        transform.position = pos;

    }
}
