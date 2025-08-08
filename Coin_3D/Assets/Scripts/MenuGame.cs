using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.SceneManagement; 

public class MenuGame : MonoBehaviour
{
    [SerializeField] private HealthManager healthManager; // D�claration d'une r�f�rence publique au gestionnaire de la sant�. 

    // M�thode appel�e pour quitter le niveau actuel et revenir au menu principal.
    public void ExitLevel()
    {
        Time.timeScale = 1; // Remet le temps du jeu � sa vitesse normale (si le jeu �tait en pause, il reprend son rythme normal).

        // Appelle la m�thode ManageHealth du gestionnaire de la sant�, ici avec un param�tre (3). 
        healthManager.ManageHealth(3);

        // Charge la sc�ne "MainMenu", donc le joueur est redirig� vers le menu principal.
        SceneManager.LoadScene("MainMenu");

        // R�initialise les variables de score et de nombre de kills dans le GameManager � 0.
        GameManager.Instance.Score = 0;
        GameManager.Instance.KillCount = 0;
    }
}
