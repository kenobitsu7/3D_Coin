using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager;
    private int health;
    public int Health {  get { return health; } set { health = value; } }
    public GameObject GameOver, heart1, heart2, heart3;

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
                    audioManager.StopMusic();
                    break;           
            }
    }
}
