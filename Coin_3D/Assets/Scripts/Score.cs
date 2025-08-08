using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using TMPro; 

// Classe Score qui g�re l'affichage du score dans le jeu
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // R�f�rence � un composant TextMeshProUGUI o� le score sera affich�

    // Cette fonction est appel�e � chaque frame
    void Update()
    {
        // Met � jour le texte du score � chaque frame avec la valeur actuelle du score depuis le GameManager
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
