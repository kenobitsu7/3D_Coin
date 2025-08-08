using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// Classe principale qui g�re les donn�es globales du jeu
public class GameManager : MonoBehaviour
{
    // Instance statique pour impl�menter le pattern Singleton
    public static GameManager Instance;

    // Score du joueur
    private int score;
    public int Score { get { return score; } set { score = value; } }

    // Indique si le timer est arr�t�
    private bool timerIsStop;
    public bool TimerIsStop { get { return timerIsStop; } set { timerIsStop = value; } }

    // Temps actuel (peut repr�senter le temps �coul� ou restant selon l�usage)
    private float time;
    public float Time { get { return time; } set { time = value; } }

    // Nombre d'ennemis tu�s
    private int killCount;
    public int KillCount { get { return killCount; } set { killCount = value; } }

    // M�thode appel�e au moment de l�instanciation du GameObject
    private void Awake()
    {
        // Si aucune instance n'existe d�j�, celle-ci devient l'instance unique
        if (Instance == null)
        {
            Instance = this;

            // Ne pas d�truire ce GameObject lors des changements de sc�ne
            DontDestroyOnLoad(gameObject);
        }
        else
        {
            // S�il y a d�j� une instance, on d�truit celle-ci pour �viter les doublons
            Destroy(gameObject);
        }
    }
}
