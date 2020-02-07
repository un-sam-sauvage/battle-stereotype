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

public class Battle : MonoBehaviour
{
    public string[] index, data;

    public List<string> listData;

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

    void Awake()
    {
        SpreadsheetManager.Read(new GSTU_Search("1CN1DYKG_ZcYQxbzcMlCx-TCWbpGhlV8olewa0P106J4", "FeuilleTest"), Bado);
    }
    
    // Start is called before the first frame update
    void Start()
    {
        string pathTxt = Application.dataPath + "/DataBaseOnline.txt";
        Debug.Log("test apparition");

        var fileData = File.ReadAllText(pathTxt);
        
        data = fileData.Split(new char[] { '\n' });

        listData = new System.Collections.Generic.List<string>(data);
        listData.RemoveAt(0);

        GenerationCombat();
    }

    public void Bado(GstuSpreadSheet spreadSheetRef)
    {
        Debug.Log("yo");
        
        string pathTxt = Application.dataPath + "/DataBaseOnline.txt";
        
        StringBuilder str = new StringBuilder();

        foreach (var row in spreadSheetRef.rows.primaryDictionary)
        {
            foreach (var cell in row.Value)
            {
                str.Append(cell.value + "|");
            }

            str.Remove(str.Length - 1, 1);
            str.Append("\n");
        }

        str.Remove(str.Length - 1, 1);
        
        File.WriteAllText(pathTxt, str.ToString());
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
            //index[1].Remove('*');
            goodAnswer = index[1].ToString();
            
        }
        else if (index[2].Contains("*"))
        {
            //index[2].Remove('*');
            goodAnswer = index[2].ToString();
        }
        else
        {
            //index[3].Remove('*');
            goodAnswer = index[3].ToString();
        }

        stereotype.text = index[0].ToString();
        rep1.text = index[1].ToString();
        rep2.text = index[2].ToString();
        rep3.text = index[3].ToString();
        
        //VerifAnswer(myAnswer);
    }

    public void VerifAnswer(TMP_Text selectedAnswer)
    {
        isWinning = true;

        if (selectedAnswer.text == goodAnswer.ToString()) //Si la réponse sélectionné est égale à la bonne réponse
        {
            victoryText.text = "You win !";
            //FindObjectOfType<AudioManager>().Play("GoodSound"); //On joue le son de victoire

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
                //FindObjectOfType<AudioManager>().Stop("MobMusic");      
                //FindObjectOfType<AudioManager>().Play("BossMusic");
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
            //FindObjectOfType<Health>().LoseLife();  //on lance la fonction LoseLife du script Health
            //FindObjectOfType<AudioManager>().Play("ErrorSound");    //On joue le son de l'erreur
        }
    }
    
    void DeleteStereotype()
    {
        if (listData.Count > 1)
        {
            listData.RemoveAt(randomNumber);
        }
        
        //GenerationCombat();
    }
    

    void Update()
    {
        if (countingAnswer >= 4) //Si le compteur atteint 4, le boss est vaincu, on va aux crédits
        {
            boss.SetActive(false);
            //FindObjectOfType<AudioManager>().Stop("BossMusic");
            countDown -= Time.deltaTime;
            imageFade.SetActive(true);

            if (countDown <= 0)
            {
                SceneManager.LoadScene(sceneCredits);
            }

        }
    }
}
