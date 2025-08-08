using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerKnockback : MonoBehaviour
{
    // R�f�rence au Rigidbody du joueur (le composant physique)
    [SerializeField] private Rigidbody rb;

    // Force d'impact appliqu�e lors du knockback
    [SerializeField] private float strength = 10f;

    // D�lai avant de pouvoir appliquer un autre knockback
    [SerializeField] private float cooldown = 0.2f;

    // Variable pour stocker le temps du dernier knockback
    private float lastKnockbackTime = -Mathf.Infinity;

    // Fonction pour appliquer le knockback au joueur
    public void ApplyKnockback(Vector3 direction)
    {
        // V�rifie si le temps depuis le dernier knockback est inf�rieur au d�lai de cooldown
        if (Time.time - lastKnockbackTime < cooldown)
        {
            // Si oui, on ne fait rien (on ignore le knockback)
            return;
        }

        // Emp�che le knockback d'affecter la hauteur du joueur (on garde la direction horizontale seulement)
        direction.y = 0f;

        // Applique une force d'impulsion dans la direction donn�e, normalis�e et multipli�e par la force
        rb.AddForce(direction.normalized * strength, ForceMode.Impulse);

        // Met � jour le temps du dernier knockback pour respecter le cooldown
        lastKnockbackTime = Time.time;
    }
}
