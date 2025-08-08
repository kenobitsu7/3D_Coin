using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // R�f�rence au gestionnaire de la sant�. 
    // Ce champ permet d'acc�der � la logique de gestion de la sant� du joueur.
    [SerializeField] private HealthManager healthManager;

    // M�thode publique qui sera appel�e pour red�marrer le niveau.
    public void RestartLevel()
    {
        // R�active le passage du temps dans le jeu (au cas o� il aurait �t� mis en pause).
        // Ceci met le Time.timeScale � 1, ce qui indique que le jeu est en temps r�el.
        Time.timeScale = 1;

        // Remet la sant� du joueur � la valeur de d�part (ici 3).
        // Cette ligne permet de r�initialiser la sant� du joueur � son �tat initial.
        healthManager.ManageHealth(3);

        // Recharge la sc�ne actuelle du jeu (ici la sc�ne nomm�e "Game").
        // SceneManager.LoadScene permet de charger une nouvelle sc�ne, ici la sc�ne "Game".
        SceneManager.LoadScene("Game");

        // R�initialise le score du jeu � 0 lorsque le niveau red�marre.
        // GameManager est une instance unique qui g�re les informations globales du jeu.
        GameManager.Instance.Score = 0;

        // R�initialise le nombre de kills � 0 lorsque le niveau red�marre.
        // Cela remet � z�ro la comptabilit� des ennemis tu�s dans ce niveau.
        GameManager.Instance.KillCount = 0;
    }
}
