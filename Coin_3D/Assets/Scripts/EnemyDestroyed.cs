using System.Collections; 
using System.Collections.Generic; 
using UnityEngine; 
using TMPro; 

public class EnemyDestroyed : MonoBehaviour
{
    // D�claration d'une variable publique pour afficher le nombre d'ennemis d�truits
    // Cette variable fait r�f�rence � un objet TextMeshProUGUI, qui sera li� � un champ texte dans l'interface utilisateur.
    public TextMeshProUGUI enemyDestroyedText;

    // La m�thode Update est appel�e une fois par frame.
    void Update()
    {
        // Mise � jour du texte affich� sur l'interface utilisateur
        // La propri�t� 'KillCount' de GameManager.Instance retourne le nombre d'ennemis tu�s.
        // Ce nombre est converti en cha�ne de caract�res avec 'ToString()' et est affich� dans 'enemyDestroyedText'.
        enemyDestroyedText.text = "Enemy Destroyed: " + GameManager.Instance.KillCount.ToString();
    }
}
