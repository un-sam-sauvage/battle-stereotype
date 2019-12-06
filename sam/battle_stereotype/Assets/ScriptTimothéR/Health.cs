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
    public Animator animationHp1;
    public Animator animationHp2;
    public Animator animationHp3;
    public Animator animationHp4;
    public Animator animationHp5;
    public float CountDown = 1f;
    

    public void LoseLife()
    {
        health--;

    }

    // Update is called once per frame
    void Update()
    { // Test pour voir animation coeurs 
        if (health == 4)
        {

            animationHp1.SetBool("Coeur4", true);

        }

        if (health == 3)
        {

            animationHp2.SetBool("Coeur3", true);

        }

        if (health == 2)
        {
            animationHp3.SetBool("Coeur2", true);

        }

        if (health == 1)
        {
            animationHp4.SetBool("Coeur1", true);
        }

        if (health == 0)
        {
            animationHp5.SetBool("Coeur", true);

        }

        if (health <= 0)// Fait apparaitre le panel GameOver
        {
            CountDown -= Time.deltaTime;
            if (CountDown <= 0)
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
