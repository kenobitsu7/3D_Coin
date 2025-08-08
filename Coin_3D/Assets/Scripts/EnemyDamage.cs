using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // R�f�rence au gestionnaire de la sant� du joueur
    [SerializeField] private HealthManager healthManager;
    // Valeur du dommage inflig� par l'ennemi
    [SerializeField] private int damage = 1;

    // M�thode appel�e lorsque la collision avec un autre objet se produit
    private void OnCollisionEnter(Collision collision)
    {
        // V�rifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Inflige des d�g�ts au joueur en utilisant le HealthManager
            healthManager.ManageHealth(-damage);

            // Calcule la direction du knockback (pouss�e) en fonction de la position du joueur par rapport � l'ennemi
            Vector3 dir = (collision.transform.position - transform.position).normalized;

            // Applique le knockback au joueur s'il poss�de un script PlayerKnockback
            collision.gameObject.GetComponent<PlayerKnockback>()?.ApplyKnockback(dir);
        }
    }
}
