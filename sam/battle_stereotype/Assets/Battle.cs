using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public Combat[] combats;
    Combat combats1;
    int x;
    

    public Button button1, button2, button3;
    // Start is called before the first frame update
    void Start()
    {
        x = Random.Range(0, combats.Length);
        combats1 = combats[x];

        
        
        Debug.Log(x);

        combats1.stePrint.text = combats1.stereotype;

        combats1.rep1.text = combats1.reponse1;
        combats1.rep2.text = combats1.reponse2;
        combats1.rep3.text = combats1.reponse3;


    }

    public void PlayerTurn()
    {
        Button b1 = button1.GetComponent<Button>();
        Button b2 = button2.GetComponent<Button>();
        Button b3 = button3.GetComponent<Button>();

        b1.onClick.AddListener(PrintAnswer1);
        b2.onClick.AddListener(PrintAnswer2);
        b3.onClick.AddListener(PrintAnswer3);


        if (combats1.answer.text == combats1.goodAnswer.text)
        {
            Debug.Log("You win !");
        }
        else
        {
            Debug.Log("You loose...");
        }
    }

    public void PrintAnswer1()
    {
        combats1.answer.text = combats1.rep1.text;
    }

    public void PrintAnswer2()
    {
        combats1.answer.text = combats1.rep2.text;
    }

    public void PrintAnswer3()
    {
        combats1.answer.text = combats1.rep3.text;
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