using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    
    public GameObject GameOver, heart1, heart2, heart3;
    private int health;

    // Start is called before the first frame update
    void Start()
    {
        health = 3;
        
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);
        GameOver.gameObject.SetActive(false);
    }

    // Update is called once per frame
    public void ManageHealth(int amount)
    {
        health += amount;

            switch (health)
            {
              
                case 3:                 
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(true);
                    break;
                case 2:                 
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(true);
                    heart3.gameObject.SetActive(false);
                    break;
                case 1:        
                    heart1.gameObject.SetActive(true);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);
                    break;
                case 0:                   
                    heart1.gameObject.SetActive(false);
                    heart2.gameObject.SetActive(false);
                    heart3.gameObject.SetActive(false);                    
                    GameOver.gameObject.SetActive(true);                    
                    Time.timeScale = 0;
                    break;           
            }
    }
}
