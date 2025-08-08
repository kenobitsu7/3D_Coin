using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

// Définition de la classe TimeDisplay
public class TimeDisplay : MonoBehaviour
{
    // Déclaration d'une variable publique pour afficher le temps à l'écran
    public TextMeshProUGUI displayTime;

    // La méthode Start est appelée une fois au début du jeu
    void Start()
    {
        // Appel de la méthode DisplayTime pour afficher le temps initial du GameManager
        DisplayTime(GameManager.Instance.Time);
    }

    // Méthode pour afficher le temps sous la forme minutes:secondes
    void DisplayTime(float timeToDisplay)
    {
        // Conversion du temps en minutes (en arrondissant à l'entier inférieur)
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        // Conversion du temps restant en secondes (en arrondissant à l'entier inférieur)
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formatage du texte pour l'affichage sous la forme MM:SS, avec des zéros si nécessaire
        displayTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
