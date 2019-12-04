using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public Combat[] combats;
    int x;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, 5);
        Combat combats1 = combats[x];
        Debug.Log(x);

        combats1.stePrint.text = combats1.stereotype;

        
        
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
    public Text stePrint;
    public Text rep1, rep2, rep3, rep4;
    public string answer;
}