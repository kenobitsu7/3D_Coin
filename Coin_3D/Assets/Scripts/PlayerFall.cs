using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// Définition de la classe PlayerFall qui hérite de MonoBehaviour
public class PlayerFall : MonoBehaviour
{
    // Déclaration d'un champ public sérialisé pour gérer la santé du joueur via un autre script
    [SerializeField] private HealthManager healthManager;

    // Référence à l'objet Player (peut être utilisé pour désactiver le joueur en cas de chute)
    public GameObject Player;

    // Déclenchement de l'événement lorsque quelque chose entre en collision avec le collider du joueur
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet avec lequel le joueur entre en collision possède le tag "DeathCollider"
        if (other.gameObject.CompareTag("DeathCollider"))
        {
            // Si c'est le cas, gère la santé du joueur en réduisant toute la vie (rester -healthManager.Health)
            healthManager.ManageHealth(-healthManager.Health);

            // Désactive l'objet Player (simule que le joueur est "mort" ou tombe)
            Player.gameObject.SetActive(false);

            // Met en pause le temps dans le jeu (arrête toutes les actions du jeu)
            Time.timeScale = 0;
        }
    }
}
