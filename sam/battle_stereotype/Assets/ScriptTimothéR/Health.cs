using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Health : MonoBehaviour
{
    public int health;
    public int numOfHearts;

    public Image[] hearts;
    public Sprite fullheart;
    public Sprite emptyHeart;

    public Animator[] animationHp;
    public float countDown = 0.5f;
    

    public void LoseLife()
    {
        health--;

    }

    // Update is called once per frame
    void Update()
    { // On lance les animations à chaque fois qu'on perd de la vie 
        if (health == 4)
        {

            animationHp[0].SetBool("Coeur4", true);

        }

        if (health == 3)
        {

            animationHp[1].SetBool("Coeur3", true);

        }

        if (health == 2)
        {
            animationHp[2].SetBool("Coeur2", true);

        }

        if (health == 1)
        {
            animationHp[3].SetBool("Coeur1", true);
        }

        if (health == 0)
        {
            animationHp[4].SetBool("Coeur", true);

        }

        if (health <= 0)// Fait apparaitre le panel GameOver après un décompte
        {
            countDown -= Time.deltaTime;

            if(countDown <= 0)  
            {
                GameOver gameOver = FindObjectOfType<GameOver>();
                gameOver.GameOverOn();
            }
        }


        if (health > numOfHearts)
        {
            health = numOfHearts;
        }


        for (int i = 0; i < hearts.Length; i++)
        {//SetUp la vie si i est inférieur à la vie total (5) 

            if (i < health) // Fait apparaitre le Sprite "fullheart"
            {
                hearts[i].sprite = fullheart;
            }
           else
            {
                hearts[i].sprite = emptyHeart; // Fait apparaitre le Sprite "Emptyheart" à la place de "fullheart"
            }

            if (i < numOfHearts)// Rend visible hearts si i inférieur à numOfHearts
            {
                hearts[i].enabled = true;
            }
            else
            {// Rend invisible hearts si i supérieur à numOfHearts
                hearts[i].enabled = false;
            }
        }
    }
}
