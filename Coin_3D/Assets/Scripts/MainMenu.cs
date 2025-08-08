using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    // Ce script g�re les interactions du menu principal

    // Fonction pour quitter le jeu
    public void ExitButton()
    {
        // Quitte le jeu 
        Application.Quit();

        // Affiche un message dans la console pour indiquer que le jeu est ferm�
        Debug.Log("Game closed");
    }

    // Fonction pour d�marrer une nouvelle partie
    public void StartGame()
    {
        // Charge la sc�ne nomm�e "Game"
        SceneManager.LoadScene("Game");
    }
}
