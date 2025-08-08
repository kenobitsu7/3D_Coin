using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Script pour un compteur de temps
public class CountdownTimer : MonoBehaviour
{
    // Référence au gestionnaire audio (AudioManager)
    [SerializeField] private AudioManager audioManager;

    // Texte à afficher pour le timer
    public TextMeshProUGUI timerText;

    // Valeur initiale du timer (en secondes)
    public float timeValue = 90;

    // Référence à l'objet GameOver qui sera affiché à la fin du jeu
    public GameObject GameOver;

    // Mise à jour du timer chaque frame
    void Update()
    {
        // Vérifie si le timer doit s'arrêter ou non
        if (!GameManager.Instance.TimerIsStop)
        {
            // Si le temps restant est plus grand que 0, décrémente le timer
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                // Si le temps est écoulé, le timer ne devient pas négatif
                timeValue = 0;
            }

            // Affiche l'heure restante sur l'écran
            DisplayTime(timeValue);
        }
    }

    // Affiche l'heure restante sous forme de minutes et secondes
    void DisplayTime(float timeToDisplay)
    {
        // Si le temps est écoulé (moins que 0), met le timer à 0 et affiche GameOver
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;

            // Affiche l'écran de fin de jeu
            GameOver.gameObject.SetActive(true);

            // Arrête le temps (effet de pause)
            Time.timeScale = 0;

            // Arrête la musique de fond
            audioManager.StopMusic();
        }
        else if (timeToDisplay > 0)
        {
            // Si le temps est supérieur à 0, ajoute 1 pour compenser une petite erreur de calcul liée à Time.deltaTime
            timeToDisplay += 1;
        }

        // Calcule les minutes et secondes restantes
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formate le temps pour l'affichage sous forme de minutes:secondes
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
