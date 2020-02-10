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

public class DataBase : MonoBehaviour
{
    public List<string> listData;
    public string infoData;
    
    void Awake()
    {
        SpreadsheetManager.Read(new GSTU_Search("1CN1DYKG_ZcYQxbzcMlCx-TCWbpGhlV8olewa0P106J4", "FeuilleTest"), Bado);
        DontDestroyOnLoad(gameObject);
    }
    
    
    public void Bado(GstuSpreadSheet spreadSheetRef)
    {
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
        infoData = str.ToString();
        
        listData = new List<string>(infoData.Split(new char[]{'\n'}));
        
        listData.RemoveAt(0);
    }
}
