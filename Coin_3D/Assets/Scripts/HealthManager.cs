using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthManager : MonoBehaviour
{
    [SerializeField] private AudioManager audioManager; // Référence à un AudioManager pour contrôler la musique du jeu
    private int health; // Variable privée pour gérer la santé du joueur

    // Propriété pour accéder et modifier la santé du joueur
    public int Health
    {
        get { return health; }
        set { health = value; }
    }

    public GameObject GameOver, heart1, heart2, heart3; // Références aux objets de l'interface utilisateur : Game Over et les cœurs

    // Start est appelé une seule fois au début du jeu
    void Start()
    {
        health = 3; // Initialise la santé à 3 au démarrage du jeu (le joueur commence avec 3 cœurs)

        // Active les cœurs au démarrage
        heart1.gameObject.SetActive(true);
        heart2.gameObject.SetActive(true);
        heart3.gameObject.SetActive(true);

        // Cache l'écran de Game Over au démarrage
        GameOver.gameObject.SetActive(false);
    }

    // Méthode qui gère la modification de la santé (ajouter ou soustraire de la santé)
    public void ManageHealth(int amount)
    {
        health += amount; // Modifie la santé en fonction de l'amount passé (positif ou négatif)

        // En fonction de la nouvelle valeur de la santé, on met à jour l'affichage des cœurs et du Game Over
        switch (health)
        {
            case 3: // Si la santé est à 3, on affiche tous les cœurs
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(true);
                break;

            case 2: // Si la santé est à 2, on cache le troisième cœur
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(true);
                heart3.gameObject.SetActive(false);
                break;

            case 1: // Si la santé est à 1, on cache les deux derniers cœurs
                heart1.gameObject.SetActive(true);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);
                break;

            case 0: // Si la santé atteint 0, on cache tous les cœurs et affiche l'écran de Game Over
                heart1.gameObject.SetActive(false);
                heart2.gameObject.SetActive(false);
                heart3.gameObject.SetActive(false);

                // Affiche l'écran de Game Over
                GameOver.gameObject.SetActive(true);

                // Met le jeu en pause
                Time.timeScale = 0;

                // Arrête la musique du jeu
                audioManager.StopMusic();
                break;
        }
    }
}
