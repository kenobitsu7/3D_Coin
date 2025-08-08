using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class MenuReturn : MonoBehaviour
{
    // Cette m�thode est appel�e lorsqu'un autre objet entre en collision avec cet objet
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre en collision a le tag "Player"
        if (other.tag == "Player")
        {
            // Charge la sc�ne "MainMenu" lorsque le joueur entre en collision
            SceneManager.LoadScene("MainMenu");

            // R�initialise les valeurs du gestionnaire de jeu

            // R�initialisation du score � 0
            GameManager.Instance.Score = 0;
            // R�initialisation du nombre de tu�s � 0
            GameManager.Instance.KillCount = 0;

            // Arr�te le timer (au cas o� il �tait actif)
            GameManager.Instance.TimerIsStop = false;
            // R�initialise le temps restant � 90 secondes
            GameManager.Instance.Time = 90f;
        }
    }
}
