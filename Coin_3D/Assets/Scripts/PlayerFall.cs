using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

// D�finition de la classe PlayerFall qui h�rite de MonoBehaviour
public class PlayerFall : MonoBehaviour
{
    // D�claration d'un champ public s�rialis� pour g�rer la sant� du joueur via un autre script
    [SerializeField] private HealthManager healthManager;

    // R�f�rence � l'objet Player (peut �tre utilis� pour d�sactiver le joueur en cas de chute)
    public GameObject Player;

    // D�clenchement de l'�v�nement lorsque quelque chose entre en collision avec le collider du joueur
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet avec lequel le joueur entre en collision poss�de le tag "DeathCollider"
        if (other.gameObject.CompareTag("DeathCollider"))
        {
            // Si c'est le cas, g�re la sant� du joueur en r�duisant toute la vie (rester -healthManager.Health)
            healthManager.ManageHealth(-healthManager.Health);

            // D�sactive l'objet Player (simule que le joueur est "mort" ou tombe)
            Player.gameObject.SetActive(false);

            // Met en pause le temps dans le jeu (arr�te toutes les actions du jeu)
            Time.timeScale = 0;
        }
    }
}
