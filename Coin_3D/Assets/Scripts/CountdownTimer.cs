using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

// Script pour un compteur de temps
public class CountdownTimer : MonoBehaviour
{
    // R�f�rence au gestionnaire audio (AudioManager)
    [SerializeField] private AudioManager audioManager;

    // Texte � afficher pour le timer
    public TextMeshProUGUI timerText;

    // Valeur initiale du timer (en secondes)
    public float timeValue = 90;

    // R�f�rence � l'objet GameOver qui sera affich� � la fin du jeu
    public GameObject GameOver;

    // Mise � jour du timer chaque frame
    void Update()
    {
        // V�rifie si le timer doit s'arr�ter ou non
        if (!GameManager.Instance.TimerIsStop)
        {
            // Si le temps restant est plus grand que 0, d�cr�mente le timer
            if (timeValue > 0)
            {
                timeValue -= Time.deltaTime;
            }
            else
            {
                // Si le temps est �coul�, le timer ne devient pas n�gatif
                timeValue = 0;
            }

            // Affiche l'heure restante sur l'�cran
            DisplayTime(timeValue);
        }
    }

    // Affiche l'heure restante sous forme de minutes et secondes
    void DisplayTime(float timeToDisplay)
    {
        // Si le temps est �coul� (moins que 0), met le timer � 0 et affiche GameOver
        if (timeToDisplay < 0)
        {
            timeToDisplay = 0;

            // Affiche l'�cran de fin de jeu
            GameOver.gameObject.SetActive(true);

            // Arr�te le temps (effet de pause)
            Time.timeScale = 0;

            // Arr�te la musique de fond
            audioManager.StopMusic();
        }
        else if (timeToDisplay > 0)
        {
            // Si le temps est sup�rieur � 0, ajoute 1 pour compenser une petite erreur de calcul li�e � Time.deltaTime
            timeToDisplay += 1;
        }

        // Calcule les minutes et secondes restantes
        float minutes = Mathf.FloorToInt(timeToDisplay / 60);
        float seconds = Mathf.FloorToInt(timeToDisplay % 60);

        // Formate le temps pour l'affichage sous forme de minutes:secondes
        timerText.text = string.Format("{0:00}:{1:00}", minutes, seconds);
    }
}
