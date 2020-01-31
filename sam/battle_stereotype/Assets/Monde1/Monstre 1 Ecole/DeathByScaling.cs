using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByScaling : MonoBehaviour
{
    float x = 0.05f;
    float y = 0.05f;
    float z = 0.05f;

    public void DeathByScale()
    {
        transform.localScale -= new Vector3(x, y, z);   //On réduit la scale de l'objet de 0.05 toutes les frames

        if (transform.localScale.x <= 0 && transform.localScale.y <= 0 && transform.localScale.z <= 0)
        {
            Destroy(gameObject);    //Quand chaque valeur du scale atteint 0 ou moins, on détuit l'objet
        }
    }
}
