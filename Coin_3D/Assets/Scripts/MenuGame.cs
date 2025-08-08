using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class MenuGame : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager; // Déclaration d'une référence publique au gestionnaire de la santé. 

    // Méthode appelée pour quitter le niveau actuel et revenir au menu principal.
    public void ExitLevel()
    {
        Time.timeScale = 1; // Remet le temps du jeu à sa vitesse normale (si le jeu était en pause, il reprend son rythme normal).

        // Appelle la méthode ManageHealth du gestionnaire de la santé, ici avec un paramètre (3). 
        healthManager.ManageHealth(3);

        // Charge la scène "MainMenu", donc le joueur est redirigé vers le menu principal.
        SceneManager.LoadScene("MainMenu");

        // Réinitialise les variables de score et de nombre de kills dans le GameManager à 0.
        GameManager.Instance.Score = 0;
        GameManager.Instance.KillCount = 0;
    }
}
