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
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.A))
        {
            health--;
        }
         if (Input.GetKeyDown(KeyCode.B) && health == 5)
        {
           
            animationHp1.SetBool("Coeur4", true);

        }
        if (Input.GetKeyDown(KeyCode.B) && health == 4)
        {
            
            animationHp2.SetBool("Coeur3", true);

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
        if (health <= 0)
        {
            GameOver gameOver = FindObjectOfType<GameOver>();
            gameOver.GameOverOn();
            

        }

    }
}
