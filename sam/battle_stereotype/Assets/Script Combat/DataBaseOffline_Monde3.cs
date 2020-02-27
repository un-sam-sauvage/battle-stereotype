using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class DataBaseOffline_Monde3 : MonoBehaviour
{
    public TextAsset badoMonde3;
    public List<string> listData = new List<string>();
    public string infoData;
    
    void Start()
    {
        DontDestroyOnLoad(gameObject);
        Bado();
    }

    public void Bado()
    {
        StringBuilder str = new StringBuilder();
        str.Append(badoMonde3.text);

        infoData = str.ToString();
        
        string[] splitInfoData= infoData.Split('=');

        foreach (string strs in splitInfoData)
        {
            listData.Add(strs);
        }
    }
}
