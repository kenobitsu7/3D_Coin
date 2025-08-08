using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RestartGame : MonoBehaviour
{
    // Référence au gestionnaire de la santé. 
    // Ce champ permet d'accéder à la logique de gestion de la santé du joueur.
    [SerializeField] private HealthManager healthManager;

    // Méthode publique qui sera appelée pour redémarrer le niveau.
    public void RestartLevel()
    {
        // Réactive le passage du temps dans le jeu (au cas où il aurait été mis en pause).
        // Ceci met le Time.timeScale à 1, ce qui indique que le jeu est en temps réel.
        Time.timeScale = 1;

        // Remet la santé du joueur à la valeur de départ (ici 3).
        // Cette ligne permet de réinitialiser la santé du joueur à son état initial.
        healthManager.ManageHealth(3);

        // Recharge la scène actuelle du jeu (ici la scène nommée "Game").
        // SceneManager.LoadScene permet de charger une nouvelle scène, ici la scène "Game".
        SceneManager.LoadScene("Game");

        // Réinitialise le score du jeu à 0 lorsque le niveau redémarre.
        // GameManager est une instance unique qui gère les informations globales du jeu.
        GameManager.Instance.Score = 0;

        // Réinitialise le nombre de kills à 0 lorsque le niveau redémarre.
        // Cela remet à zéro la comptabilité des ennemis tués dans ce niveau.
        GameManager.Instance.KillCount = 0;
    }
}
