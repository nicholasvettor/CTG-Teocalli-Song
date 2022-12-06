using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class PlayerStat : MonoBehaviour
{

    public int CurrentHealth = 100;

    public int MaxHealth = 100;

    public int MinHealth = 0;

    public Image deathScreen;

    public TextMeshPro deathText;

    public Image heart1;

    public Image heart2;

    public Image heart3;

    public Sprite damagedHeartSprite;

    public Sprite normalHeartSprite;

    public bool LIGHTNINGPOWER;

    public Image movingThing;

    // Start is called before the first frame update
    void Start()
    {
        
        CurrentHealth = 100;

    }

    // Update is called once per frame
    void Update()
    {
        if(CurrentHealth < 1)
        {
            deathScreen.gameObject.SetActive(true);

            heart1.gameObject.SetActive(false);
            heart2.gameObject.SetActive(false);
            heart3.gameObject.SetActive(false);

            movingThing.gameObject.SetActive(false);

            Invoke("endGame", 5f);

        }
        if(CurrentHealth < 99)
        {
            heart1.sprite = damagedHeartSprite;

            if (CurrentHealth < 66)
            {
                heart2.sprite = damagedHeartSprite;

                if (CurrentHealth < 33)
                {
                    heart3.sprite = damagedHeartSprite;

                }
                else
                {
                    heart3.sprite = normalHeartSprite;
                }
            }
            else
            {
                heart2.sprite = normalHeartSprite;
            }
            
        }
        else
        {
            heart1.sprite = normalHeartSprite;
        }

    }

    void endGame()
    {
        Debug.Log("Closing game!");

        Application.Quit();
    }

}
