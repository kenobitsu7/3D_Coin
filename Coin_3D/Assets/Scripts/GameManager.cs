using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe principale qui gère les données globales du jeu
public class GameManager : MonoBehaviour
{
    // Instance statique pour implémenter le pattern Singleton
    public static GameManager Instance;

    // Score du joueur
    private int score;
    public int Score { get { return score; } set { score = value; } }

    // Indique si le timer est arrêté
    private bool timerIsStop;
    public bool TimerIsStop { get { return timerIsStop; } set { timerIsStop = value; } }

    // Temps actuel (peut représenter le temps écoulé ou restant selon l’usage)
    private float time;
    public float Time { get { return time; } set { time = value; } }

    // Nombre d'ennemis tués
    private int killCount;
    public int KillCount { get { return killCount; } set { killCount = value; } }

    // Méthode appelée au moment de l’instanciation du GameObject
    private void Awake()
    {
        // Si aucune instance n'existe déjà, celle-ci devient l'instance unique
        if (Instance == null)
        {
            Instance = this;

            // Ne pas détruire ce GameObject lors des changements de scène
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // S’il y a déjà une instance, on détruit celle-ci pour éviter les doublons
            Destroy(gameObject);
        }
    }
}
