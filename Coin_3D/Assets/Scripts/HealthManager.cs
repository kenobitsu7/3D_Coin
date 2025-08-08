using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager; // R�f�rence � un AudioManager pour contr�ler la musique du jeu
    private int health; // Variable priv�e pour g�rer la sant� du joueur

    // Propri�t� pour acc�der et modifier la sant� du joueur
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject GameOver, heart1, heart2, heart3; // R�f�rences aux objets de l'interface utilisateur : Game Over et les c�urs

    // Start est appel� une seule fois au d�but du jeu
    void Start()
    {
        health = 3; // Initialise la sant� � 3 au d�marrage du jeu (le joueur commence avec 3 c�urs)

        // Active les c�urs au d�marrage
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        // Cache l'�cran de Game Over au d�marrage
        GameOver.gameObject.SetActive(false);
    }

    // M�thode qui g�re la modification de la sant� (ajouter ou soustraire de la sant�)
    public void ManageHealth(int amount)
    {
        health += amount; // Modifie la sant� en fonction de l'amount pass� (positif ou n�gatif)

        // En fonction de la nouvelle valeur de la sant�, on met � jour l'affichage des c�urs et du Game Over
        switch (health)
        {
            case 3: // Si la sant� est � 3, on affiche tous les c�urs
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2: // Si la sant� est � 2, on cache le troisi�me c�ur
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1: // Si la sant� est � 1, on cache les deux derniers c�urs
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0: // Si la sant� atteint 0, on cache tous les c�urs et affiche l'�cran de Game Over
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                // Affiche l'�cran de Game Over
                GameOver.gameObject.SetActive(true);

                // Met le jeu en pause
                Time.timeScale = 0;

                // Arr�te la musique du jeu
                audioManager.StopMusic();
                break;
        }
    }
}
