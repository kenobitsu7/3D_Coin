using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting; 
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    // ------- D�claration des variables publiques et priv�es pour g�rer les sources et clips audio --------

    [Header("---------- Audio Source ----------")]
    [SerializeField] AudioSource musicSource; // Source audio pour la musique de fond
    [SerializeField] AudioSource SFXSource;   // Source audio pour les effets sonores (SFX)

    [Header("---------- Audio Clip ----------")]
    public AudioClip background;  // Clip audio pour la musique de fond
    public AudioClip coin;       // Clip audio pour le son du coin collect�
    public AudioClip gameOver;   // Clip audio pour le son de fin de jeu
    public AudioClip finalLevel; // Clip audio pour le son de niveau final

    // ------- M�thodes de gestion des sons --------

    // M�thode appel�e au d�marrage du jeu ou au lancement de ce script
    public void Start()
    {        
        // D�marre la musique de fond d�s le lancement du jeu
        musicSource.Play();
    }

    // M�thode pour jouer un effet sonore (SFX) � la demande
    public void PlaySFX(AudioClip clip)
    {
        // Joue un effet sonore sp�cifi� en param�tre, sans r�p�ter le clip
        SFXSource.PlayOneShot(clip);
    }

    // M�thode pour arr�ter la musique de fond
    public void StopMusic()
    {
        // Arr�te la musique de fond en cours
        musicSource.Stop();
    }
}
