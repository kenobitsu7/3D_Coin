using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class EnemyDamage : MonoBehaviour
{
    // Référence au gestionnaire de la santé du joueur
    [SerializeField] private HealthManager healthManager;
    // Valeur du dommage infligé par l'ennemi
    [SerializeField] private int damage = 1;

    // Méthode appelée lorsque la collision avec un autre objet se produit
    private void OnCollisionEnter(Collision collision)
    {
        // Vérifie si l'objet en collision est le joueur
        if (collision.gameObject.CompareTag("Player"))
        {
            // Inflige des dégâts au joueur en utilisant le HealthManager
            healthManager.ManageHealth(-damage);

            // Calcule la direction du knockback (poussée) en fonction de la position du joueur par rapport à l'ennemi
            Vector3 dir = (collision.transform.position - transform.position).normalized;

            // Applique le knockback au joueur s'il possède un script PlayerKnockback
            collision.gameObject.GetComponent<PlayerKnockback>()?.ApplyKnockback(dir);
        }
    }
}
