using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayMobMusic : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        FindObjectOfType<AudioManager>().Play("MobMusic");
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
