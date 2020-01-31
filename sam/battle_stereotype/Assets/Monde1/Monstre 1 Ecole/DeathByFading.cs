using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeathByFading : MonoBehaviour
{
    SpriteRenderer spriteRenderer;
    float a = 1f;
    float x = 0.02f;

    public void DeathByFade()
    {
        a -= x; //a perd x à chaque frame
        spriteRenderer = GetComponent<SpriteRenderer>();    //on récupère les composants du SpriteRenderer
        spriteRenderer.color = new Color(1, 1, 1, a);   //on actualise l'opacité de la couleur du sprite

        if (a <= 0)
        {
            Destroy(gameObject);    //Quand a atteint 0 ou moins, on détruit l'objet
        }
    }
}
