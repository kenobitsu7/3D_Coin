using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;  

// D�finition de la classe TimeDisplay
public class TimeDisplay : MonoBehaviour
{
    // D�claration d'une variable publique pour afficher le temps � l'�cran
    public TextMeshProUGUI displayTime;

    // La m�thode Start est appel�e une fois au d�but du jeu
    void Start()
    {
        // Appel de la m�thode DisplayTime pour afficher le temps initial du GameManager
        DisplayTime(GameManager.Instance.Time);
    }

    // M�thode pour afficher le temps sous la forme minutes:secondes
    void DisplayTime(float timeToDisplay)
    {
        // Conversion du temps en minutes (en arrondissant � l'entier inf�rieur)
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);

        // Conversion du temps restant en secondes (en arrondissant � l'entier inf�rieur)
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formatage du texte pour l'affichage sous la forme MM:SS, avec des z�ros si n�cessaire
        displayTime.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
