using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; 
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ------- Déclaration des variables publiques et privées pour gérer les sources et clips audio --------

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource; // Source audio pour la musique de fond
    [SerializeField] AudioSource SFXSource;   // Source audio pour les effets sonores (SFX)

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;  // Clip audio pour la musique de fond
    public AudioClip coin;       // Clip audio pour le son du coin collecté
    public AudioClip gameOver;   // Clip audio pour le son de fin de jeu
    public AudioClip finalLevel; // Clip audio pour le son de niveau final

    // ------- Méthodes de gestion des sons --------

    // Méthode appelée au démarrage du jeu ou au lancement de ce script
    public void Start()
    {        
        // Démarre la musique de fond dès le lancement du jeu
        musicSource.Play();
    }

    // Méthode pour jouer un effet sonore (SFX) à la demande
    public void PlaySFX(AudioClip clip)
    {
        // Joue un effet sonore spécifié en paramètre, sans répéter le clip
        SFXSource.PlayOneShot(clip);
    }

    // Méthode pour arrêter la musique de fond
    public void StopMusic()
    {
        // Arrête la musique de fond en cours
        musicSource.Stop();
    }
}
