using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class Battle : MonoBehaviour
{
    public int[] combatSize;
    public List<Combat> combats = new List<Combat>();
    Combat combats1;
    int x;
    int randomQuestion;
    public Text victoryText;
    int death;

    public GameObject monstre1, monstre2, monstre3, boss;
    bool isWinning = false;
    int countingAnswer = 0;
    public string sceneCredits;

    // Start is called before the first frame update
    void Start()
    {
        x = combatSize.Length;  //x prend la taille du tableau, donc le nombre total de stéréotypes
        randomQuestion = Random.Range(0, x);    //randomQuestion prend une valeur aléatoire entre 0 et x
        combats1 = combats[randomQuestion]; //combats1 prend tous les éléments de la classe combat, à un rang de la liste aléatoire (la liste combats)
        
        Debug.Log(x);
        //on affiche le stéréotype aléatoire dans la bulle de texte du monstre, et les réponses à ce stéréotypes dans les images contenant les réponses
        combats1.stePrint.text = combats1.stereotype;   

        combats1.rep1.text = combats1.reponse1;
        combats1.rep2.text = combats1.reponse2;
        combats1.rep3.text = combats1.reponse3;
    }

    public void PrintAnswer(Text a)
    {
        combats1.answer.text = a.text;  //on affiche la réponse sélectionné dans notre bulle de texte
        isWinning = true;

        if (a.text == combats1.goodAnswer.text)
        {
            victoryText.text = "You win !";

            if(monstre1.activeInHierarchy && isWinning == true)
            {
                monstre1.SetActive(false);
                monstre2.SetActive(true);
                isWinning = false;
            }
            
            if(monstre2.activeInHierarchy && isWinning == true)
            {
                monstre2.SetActive(false);
                monstre3.SetActive(true);
                isWinning = false;
            }

            if(monstre3.activeInHierarchy && isWinning == true)
            {
                monstre3.SetActive(false);
                boss.SetActive(true);
                isWinning = false;
                FindObjectOfType<AudioManager>().Stop("MobMusic");
                FindObjectOfType<AudioManager>().Play("BossMusic");
            }

            if(boss.activeInHierarchy)
            {
                countingAnswer++;
                if(countingAnswer >= 4)
                {
                    boss.SetActive(false);
                    FindObjectOfType<AudioManager>().Stop("BossMusic");
                    SceneManager.LoadScene(sceneCredits);
                }
            }
            
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
            FindObjectOfType<Health>().LoseLife();
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