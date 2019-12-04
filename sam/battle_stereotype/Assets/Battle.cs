using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public Combat[] combats;
    int x;
    Combat combats1;

    public Button button1, button2, button3;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, 5);
        combats1 = combats[x];
        
        Debug.Log(x);

        combats1.stePrint.text = combats1.stereotype;

        combats1.rep1.text = combats1.reponse1;
        combats1.rep2.text = combats1.reponse2;
        combats1.rep3.text = combats1.reponse3;


    }

    public void PlayerTurn()
    {
        
    }
}


[System.Serializable]
public class Combat
{
    public string name;
    public string stereotype;
    public Text stePrint;
    public string reponse1, reponse2, reponse3;
    public Text rep1, rep2, rep3;
    public Text answer;
    public Text goodAnswer;
}