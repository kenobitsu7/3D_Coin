using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Index de la scène à charger une fois que le joueur sort du niveau
    public int sceneBuildIndex;

    // Référence au script CountdownTimer pour récupérer le temps restant
    public CountdownTimer countdownTimer;

    // Cette méthode est appelée lorsqu'un autre objet entre en collision avec le collider attaché à cet objet
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre en collision est le joueur (tag "Player")
        if (other.tag == "Player")
        {
            // Arrête le timer du GameManager (indique que le temps ne doit plus être compté)
            GameManager.Instance.TimerIsStop = true;

            // Met à jour le temps du GameManager avec la valeur actuelle du compte à rebours
            GameManager.Instance.Time = countdownTimer.timeValue;

            // Charge la scène spécifiée par l'index dans le tableau des scènes du build
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
