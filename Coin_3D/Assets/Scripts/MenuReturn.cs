using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class MenuReturn : MonoBehaviour
{
    // Cette méthode est appelée lorsqu'un autre objet entre en collision avec cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre en collision a le tag "Player"
        if (other.tag == "Player")
        {
            // Charge la scène "MainMenu" lorsque le joueur entre en collision
            SceneManager.LoadScene("MainMenu");

            // Réinitialise les valeurs du gestionnaire de jeu

            // Réinitialisation du score à 0
            GameManager.Instance.Score = 0;
            // Réinitialisation du nombre de tués à 0
            GameManager.Instance.KillCount = 0;

            // Arrête le timer (au cas où il était actif)
            GameManager.Instance.TimerIsStop = false;
            // Réinitialise le temps restant à 90 secondes
            GameManager.Instance.Time = 90f;
        }
    }
}
