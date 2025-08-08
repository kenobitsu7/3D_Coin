using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformAnchorer : MonoBehaviour
{
    // D�clare une variable pour stocker la r�f�rence au parent d'origine de l'objet
    private Transform originalparent;

    // M�thode appel�e au d�marrage du jeu
    private void Start()
    {
        // Initialisation du parent d'origine � null
        originalparent = null;
    }

    // M�thode appel�e lorsqu'un autre objet entre dans le d�clencheur (Trigger)
    private void OnTriggerEnter(Collider other)
    {
        // V�rifie si l'objet qui entre dans le d�clencheur poss�de le tag "Platform"
        if (other.CompareTag("Platform"))
        {
            // Change le parent de cet objet pour celui de l'objet avec le tag "Platform"
            transform.parent = other.transform;
        }
    }

    // M�thode appel�e lorsqu'un autre objet sort du d�clencheur (Trigger)
    private void OnTriggerExit(Collider other)
    {
        // V�rifie si l'objet qui quitte le d�clencheur poss�de le tag "Platform"
        if (other.CompareTag("Platform"))
        {
            // Restaure le parent original de cet objet
            transform.parent = originalparent;
        }
    }
}
