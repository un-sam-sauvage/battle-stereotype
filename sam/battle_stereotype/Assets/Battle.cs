using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Battle : MonoBehaviour
{
    public int[] combatSize;
    public List<Combat> combats = new List<Combat>();
    Combat combats1;
    int x;
    int randomQuestion;
    public Text victoryText;
    
    // Start is called before the first frame update
    void Start()
    {
        x = combatSize.Length;
        randomQuestion = Random.Range(0, x);
        combats1 = combats[randomQuestion];

        
        
        Debug.Log(x);

        combats1.stePrint.text = combats1.stereotype;

        combats1.rep1.text = combats1.reponse1;
        combats1.rep2.text = combats1.reponse2;
        combats1.rep3.text = combats1.reponse3;

        for(int i = 0; i < combatSize.Length; i++)
        {

        }

    }

    /*public void PlayerTurn()
    {
        Button b1 = button1.GetComponent<Button>();
        Button b2 = button2.GetComponent<Button>();
        Button b3 = button3.GetComponent<Button>();

        b1.onClick.AddListener(() => PrintAnswer(combats1.rep1));
        b2.onClick.AddListener(() => PrintAnswer(combats1.rep2));
        b3.onClick.AddListener(() => PrintAnswer(combats1.rep3));
        Debug.Log("Test");    
    }*/

    public void PrintAnswer(Text a)
    {
        combats1.answer.text = a.text;

        if (a.text == combats1.goodAnswer.text)
        {
            victoryText.text = "You win !";
            combats.RemoveAt(randomQuestion);
            x--;
            randomQuestion = Random.Range(0, x);

            combats1 = combats[randomQuestion];

            combats1.stePrint.text = combats1.stereotype;

            combats1.rep1.text = combats1.reponse1;
            combats1.rep2.text = combats1.reponse2;
            combats1.rep3.text = combats1.reponse3;
        }
        else
        {
            victoryText.text = "You loose...";
        }
    }
}


[System.Serializable]
public class Combat
{
    public string stereotype;
    public Text stePrint;
    public string reponse1, reponse2, reponse3;
    public Text rep1, rep2, rep3;
    public Text answer;
    public Text goodAnswer;
}