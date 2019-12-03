using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Battle : MonoBehaviour
{
    public Combat[] combats;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Combat
{
    public string stereotype;
    public string rep1, rep2, rep3, rep4;
    public Sprite monsterSprite;
    public string answer;
}