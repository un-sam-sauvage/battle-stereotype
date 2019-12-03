using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public Combat[] combats;
    // Start is called before the first frame update
    void Start()
    {
        Combat combats1 = combats[1];
        Debug.Log(combats1);
        if(combats1 == combats[0])
        {
            combats1.rep1.text = "Test";
            combats1.rep2.text = "Test";
            combats1.rep3.text = "Test";
            combats1.rep4.text = "Test";
        }
        else if(combats1 == combats[1])
        {
            combats1.rep1.text = "Là c'est le deuxième";
            combats1.rep2.text = "Oui";
            combats1.rep3.text = "Ah";
            combats1.rep4.text = "Ok";
        }
        

        
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}


[System.Serializable]
public class Combat
{
    public string name;
    public string stereotype;
    public Text rep1, rep2, rep3, rep4;
    public Sprite monsterSprite;
    public string answer;
}