using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using UnityEngine.UI; 
using TMPro; 

// Classe Score qui gère l'affichage du score dans le jeu
public class Score : MonoBehaviour
{
    public TextMeshProUGUI scoreText; // Référence à un composant TextMeshProUGUI où le score sera affiché

    // Cette fonction est appelée à chaque frame
    void Update()
    {
        // Met à jour le texte du score à chaque frame avec la valeur actuelle du score depuis le GameManager
        scoreText.text = "Score: " + GameManager.Instance.Score;
    }
}
