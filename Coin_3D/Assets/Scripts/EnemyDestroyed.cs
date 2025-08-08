using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using TMPro; 

public class EnemyDestroyed : MonoBehaviour
{
    // Déclaration d'une variable publique pour afficher le nombre d'ennemis détruits
    // Cette variable fait référence à un objet TextMeshProUGUI, qui sera lié à un champ texte dans l'interface utilisateur.
    public TextMeshProUGUI enemyDestroyedText;

    // La méthode Update est appelée une fois par frame.
    void Update()
    {
        // Mise à jour du texte affiché sur l'interface utilisateur
        // La propriété 'KillCount' de GameManager.Instance retourne le nombre d'ennemis tués.
        // Ce nombre est converti en chaîne de caractères avec 'ToString()' et est affiché dans 'enemyDestroyedText'.
        enemyDestroyedText.text = "Enemy Destroyed: " + GameManager.Instance.KillCount.ToString();
    }
}
