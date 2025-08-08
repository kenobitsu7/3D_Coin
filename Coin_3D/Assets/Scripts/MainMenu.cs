using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Ce script gère les interactions du menu principal

    // Fonction pour quitter le jeu
    public void ExitButton()
    {
        // Quitte le jeu 
        Application.Quit();

        // Affiche un message dans la console pour indiquer que le jeu est fermé
        Debug.Log("Game closed");
    }

    // Fonction pour démarrer une nouvelle partie
    public void StartGame()
    {
        // Charge la scène nommée "Game"
        SceneManager.LoadScene("Game");
    }
}
