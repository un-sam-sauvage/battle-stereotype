using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using TMPro;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleSheetsToUnity;
using JetBrains.Annotations;

public class BattleOffline_Monde3 : MonoBehaviour
{
    public string[] index;

    public List<string> listData = new List<string>();

    public int randomNumber;
    public string goodAnswer;

    
    public TMP_Text victoryText, stereotype, rep1, rep2, rep3, myAnswer;
    int death;

    public GameObject monstre1, monstre2, monstre3, boss;
    bool isWinning = false;
    int countingAnswer = 0;

    public string sceneCredits;
    public float countDown = 1f;
    public GameObject imageFade;

    public Image bossBubble;

    public GameObject mainTuto;
    private bool _firstAnswer;

    void Awake()
    {
        DataBaseOffline_Monde3 dataBase = FindObjectOfType<DataBaseOffline_Monde3>();
        listData = dataBase.listData;
    }
    
    // Start is called before the first frame update
    void Start()
    {

        GenerationCombat();
    }

    

    public void GenerationCombat()
    {
        randomNumber = Random.Range(0, listData.Count);

        for (int i = 0; i < listData.Count; i++)
        {
            index = listData[randomNumber].Split(new char[] {'|'});
        }
        
        if (index[1].Contains("*"))
        {
            //index[1].Remove(0, 1);
            goodAnswer = index[1].Substring(1, index[1].Length - 1);
            rep1.text = goodAnswer;
            rep2.text = index[2].ToString();
            rep3.text = index[3].ToString();
            
        }
        else if (index[2].Contains("*"))
        {
            //index[2].Remove(0, 1);
            goodAnswer = index[2].Substring(1, index[2].Length - 1);
            rep1.text = index[1].ToString();
            rep2.text = goodAnswer;
            rep3.text = index[3].ToString();
        }
        else
        {
            //index[3].Remove(0, 1);
            goodAnswer = index[3].Substring(1, index[3].Length - 1);
            rep1.text = index[1].ToString();
            rep2.text = index[2].ToString();
            rep3.text = goodAnswer;
        }

        stereotype.text = index[0].ToString();
    }

    public void VerifAnswer(TMP_Text selectedAnswer)
    {
        
        myAnswer.text = selectedAnswer.text;
        
            
        
        isWinning = true;
        

        if (selectedAnswer.text == goodAnswer.ToString()) //Si la réponse sélectionné est égale à la bonne réponse
        {
            victoryText.text = "You win !";
            
            //désative le tutoriel.
            if (_firstAnswer)
            {
                mainTuto.SetActive(false);
                _firstAnswer = false;
            }
            
            FindObjectOfType<AudioManager>().Play("GoodSound"); //On joue le son de victoire

                //Les boucles if servent à changer de monstre à chaque fois
            if (monstre1.activeInHierarchy && isWinning)
            {
                monstre1.SetActive(false);
                monstre2.SetActive(true);
                isWinning = false;
            }
            
            if(monstre2.activeInHierarchy && isWinning)
            {
                monstre2.SetActive(false);
                monstre3.SetActive(true);
                isWinning = false;
            }

            if(monstre3.activeInHierarchy && isWinning)
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
            
            DeleteStereotype();   //On supprime la question à laquelle on vient de répondre
            
        }
        else
        {
            victoryText.text = "You loose...";
            FindObjectOfType<Health>().LoseLife();  //on lance la fonction LoseLife du script Health
            FindObjectOfType<AudioManager>().Play("ErrorSound");    //On joue le son de l'erreur
        }
    }
    
    void DeleteStereotype()
    {
        if (listData.Count > 1)
        {
            listData.RemoveAt(randomNumber);
        }
        
        GenerationCombat();
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
                SceneManager.LoadScene("Monde2");
            }

        }
    }
}
