using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelExit : MonoBehaviour
{
    // Index de la sc�ne � charger une fois que le joueur sort du niveau
    public int sceneBuildIndex;

    // R�f�rence au script CountdownTimer pour r�cup�rer le temps restant
    public CountdownTimer countdownTimer;

    // Cette m�thode est appel�e lorsqu'un autre objet entre en collision avec le collider attach� � cet objet
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre en collision est le joueur (tag "Player")
        if (other.tag == "Player")
        {
            // Arr�te le timer du GameManager (indique que le temps ne doit plus �tre compt�)
            GameManager.Instance.TimerIsStop = true;

            // Met � jour le temps du GameManager avec la valeur actuelle du compte � rebours
            GameManager.Instance.Time = countdownTimer.timeValue;

            // Charge la sc�ne sp�cifi�e par l'index dans le tableau des sc�nes du build
            SceneManager.LoadScene(sceneBuildIndex, LoadSceneMode.Single);
        }
    }
}
