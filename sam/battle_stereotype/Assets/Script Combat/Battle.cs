using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleSheetsToUnity;

public class Battle : MonoBehaviour
{
    public int[] combatSize;
    public List<Combat> combats = new List<Combat>();
    Combat combats1;
    int x;
    int randomQuestion;
    public TMP_Text victoryText;
    int death;

    public GameObject monstre1, monstre2, monstre3, boss;
    bool isWinning = false;
    int countingAnswer = 0;

    public string sceneCredits;
    public float countDown = 1f;
    public GameObject imageFade;

    public Image bossBubble;

    // Start is called before the first frame update
    void Start()
    {
        x = combatSize.Length;  //x prend la taille du tableau, donc le nombre total de stéréotypes
        randomQuestion = Random.Range(0, x);    //randomQuestion prend une valeur aléatoire entre 0 et x
        //combats1 = combats[randomQuestion]; //combats1 prend tous les éléments de la classe combat, à un rang de la liste aléatoire (la liste combats)
        
        Debug.Log(x);
        //on affiche le stéréotype aléatoire dans la bulle de texte du monstre, et les réponses à ce stéréotypes dans les images contenant les réponses
        combats1.stePrint.text = combats1.stereotype;   

        combats1.rep1.text = combats1.reponse1;
        combats1.rep2.text = combats1.reponse2;
        combats1.rep3.text = combats1.reponse3;
        
        SpreadsheetManager.Read(new GSTU_Search("1CN1DYKG_ZcYQxbzcMlCx-TCWbpGhlV8olewa0P106J4", "FeuilleTest"), Combat);
    }

    public void Combat(GstuSpreadSheet spreadSheetRef)
    {
        Debug.Log(spreadSheetRef.columns["Stéréotypes"]);
        foreach (var columnStereotype in spreadSheetRef.Cells)
        {
            
        }
    }

    public void PrintAnswer(TMP_Text a)
    {
        combats1.answer.text = a.text;  //on affiche la réponse sélectionné dans notre bulle de texte
        isWinning = true;

        if (a.text == combats1.goodAnswer.text) //Si la réponse sélectionné est égale à la bonne réponse
        {
            victoryText.text = "You win !";
            FindObjectOfType<AudioManager>().Play("GoodSound"); //On joue le son de victoire

                //Les boucles if servent à changer de monstre à chaque fois
            if (monstre1.activeInHierarchy && isWinning == true)
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

                //On arrête la musique des mobs et on joue la musique de boss
                FindObjectOfType<AudioManager>().Stop("MobMusic");      
                FindObjectOfType<AudioManager>().Play("BossMusic");
                bossBubble.color = new Color(255, 0, 0);    //change la bulle du boss en rouge
            }

            if(boss.activeInHierarchy)  //Si le boss est activé dans la hiérarchie
            {
                countingAnswer++;   //On ajoute 1 au compteur de bonnes réponses
                
            }
            
            combats.RemoveAt(randomQuestion);   //On supprime la question à laquelle on vient de répondre
            x--;    //On retire 1 à x
            randomQuestion = Random.Range(0, x);    //On redéfinit randomQuestion avec une valeur maximum réduite précedemment

            combats1 = combats[randomQuestion]; //combats1 prend un élément aléatoire de la liste combats et tous les élements de celui-ci

            combats1.stePrint.text = combats1.stereotype;

            combats1.rep1.text = combats1.reponse1;
            combats1.rep2.text = combats1.reponse2;
            combats1.rep3.text = combats1.reponse3;
        }
        else
        {
            victoryText.text = "You loose...";
            FindObjectOfType<Health>().LoseLife();  //on lance la fonction LoseLife du script Health
            FindObjectOfType<AudioManager>().Play("ErrorSound");    //On joue le son de l'erreur
        }
    }

    void Update()
    {
        if (countingAnswer >= 4) //Si le compteur atteint 4, le boss est vaincu, on va aux crédits
        {
            boss.SetActive(false);
            FindObjectOfType<AudioManager>().Stop("BossMusic");
            countDown -= Time.deltaTime;
            imageFade.SetActive(true);

            if (countDown <= 0)
            {
                SceneManager.LoadScene(sceneCredits);
            }

        }
    }
}


[System.Serializable]
public class Combat //on crée une classe combat avec plusieurs éléments
{
    public string stereotype;
    public TMP_Text stePrint;
    public string reponse1, reponse2, reponse3;
    public TMP_Text rep1, rep2, rep3;
    public TMP_Text answer;
    public TMP_Text goodAnswer;
}