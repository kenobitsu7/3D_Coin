using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    // Référence au Rigidbody du joueur (le composant physique)
    [SerializeField] private Rigidbody rb;

    // Force d'impact appliquée lors du knockback
    [SerializeField] private float strength = 10f;

    // Délai avant de pouvoir appliquer un autre knockback
    [SerializeField] private float cooldown = 0.2f;

    // Variable pour stocker le temps du dernier knockback
    private float lastKnockbackTime = -Mathf.Infinity;

    // Fonction pour appliquer le knockback au joueur
    public void ApplyKnockback(Vector3 direction)
    {
        // Vérifie si le temps depuis le dernier knockback est inférieur au délai de cooldown
        if (Time.time - lastKnockbackTime < cooldown)
        {
            // Si oui, on ne fait rien (on ignore le knockback)
            return;
        }

        // Empêche le knockback d'affecter la hauteur du joueur (on garde la direction horizontale seulement)
        direction.y = 0f;

        // Applique une force d'impulsion dans la direction donnée, normalisée et multipliée par la force
        rb.AddForce(direction.normalized * strength, ForceMode.Impulse);

        // Met à jour le temps du dernier knockback pour respecter le cooldown
        lastKnockbackTime = Time.time;
    }
}
