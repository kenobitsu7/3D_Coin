using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightPlaneManager : MonoBehaviour
{
    // Référence à la lumière directionnelle dans la scène (par exemple, lumière principale)
    [SerializeField] private GameObject directionalLight;

    // Tableau contenant les lumières supplémentaires à activer/désactiver
    [SerializeField] private GameObject[] lights;

    // Cette méthode est appelée lorsqu'un autre objet entre en collision avec le trigger
    private void OnTriggerEnter(Collider other)
    {
        // Vérifie si l'objet qui entre en collision est le joueur
        if (other.CompareTag("Player"))
        {
            // Désactive la lumière directionnelle (par exemple, pour simuler un changement d'éclairage)
            directionalLight.SetActive(false);

            // Active toutes les lumières supplémentaires dans le tableau "lights"
            foreach (GameObject light in lights)
            {
                light.SetActive(true);
            }
        }
    }

    // Cette méthode est appelée lorsqu'un autre objet quitte la collision avec le trigger
    private void OnTriggerExit(Collider other)
    {
        // Vérifie si l'objet qui quitte la zone est le joueur
        if (other.CompareTag("Player"))
        {
            // Réactive la lumière directionnelle (restaure l'éclairage original)
            directionalLight.SetActive(true);

            // Désactive toutes les lumières supplémentaires dans le tableau "lights"
            foreach (GameObject light in lights)
            {
                light.SetActive(false);
            }
        }
    }
}
