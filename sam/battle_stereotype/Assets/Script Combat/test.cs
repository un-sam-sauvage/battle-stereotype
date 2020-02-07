using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using GoogleSheetsToUnity;
using JetBrains.Annotations;

public class test : MonoBehaviour
{
    public string[] index, data;

    public List<string> listData;

    public int randomNumber;
    public string goodAnswer;
    
    void Awake()
    {
        SpreadsheetManager.Read(new GSTU_Search("1CN1DYKG_ZcYQxbzcMlCx-TCWbpGhlV8olewa0P106J4", "FeuilleTest"), Bado);

    }
    void Start()
    {
        string pathTxt = Application.dataPath + "/DataBaseOnline.txt";
        Debug.Log("test apparition");

        var fileData = File.ReadAllText(pathTxt);
        
        data = fileData.Split(new char[] { '\n' });

        listData = new System.Collections.Generic.List<string>(data);
        listData.RemoveAt(0);
        
        Combat();
    }

    public void Bado(GstuSpreadSheet spreadSheetRef)
    {
        Debug.Log(spreadSheetRef.columns["Stéréotypes"]);

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

    public void Combat()
    {
        randomNumber = Random.Range(0, listData.Count);

        for (int i = 0; i < listData.Count; i++)
        {
            index = listData[randomNumber].Split(new char[] {'|'});
        }

        /*OPTIMISATION
         for (int i = 0; i < index.Length; i++)
        {
            foreach (var char in index[i])
            {
                if(char )
            }
        }*/

        if (index[1].Contains("*"))
        {
            goodAnswer = index[1];
        }
        else if (index[2].Contains("*"))
        {
            goodAnswer = index[2];
        }
        else
        {
            goodAnswer = index[3];
        }

        VerifAnswer();
    }

    public void VerifAnswer()
    {
        
    }

    void SupprAnswer()
    {
        if (listData.Count > 1)
        {
            listData.RemoveAt(randomNumber);
        }
    }
}