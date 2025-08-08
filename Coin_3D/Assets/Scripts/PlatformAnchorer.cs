using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnchorer : MonoBehaviour
{
    // Déclare une variable pour stocker la référence au parent d'origine de l'objet
    private Transform originalparent;

    // Méthode appelée au démarrage du jeu
    private void Start()
    {
        // Initialisation du parent d'origine à null
        originalparent = null;
    }

    // Méthode appelée lorsqu'un autre objet entre dans le déclencheur (Trigger)
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre dans le déclencheur possède le tag "Platform"
        if (other.CompareTag("Platform"))
        {
            // Change le parent de cet objet pour celui de l'objet avec le tag "Platform"
            transform.parent = other.transform;
        }
    }

    // Méthode appelée lorsqu'un autre objet sort du déclencheur (Trigger)
    private void OnTriggerExit(Collider other)
    {
        // Vérifie si l'objet qui quitte le déclencheur possède le tag "Platform"
        if (other.CompareTag("Platform"))
        {
            // Restaure le parent original de cet objet
            transform.parent = originalparent;
        }
    }
}
